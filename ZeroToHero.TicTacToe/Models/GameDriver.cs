namespace ZeroToHero.TicTacToe.Models
{
    public class GameDriver
    {
        public Game Game { get; set; }
        public List<Player> Players { get; set; } = [new('X', "Player 1", true, 1), new('O', "Player 2", false, 2)];
        public GameDriver()
        {
            Game = new Game(new Board(), Players);
        }
        public void SetSquare(TicTacToeModel ticTacToeModel)
        {
            Game.SetSquare(ticTacToeModel);
        }
        public void SwitchPlayers()
        {
            Game.SwitchPlayers();
        }
        public void ResetGame()
        {
            if (!Game.IsDraw())
            {

               var winner = Game.GetWinner();
               winner.AddWin();

               var loser = Players.First(player => player.Id != winner.Id);
               loser.AddLoss();

               Players = new List<Player> { winner, loser };    
            }
            else
            {
                Game.Players.ForEach(player => player.AddDraw());
            }

            Game = new Game(new Board(), Players);
        }
        public bool IsGameOver()
        {
            return Game.IsGameOver();
        }
        public Player GetWinner()
        {
            return Game.GetWinner();
        }
        public int Rows => Game.Board.Rows;
        public int Cols => Game.Board.Cols;
        public bool IsSquareTaken(int row, int col)
        {
            return Game.Board.IsSquareTaken(row, col);
        }
        public Square GetSquare(int row, int col)
        {
            return Game.Board.Squares[row, col];
        }
        public Player CurrentPlayer => Game.Players.First(player => player.IsCurrentlyPlaying);
    }
}
