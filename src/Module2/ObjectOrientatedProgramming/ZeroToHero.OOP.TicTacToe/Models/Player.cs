namespace ZeroToHero.TicTacToe.Models
{
    public class Player
    {
        public Player(char symbol, string name, bool isCurrentlyPlaying, int id)
        {
            Symbol = symbol;
            Name = name;
            IsCurrentlyPlaying = isCurrentlyPlaying;
            Id = id;
            Score = new Score();
        }
        public int Id { get; set; }
        public Score Score { get; set; }
        public char Symbol { get; set; } 
        public string Name { get; set; } 
        public bool IsCurrentlyPlaying { get; set; } 

        public void SetScore(Score score)
        {
            Score = score;
        }
        public void SetCurrentlyPlaying(bool isCurrentlyPlaying)
        {
            IsCurrentlyPlaying = isCurrentlyPlaying;
        }
        public void AddWin()
        {
            Score.IncrementWins();
        }
        public void AddDraw()
        {
            Score.IncrementDraws();
        }
        public void AddLoss()
        {
            Score.IncrementLosses();
        }
        public void ResetScore()
        {
            Score.Reset();
        }
        
    }
}
