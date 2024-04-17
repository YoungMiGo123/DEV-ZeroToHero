namespace BooksApi.Core.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;
        public Guid? CreatedBy { get; set; } = Guid.Empty;
        public Guid? ModifiedBy { get; set; } = Guid.Empty;
    }
}
