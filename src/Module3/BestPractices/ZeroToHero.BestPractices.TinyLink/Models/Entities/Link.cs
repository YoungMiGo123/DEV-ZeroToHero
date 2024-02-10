namespace ZeroToHero.BestPractices.TinyLink.Models.Entities
{
    public class Link : Entity
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string Hash { get; set; }
       
    }
}
