using System.Globalization;
using ZeroToHero.Interfaces.Chess.Models;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Services.Implementations
{
    public class Bishop(ChessPieceColor color) : IBishop
    {
        private List<AvailableMove> _availableMoves = [];
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsAlive { get; set; } = true;
        public ChessPieceColor Color { get; set; } = color;
        public ChessPieceType Type => ChessPieceType.Bishop;

        public BishopType BishopType { get; set; }

        public string ImagePath => $"images/{Color.ToString().ToLower()}{Type}.png";
        public bool HasMoved { get; set; }
        public List<AvailableMove> GetPossibleMoves(IBoard board)
        {
            _availableMoves.Clear();

            // Get the current tile of the bishop
            var currentTile = board.Squares.FirstOrDefault(x => x.IsOccupied && x.Piece?.Id == Id);

            if (currentTile == null)
            {
                return _availableMoves;
            }

            // Define the possible directions a bishop can move diagonally
            var directions = new List<Direction>
            {
                new(-1, -1), // Diagonal to the top-left
                new(-1, 1),  // Diagonal to the top-right
                new(1, -1),  // Diagonal to the bottom-left
                new(1, 1)    // Diagonal to the bottom-right
            };

            // Check possible moves in each direction
            foreach (var direction in directions)
            {
                AvailableMovesHelper.CheckDiagonalMoves(board, currentTile, direction, _availableMoves, Color);
            }

            return _availableMoves;
        }

       
    }

}
