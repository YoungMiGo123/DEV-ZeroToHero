using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public class GameManager
    {
        public Game Game { get; set; }
        public GameManager()
        {
            Game = new Game();
        }

        public void SwitchPlayer()
        {
            Game.SwitchPlayers();
        }
        public Player CurrentPlayer => Game.CurrentPlayer;
        public Player Opposition => Game.Opposition;
        public IBoard Board => Game.Board;
        public MoveResponse MovePiece(string toPosition)
        {
            var source = Game.Board.Squares.FirstOrDefault(x => x.IsSelected);
            var destination = Game.Board.Squares.FirstOrDefault(x => x.Position == toPosition);

            var moveType = destination?.Piece != null ? MoveType.Capture : MoveType.Regular;
            var moveRequest = new MoveRequest
            {
                FromPosition = source?.Position ?? string.Empty,
                ToPosition = toPosition,
                FromChessPiece = source?.Piece!,
                MoveType = moveType,
                ToPiece = destination?.Piece!
            };
            var moveResponse = Game.MovePiece(moveRequest);

            return moveResponse;
        }

        public bool UndoMove()
        {
            return Game.UndoMove();
        }
        public void ResetGame()
        {
            Game.ResetGame();
        }   

        public bool IsGameOver()
        {
            return Game.IsGameOver;
        }

        public void UpdateScores()
        {
            Game.UpdateScores();
        }

        public Player GetWinner()
        {
            return Game.GetWinner();
        }
    }
}
