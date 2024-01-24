using ZeroToHero.Interfaces.Chess.Models;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Services.Implementations
{
    public class Queen(ChessPieceColor color) : IChessPiece
    {
        private List<AvailableMove> _availableMoves = [];
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsAlive { get; set; } = true;
        public ChessPieceColor Color { get; set; } = color;
        public ChessPieceType Type => ChessPieceType.Queen;
        public string ImagePath => $"images/{Color.ToString().ToLower()}{Type}.png";
        public bool HasMoved { get; set; }

        public List<AvailableMove> GetPossibleMoves(IBoard board)
        {
            return [];
        }
    }

}
