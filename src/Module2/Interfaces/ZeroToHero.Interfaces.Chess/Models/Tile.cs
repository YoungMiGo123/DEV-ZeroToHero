using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public class Tile
    {
        public string Position { get; set; }
        public IChessPiece? Piece { get; set; }
        public bool IsDark { get; set; }
        public bool IsOccupied => Piece != null;
        public bool IsOccupiedBy(ChessPieceColor color) => IsOccupied && Piece?.Color == color;
        public bool IsSelected { get; set; }
        public Tile(string position)
        {
            Position = position;
        }
        public Tile(string position, IChessPiece chessPiece) 
        {
            Position = position;
            Piece = chessPiece;
        }
        public Tile(string position, IChessPiece chessPiece, bool isDark)
        {
            Position = position;
            Piece = chessPiece;
            IsDark = isDark;
        }

        public void SetPiece(IChessPiece chessPiece)
        {
            Piece = chessPiece;
        }
        public void ClearPiece()
        {
            SetPiece(null); 
        }
       

    }
}
