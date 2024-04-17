namespace BooksApi.Core.Entities
{
    public class UserBook : Entity
    {
        public DateTime BorrowedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
