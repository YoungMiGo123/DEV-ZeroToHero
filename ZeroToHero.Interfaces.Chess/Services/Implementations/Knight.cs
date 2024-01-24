using System.Globalization;
using ZeroToHero.Interfaces.Chess.Models;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Services.Implementations
{
    public class Knight(ChessPieceColor color) : IChessPiece
    {
        private List<AvailableMove> _availableMoves = [];
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsAlive { get; set; } = true;
        public ChessPieceColor Color { get; set; } = color;
        public ChessPieceType Type => ChessPieceType.Knight;
        public string ImagePath => $"images/{Color.ToString().ToLower()}{Type}.png";
        public bool HasMoved { get; set; }
        public List<AvailableMove> GetPossibleMoves(IBoard board)
        {
            _availableMoves.Clear();

            // Get the current tile of the knight
            var currentTile = board.Squares.FirstOrDefault(x => x.IsOccupied && x.Piece?.Id == Id);

            if (currentTile == null)
            {
                // Knight not found on the board
                return _availableMoves;
            }

            // Define the possible L-shaped moves for a knight using Direction
            var moves = new List<Direction>
            {
                new(2, 1),  // Two squares up, one square right
                new(2, -1), // Two squares up, one square left
                new(-2, 1), // Two squares down, one square right
                new(-2, -1),// Two squares down, one square left
                new(1, 2),  // Two squares right, one square up
                new(-1, 2), // Two squares left, one square up
                new(1, -2), // Two squares right, one square down
                new(-1, -2) // Two squares left, one square down
            };

            // Check possible moves
            foreach (var move in moves)
            {
                int newFile = currentTile.Position[0] + move.FileChange;
                int newRank = int.Parse($"{currentTile.Position[1]}", CultureInfo.InvariantCulture) + move.RankChange;
                var opponentColor = Color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;

                if (AvailableMovesHelper.IsMoveValid(board, newFile, newRank, opponentColor))
                {
                    string newPosition = $"{(char)newFile}{newRank}";
                    _availableMoves.Add(new AvailableMove(newPosition, MoveType.Regular));
                }
            }

            return _availableMoves;
        }

    }

}
