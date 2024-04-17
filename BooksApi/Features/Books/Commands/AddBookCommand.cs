using MediatR;

namespace BooksApi.Features.Books.Commands
{
    public class AddBookCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
