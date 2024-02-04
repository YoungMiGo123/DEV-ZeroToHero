using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public class MoveRequest
    {
        public string FromPosition { get; set; }
        public string ToPosition { get; set; }
        public IChessPiece FromChessPiece { get; set; }
        public MoveType MoveType { get; set; }
        public IChessPiece ToPiece { get; set; }
    }

    public class MoveResponse
    {
        public MoveRequest MoveRequest { get; set; }
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
        public ChessPieceColor Color { get; set; }
    }
}
