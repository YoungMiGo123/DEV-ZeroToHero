using AutoMapper;
using BooksApi.Features.Books.Dtos;
using BooksApi.Features.Books.Queries;
using BooksApi.Infrastructure.Repositories;
using MediatR;

namespace BooksApi.Features.Books.QueryHandlers
{
    public class BooksQueryHandler(IBookRepository bookRepository, IMapper mapper) :
        IRequestHandler<BooksQuery, IEnumerable<BookDto>>
    {
        public async Task<IEnumerable<BookDto>> Handle(BooksQuery request, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetAllAsync();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
