namespace ZeroToHero.BestPractices.TinyLink.Models.Entities
{
    public class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDateTime { get; set; } = DateTime.UtcNow;
        public bool Deactivated { get; set; }   
    }
}
