using ZeroToHero.Interfaces.Chess.Models;

namespace ZeroToHero.Interfaces.Chess.Services.Interfaces
{
    public interface IChessPiece
    {
        Guid Id { get; set; } 
        bool HasMoved { get; set; } 
        bool IsAlive { get; set; }
        ChessPieceColor Color { get; set; }
        ChessPieceType Type { get; }
        List<AvailableMove> GetPossibleMoves(IBoard board);
        public string ImagePath { get; }
    }
    
}
