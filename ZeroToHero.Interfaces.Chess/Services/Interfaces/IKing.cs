namespace ZeroToHero.Interfaces.Chess.Services.Interfaces
{
    public interface IKing : IChessPiece
    {
        public bool IsChecked(IBoard board);
        public bool IsCheckmate(IBoard board);
        public bool IsStalemate(IBoard board);
    }
}
