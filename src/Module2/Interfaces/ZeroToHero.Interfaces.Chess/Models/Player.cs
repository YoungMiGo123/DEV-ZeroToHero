namespace ZeroToHero.Interfaces.Chess.Models
{
    public class Player
    {
        public int Id { get; set; }
        public Score Score { get; set; }
        public ChessPieceColor Color { get; set; }
        public string Name { get; set; }
        public bool IsCurrentlyPlaying { get; set; }
        public Player(int id, ChessPieceColor playerColor, string name, bool currentPlaying)
        {
            Id = id;
            Color = playerColor;
            Name = name;
            Score = new Score();
            IsCurrentlyPlaying = currentPlaying;
        }

        public void SetScore(Score score)
        {
            Score = score;
        }
        public void SetCurrentlyPlaying(bool isCurrentlyPlaying)
        {
            IsCurrentlyPlaying = isCurrentlyPlaying;
        }
    }
}
