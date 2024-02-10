namespace ZeroToHero.BestPractices.TinyLink.Models.Entities
{

    public class Visit : Entity
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public string? IPAddress { get; set; }
        public string? Device { get; set; }
        public Guid LinkId { get; set; }
        public Link Link { get; set; }
    }
}
