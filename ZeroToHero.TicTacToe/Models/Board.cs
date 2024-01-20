
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
        public bool IsWinningMove(char symbol)
        {
            return IsWinningRow(symbol) || IsWinningCol(symbol) || IsWinningDiagonal(symbol);
        }

        private bool IsWinningDiagonal(char symbol)
        {
            for(int row = 0; row < Rows; row++)
            {
                if (Squares[row, row].Symbol != symbol)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsWinningCol(char symbol)
        {
            for(int row = 0; row < Rows; row++)
            {
                var isWinningCol = true;
                for(int col = 0; col < Cols; col++)
                {
                    if (Squares[col, row].Symbol != symbol)
                    {
                        isWinningCol = false;
                        break;
                    }
                }
                if (isWinningCol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsWinningRow(char symbol)
        {
            for(int row = 0; row < Rows; row++)
            {
                var isWinningRow = true;
                for(int col = 0; col < Cols; col++)
                {
                    if (Squares[row, col].Symbol != symbol)
                    {
                        isWinningRow = false;
                        break;
                    }
                }
                if (isWinningRow)
                {
                    return true;
                }
            }
            return false;
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
