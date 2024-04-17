namespace BooksApi.Features.UserBookManagement.Commands
{
    public class BorrowBookBaseCommand
    {
        public Guid BookId { get; set; }
        public string UserId { get; set; }
    }
}
