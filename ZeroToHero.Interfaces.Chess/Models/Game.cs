using System.IO.Pipelines;
using ZeroToHero.Interfaces.Chess.Services.Implementations;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public class Game
    {
        public Game()
        {
            InitializeGame();
        }
        public IBoard Board { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player Opposition { get; set; }
        public List<MoveResponse> MoveResponses { get; set; }
        public bool IsGameOver => KingInDangerType == KingInDangerType.Checkmate || IsDraw;
        private bool IsDraw => KingInDangerType == KingInDangerType.Stalemate;
        private KingInDangerType KingInDangerType { get; set; }
        private List<Player> Players { get; set; }

        public bool UndoMove()
        {
            if (MoveResponses.Count > 0)
            {
                // Get the last move response
                var lastMoveResponse = MoveResponses.Last();

                // Revert the game state based on the last move
                RevertMove(lastMoveResponse);

                // Remove the last move response from the list
                MoveResponses.Remove(lastMoveResponse);

                return true;
            }

            return false; // No moves to undo
        }

        private void RevertMove(MoveResponse moveResponse)
        {
            // Retrieve information from the move response
            string fromPosition = moveResponse.MoveRequest.FromPosition;
            string toPosition = moveResponse.MoveRequest.ToPosition;

            var fromPiece = moveResponse?.MoveRequest?.FromChessPiece;
            var toPiece = moveResponse?.MoveRequest?.ToPiece;

            // Get the tiles involved in the move
            Tile fromTile = Board.GetTile(fromPosition);
            Tile toTile = Board.GetTile(toPosition);

            // Revert the move on the board
            toTile.SetPiece(toPiece!);
            fromTile.SetPiece(fromPiece!);

            SwitchPlayers();
        }

        public void SwitchPlayers()
        {
            var nextPlayer = Players.First(player => !player.IsCurrentlyPlaying);
            var currentPlayer = Players.First(player => player.IsCurrentlyPlaying);
            currentPlayer.SetCurrentlyPlaying(false);
            nextPlayer.SetCurrentlyPlaying(true);
            CurrentPlayer = nextPlayer;
            Opposition = currentPlayer;
        }

        public void ResetGame()
        {
            InitializeGame();
        }
        public MoveResponse MovePiece(MoveRequest request)
        {
            var destinationTile = Board.GetTile(request.ToPosition);
            var selectedTile = Board.GetTile(request.FromPosition);

            var validator = new MoveValidator(Board, MoveResponses);
            (bool validMove, string message) = validator.ValidateMove(selectedTile, destinationTile, CurrentPlayer);

            var color = selectedTile!.Piece!.Color;
            if (!validMove)
            {
                return GetMoveResponse(request, message, validMove, color);
            }

            var isTileAvailable = destinationTile!.IsOccupiedBy(Opposition.Color) || !destinationTile.IsOccupied;

            if (!isTileAvailable)
            {
                return GetMoveResponse(request, message: $"Invalid move, not your turn to play {Opposition.Color}", isSuccess: false, color);
            }

            if (KingInDangerType != KingInDangerType.None)
            {
                var kingIsSaved = KingIsSaved(selectedTile, destinationTile, color);
                if (!kingIsSaved)
                {
                    return GetMoveResponse(request, message: "Invalid Move, king is still in check", isSuccess: false, color);
                }
            }

            HandleMovePiece(destinationTile, selectedTile);

            var kingResponse = CheckKingInDanger();
            KingInDangerType = kingResponse.Type;

            return GetMoveResponse(
                request,
                message: KingInDangerType != KingInDangerType.None ? kingResponse.Message : "Piece moved successfully",
                isSuccess: true,
                color
            );
        }

        private void HandleMovePiece(Tile destinationTile, Tile? selectedTile)
        {
            destinationTile.SetPiece(selectedTile.Piece);
            selectedTile.Piece.HasMoved = true;

            Board.SetTile(destinationTile.Position, destinationTile);
            Board.DeselectAllTiles();
            selectedTile.ClearPiece();
            SwitchPlayers();
        }

        private KingInDanger CheckKingInDanger()
        {
            var kingPiece = CurrentPlayer.Color == ChessPieceColor.White ?
                             Board
                            .Squares
                            .First(x => x.IsOccupied && x?.Piece?.Type == ChessPieceType.King && x.Piece.Color == ChessPieceColor.White)
                            :
                             Board
                            .Squares
                            .First(x => x.IsOccupied && x?.Piece?.Type == ChessPieceType.King && x.Piece.Color == ChessPieceColor.Black);

            var king = kingPiece.Piece as IKing;

            if (king.IsChecked(Board))
            {
                if (king.IsCheckmate(Board))
                {
                    return new KingInDanger { Message = "Checkmate", Type = KingInDangerType.Checkmate };
                }

                return new KingInDanger { Message = "Check", Type = KingInDangerType.Check };
            }
            if (king.IsStalemate(Board))
            {
                return new KingInDanger { Message = "Stalemate", Type = KingInDangerType.Stalemate };
            }

            return new KingInDanger { Message = "No danger", Type = KingInDangerType.None };
        }

        private bool KingIsSaved(Tile from, Tile to, ChessPieceColor color)
        {
            var tempBoard = Board.Copy();
            // Find the source tile
            var sourceTile = tempBoard.GetTile(from.Position);

            // Find the destination tile
            var destinationTile = tempBoard.GetTile(to.Position);
            // Move the piece (assuming that a piece exists on the source tile)
            destinationTile.SetPiece(sourceTile.Piece);
            sourceTile.ClearPiece();
            var currentKingOnBoard = tempBoard.Squares.First(x => x.IsOccupied && x.Piece?.Type == ChessPieceType.King && x.Piece.Color == color).Piece as IKing;
            // Check if the king is still in check after the move
            var newKing = new King(color) { Id = currentKingOnBoard.Id };
            var isChecked = newKing.IsChecked(tempBoard);
            return !isChecked;
        }

        private void InitializeGame(List<Player> players = null)
        {
            Board = new Board();

            if(players is null)
            {
               Players = [
                        new(1, ChessPieceColor.White, "Player 1", true),
                        new(2, ChessPieceColor.Black, "Player 2", false)
               ];
            }

            CurrentPlayer = Players.First(player => player.IsCurrentlyPlaying);
            Opposition = Players.First(player => !player.IsCurrentlyPlaying);
            MoveResponses = [];
            KingInDangerType = KingInDangerType.None;
        }

        private void AddMoveResponse(MoveResponse response, bool isSuccess)
        {
            if (isSuccess && response.MoveRequest.FromChessPiece is not null)
            {
                MoveResponses.Add(response);
            }
        }
        private MoveResponse GetMoveResponse(MoveRequest request, string message, bool isSuccess, ChessPieceColor color)
        {
            Board.DeselectAllTiles();

            var response = new MoveResponse
            {
                IsSuccessful = isSuccess,
                Message = message,
                MoveRequest = request,
                Color = color
            };

            AddMoveResponse(response, isSuccess);

            return response;
        }

        public void UpdateScores()
        {
            if (IsDraw)
            {
                CurrentPlayer.Score.IncrementDraws();
                Opposition.Score.IncrementDraws();
                return;
            }
            // Current player has been checkmated, therefore lost
            CurrentPlayer.Score.IncrementLosses();
            // Winner is always the one who is not currently playing
            Opposition.Score.IncrementLosses();
        }

        public Player GetWinner()
        {
            // Winner is always the one who is not currently playing
            return Players.First(x => !x.IsCurrentlyPlaying);
        }

        public void PlayAgain()
        {
            var players = new List<Player>()
            {
                CurrentPlayer, Opposition
            };
            InitializeGame(players);
        }
    }
}