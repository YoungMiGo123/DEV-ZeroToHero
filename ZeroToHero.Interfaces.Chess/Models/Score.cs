namespace ZeroToHero.Interfaces.Chess.Models
{
    public class Score
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public Score()
        {
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
