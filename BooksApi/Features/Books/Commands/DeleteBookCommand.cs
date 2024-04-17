using MediatR;

namespace BooksApi.Features.Books.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
