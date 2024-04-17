using BooksApi.Features.Books.Commands;
using BooksApi.Infrastructure.Repositories;
using MediatR;

namespace BooksApi.Features.Books.CommandHandlers
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, bool>
    {
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var response = await bookRepository.DeleteAsync(request.Id);
            return response;
        }
    }
}
