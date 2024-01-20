namespace ZeroToHero.TicTacToe.Models
{
    public class Game
    {
        private readonly Board _board;
        private readonly List<Player> _players;
        public Game(Board board, List<Player> players)
        {
            _board = board;
            _players = players;
        }
        public Game()
        {
            _board = new Board();

            _players = [
                new Player('X', "Player 1", true, 1),
                new Player('O', "Player 2", false, 2)
            ];
        }
        public void SetSquare(TicTacToeModel ticTacToeModel)
        {
            Board.SetSquare(ticTacToeModel);
        }
        public void SwitchPlayers()
        {
            var nextPlayer = _players.First(player => !player.IsCurrentlyPlaying);
            var currentPlayer = _players.First(player => player.IsCurrentlyPlaying);
            currentPlayer.SetCurrentlyPlaying(false);
            nextPlayer.SetCurrentlyPlaying(true);
        }
        public bool IsGameOver()
        {
            // To do: Implement this method
            return false;
        }
        public bool IsDraw()
        {
            // To do: Implement this method
            return false;
        }

        public Player GetWinner()
        {
            // To do: Implement this method
            return null;
        }
        public Player GetLoser()
        {
            // To do: Implement this method
            return null;
        }
        public Board Board => _board;
  
        public List<Player> Players => _players;
    }
}
