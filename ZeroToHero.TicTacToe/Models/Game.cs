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
            return GetWinner() is not null || IsDraw();
        }
        public bool IsDraw()
        {
            var currentPlayer = _players.First(player => player.IsCurrentlyPlaying);
            return !_board.IsWinningMove(currentPlayer.Symbol) && _board.IsFull();
        }

        public Player? GetWinner()
        {
            var currentPlayer = _players.First(player => player.IsCurrentlyPlaying);
            var isWinningMove = _board.IsWinningMove(currentPlayer.Symbol);
            return isWinningMove ? currentPlayer : null;
        }
        public Player? GetLoser()
        {
            var winner = GetWinner();
            if(winner is not null)
            {
                return _players.First(player => player.Id != winner.Id);
            }
            return null;
        }
        public Board Board => _board;
  
        public List<Player> Players => _players;
    }
}
