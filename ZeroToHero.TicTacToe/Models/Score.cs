namespace ZeroToHero.TicTacToe.Models
{
    public class Score
    {
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int Draws { get; private set; }
        public Score()
        {
            Reset();
        }
        public void IncrementWins()
        {
            Wins++;
        }
        public void IncrementLosses()
        {
            Losses++;
        }
        public void IncrementDraws()
        {
            Draws++;
        }
        public void Reset()
        {
            Wins = 0;
            Losses = 0;
            Draws = 0;
        }
    }
}
