using ZeroToHero.Interfaces.Chess.Models;

namespace ZeroToHero.Interfaces.Chess.Services.Interfaces
{
    public interface IBishop : IChessPiece
    {
        BishopType BishopType { get; set; }
    }
    
}
