using MediatR;

namespace BooksApi.Features.Books.Commands
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
