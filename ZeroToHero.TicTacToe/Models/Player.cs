namespace ZeroToHero.TicTacToe.Models
{
    public class Player(char symbol, string name, bool isCurrentlyPlaying, int id)
    {
        public int Id { get; set; } = id;
        private readonly Score _score = new();
        public char Symbol { get; set; } = symbol;
        public string Name { get; set; } = name;
        public bool IsCurrentlyPlaying { get; set; } = isCurrentlyPlaying;

       
        public void SetCurrentlyPlaying(bool isCurrentlyPlaying)
        {
            IsCurrentlyPlaying = isCurrentlyPlaying;
        }
        public void AddWin()
        {
            _score.IncrementWins();
        }
        public void AddDraw()
        {
            _score.IncrementDraws();
        }
        public void AddLoss()
        {
            _score.IncrementLosses();
        }
        public void ResetScore()
        {
            _score.Reset();
        }
        public Score Score => _score;
        
    }
}
