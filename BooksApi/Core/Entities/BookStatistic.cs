namespace BooksApi.Core.Entities
{
    public class BookStatistic : Entity
    {
        public Guid BookId { get; set; }
        public int BorrowedCount { get; set; }
        public double AverageDaysBorrowed { get; set; }
    }
}
