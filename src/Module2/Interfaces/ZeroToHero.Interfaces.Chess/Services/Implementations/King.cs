using System.Globalization;
using ZeroToHero.Interfaces.Chess.Models;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Services.Implementations
{
    public class King(ChessPieceColor color) : IKing
    {
        private List<AvailableMove> _availableMoves = [];
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsAlive { get; set; } = true;
        public ChessPieceColor Color { get; set; } = color;
        public ChessPieceType Type => ChessPieceType.King;
        public bool HasMoved { get; set; }

        public string ImagePath => $"images/{Color.ToString().ToLower()}{Type}.png";

        public List<AvailableMove> GetPossibleMoves(IBoard board)
        {
            _availableMoves.Clear();

            // Get the current tile of the king
            var currentTile = board.Squares.FirstOrDefault(x => x.IsOccupied && x.Piece?.Id == Id);

            if (currentTile == null)
            {
                // King not found on the board
                return _availableMoves;
            }

            // Define the possible moves for a king using Direction
            var directions = new List<Direction>
            {
                new(0, 1),   // One square up
                new(0, -1),  // One square down
                new(-1, 0),  // One square left
                new(1, 0),   // One square right
                new(-1, 1),  // Diagonal top-left
                new(1, 1),   // Diagonal top-right
                new(-1, -1), // Diagonal bottom-left
                new(1, -1)   // Diagonal bottom-right
            };

            var opponentColor = color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;

            // Check possible moves
            foreach (var direction in directions)
            {
                int newFile = currentTile.Position[0] + direction.FileChange;
                int newRank = int.Parse($"{currentTile.Position[1]}", CultureInfo.InvariantCulture) + direction.RankChange;

                if (AvailableMovesHelper.IsMoveValid(board, newFile, newRank, opponentColor))
                {
                    string newPosition = $"{(char)newFile}{newRank}";
                    _availableMoves.Add(new AvailableMove(newPosition, MoveType.Regular));
                }
            }

            return _availableMoves;
        }

        public bool IsChecked(IBoard board)
        {
            // Get the current tile of the king
            var kingTile = board.Squares.FirstOrDefault(x => x.IsOccupied && x.Piece?.Id == Id);

            if (kingTile == null)
            {
                // King not found on the board
                return false;
            }

            // Check if any opponent's piece has a valid move to capture the king
            var opponentColor = Color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;
            var opponentPieces = board.GetChessPiecesByColor(opponentColor);
            foreach (var tile in opponentPieces)
            {
                var opponentPiece = tile.Piece;
                var opponentMoves = opponentPiece?.GetPossibleMoves(board);

                if (opponentMoves?.Any(move => move.DestinationPosition == kingTile.Position) ?? false)
                {
                    // The king is in check
                    return true;
                }
            }

            return false;
        }

        public bool IsCheckmate(IBoard board)
        {
            // Check if the king is in check
            if (!IsChecked(board))
            {
                // The king is not in check, so it can't be checkmated
                return false;
            }

            // Check if the king has any valid moves to escape check
            var kingMoves = GetPossibleMoves(board);
            var opponentColor = Color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.Black;

            if (!kingMoves.Any(x => board.IsTileControlledBy(x.DestinationPosition, opponentColor)))
            {
                // The king has at least one valid move to escape check
                return false;
            }

            // Check if any friendly piece can block or capture the attacking piece
            var kingsArmyTiles = board
                .GetChessPiecesByColor(color)
                .Where(x => x.Piece.Type != ChessPieceType.King)
                .ToArray();

            foreach (var tile in kingsArmyTiles)
            {
                var friendlyPiece = tile.Piece;
                var friendlyMoves = friendlyPiece?.GetPossibleMoves(board) ?? [];

                foreach (var move in friendlyMoves)
                {
                    var tempBoard = board.Copy();

                    // Find the source tile
                    var sourceTile = tempBoard.GetTile(tile.Position);

                    // Find the destination tile
                    var destinationTile = tempBoard.GetTile(move.DestinationPosition);

                    // Move the piece (assuming that a piece exists on the source tile)
                    destinationTile.SetPiece(sourceTile.Piece);
                    sourceTile.ClearPiece();
                    var newKing = new King(Color) { Id = Id };
                    // Check if the king is still in check after the move
                    if (!newKing.IsChecked(tempBoard))
                    {
                        // The king can be saved by blocking or capturing the attacking piece
                        return false;
                    }
                }
            }

            // The king is in checkmate
            return true;
        }

        public bool IsStalemate(IBoard board)
        {
            // Get the current tile of the king
            var kingTile = board.Squares.FirstOrDefault(x => x.IsOccupied && x.Piece?.Id == Id);

            if (kingTile == null)
            {
                // King not found on the board
                return false;
            }

            // Check if the king is in check
            if (IsChecked(board))
            {
                // The king is in check, not stalemate
                return false;
            }

            // Check if the king has any valid moves
            var kingMoves = GetPossibleMoves(board);

            if (kingMoves.Any())
            {
                // The king has at least one valid move, not stalemate
                return false;
            }

            // Check if any friendly pieces have valid moves
            foreach (var tile in board.Squares.Where(x => x.IsOccupied && x.Piece?.Color == Color))
            {
                var friendlyPiece = tile.Piece;
                var friendlyMoves = friendlyPiece?.GetPossibleMoves(board);

                if (friendlyMoves?.Any() == true)
                {
                    // At least one friendly piece has a valid move, not stalemate
                    return false;
                }
            }

            // Stalemate: No legal moves for the player, and the king is not in check
            return true;
        }
    }

}
