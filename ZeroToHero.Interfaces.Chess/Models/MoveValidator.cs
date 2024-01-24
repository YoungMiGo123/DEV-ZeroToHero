using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public class MoveValidator(IBoard _board, List<MoveResponse> moveResponses)
    {
        public (bool, string) ValidateMove(Tile from, Tile to, Player currentPlayer)
        {
            if (from?.Piece is null)
            {
                return (false, "From Piece does not have a piece. Please select Piece before moving");
            }
            var lastMove = moveResponses.LastOrDefault();
            var piece = from.Piece;

            if (lastMove?.Color == piece.Color)
            {
                return (false, "You cannot move twice in a row");
            }

            var pieceTypes = new List<ChessPieceType> { ChessPieceType.Pawn, ChessPieceType.Bishop, ChessPieceType.Rook, ChessPieceType.King, ChessPieceType.Knight };

            if (!pieceTypes.Contains(piece.Type))
            {
                return (false, "This piece does not have the implementation to check its available moves");
            }

            if (piece.Type == ChessPieceType.King && !IsValidKingMove(from, to, currentPlayer))
            {
                return (false, "You cannot move to this square, it will threaten your king");
            }
            if (from.Piece.Color != currentPlayer.Color)
            {
                return (false, "You cannot move your oppositions pieces");
            }

            if (to.IsOccupiedBy(from.Piece.Color))
            {
                return (false, "You cannot move to a tile occupied by your own piece");
            }

            var availableMoves = piece.GetPossibleMoves(_board);

            var canMove = availableMoves.Any(x => x.DestinationPosition == to.Position);

            return (canMove, canMove ? "" : "This piece cannot move to this tile");
        }

        private bool IsValidKingMove(Tile from, Tile to, Player CurrentPlayer)
        {
            var oppositionColor = CurrentPlayer.Color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;
            if(_board.IsTileControlledBy(to.Position, oppositionColor))
            {
                return false;
            }
            return true;
        }
    }
}
