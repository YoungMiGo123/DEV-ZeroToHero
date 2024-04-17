namespace BooksApi.Features.Books.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsLoanedOut { get; set; }
        public bool IsPopular { get; set; }
    }
}
