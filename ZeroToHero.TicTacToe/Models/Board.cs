namespace ZeroToHero.TicTacToe.Models
{
    public class Square 
    {
        public char Symbol { get; set; } 
        public Square()
        {
            Symbol = '\0';
        }
        public bool IsTaken()
        {
            return Symbol != '\0';
        }
        public void SetSquare(char symbol)
        {
            Symbol = symbol;
        }
    }

    public class Board
    {
        public Square[,] Squares { get; set; }
        public int Rows => 3;
        public int Cols => 3;
        public Board()
        {
            Squares = new Square[Rows,Cols];
            InitializeBoard();  
        }
        private void InitializeBoard()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Squares[i, j] = new Square();
                }
            }
        }
        public bool IsFull()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (Squares[i, j].IsTaken())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsSquareTaken(int row, int col)
        {
            return Squares[row, col].IsTaken();
        }
        public void SetSquare(TicTacToeModel ticTacToeModel)
        {
            if (!IsSquareTaken(ticTacToeModel.Row, ticTacToeModel.Col))
            {
                Squares[ticTacToeModel.Row, ticTacToeModel.Col].SetSquare(ticTacToeModel.Symbol);
            }
         
        }
    }
}
