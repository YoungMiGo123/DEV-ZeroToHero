using ZeroToHero.Interfaces.Chess.Models;

namespace ZeroToHero.Interfaces.Chess.Services.Interfaces
{
    public interface IBoard
    {
        List<Tile> Squares { get; set; }
        Tile GetTile(string position);
        void SetTile(string position, Tile tile);
        void SelectTile(string position);
        void DeselectAllTiles();
        bool IsTileControlledBy(string position, ChessPieceColor color);
        IEnumerable<Tile> GetChessPiecesByColor(ChessPieceColor color);  
        IBoard Copy();
    }
}