namespace ZeroToHero.TicTacToe.Models
{
    public class TicTacToeModel
    {
        public TicTacToeModel()
        {
                
        }
        public TicTacToeModel(int row, int col, char symbol)
        {
            Row = row;
            Col = col;
            Symbol = symbol;
        }
        public int Row { get; set; }
        public int Col { get; set; } 
        public char Symbol { get; set; }
    }
}
