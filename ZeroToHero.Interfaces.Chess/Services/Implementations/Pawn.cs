using System.Globalization;
using ZeroToHero.Interfaces.Chess.Models;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Services.Implementations
{
    public class Pawn(ChessPieceColor color) : IChessPiece
    {
        private List<AvailableMove> _availableMoves = [];
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsAlive { get; set; } = true;
        public ChessPieceColor Color { get; set; } = color;
        public ChessPieceType Type => ChessPieceType.Pawn;
        public string ImagePath => $"images/{Color.ToString().ToLower()}{Type}.png";

        public bool HasMoved { get; set; }

        public List<AvailableMove> GetPossibleMoves(IBoard board)
        {
            _availableMoves.Clear();

            // Get the current tile of the pawn
            var currentTile = board.Squares.FirstOrDefault(x => x.IsOccupied && x.Piece?.Id == Id);

            if (currentTile is null)
            {
                // Pawn not found on the board
                return _availableMoves;
            }
            // Get the direction of the pawn based on its color
            var direction = (Color == ChessPieceColor.White) ? new Direction(0, 1) : new Direction(0, -1);

            // Check the square in front of the pawn
            string frontPosition = CalculatePosition(currentTile!.Position!, direction);

            if (IsMoveValid(board, frontPosition))
            {
                _availableMoves.Add(new AvailableMove(frontPosition, MoveType.Regular));

                // Check two squares ahead if the pawn hasn't moved yet
                if (!HasMoved)
                {
                    // Check the square two squares ahead of the pawn
                    string doubleMovePosition = CalculatePosition(currentTile.Position, new Direction(0, 2 * direction.RankChange));
                    if (IsMoveValid(board, doubleMovePosition))
                    {
                        _availableMoves.Add(new AvailableMove(doubleMovePosition, MoveType.Regular));
                    }
                }
            }

            // Check diagonal squares for possible captures 
            // Check the square to the left of the pawn
            CheckCaptureMove(board, CalculatePosition(currentTile.Position, new Direction(-1, direction.RankChange)));
            // Check the square to the right of the pawn
            CheckCaptureMove(board, CalculatePosition(currentTile.Position, new Direction(1, direction.RankChange)));

            return _availableMoves;
        }

        private void CheckCaptureMove(IBoard board, string targetPosition)
        {
            if (IsCaptureMoveValid(board, targetPosition))
            {
                _availableMoves.Add(new AvailableMove(targetPosition, MoveType.Capture));
            }
        }

        private bool IsMoveValid(IBoard board, string targetPosition)
        {
            var targetTile = board.GetTile(targetPosition);

            if (targetTile == null)
            {
                return false;
            }

            return !targetTile.IsOccupied;
        }

        private bool IsCaptureMoveValid(IBoard board, string targetPosition)
        {
            var targetTile = board.GetTile(targetPosition);

            if (targetTile is null || targetTile.Piece is null)
            {
                return false;
            }

            return targetTile.IsOccupied && targetTile.Piece?.Color != Color;
        }

        private string CalculatePosition(string currentPosition, Direction direction)
        {
            char newFile = (char)(currentPosition[0] + direction.FileChange);
            int newRank = int.Parse($"{currentPosition[1]}", CultureInfo.InvariantCulture) + direction.RankChange;

            return $"{newFile}{newRank}";
        }
    }

}
