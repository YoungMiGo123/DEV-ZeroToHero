using AutoMapper;
using BooksApi.Features.Books.Dtos;
using BooksApi.Features.Books.Queries;
using BooksApi.Infrastructure.Repositories;
using MediatR;

namespace BooksApi.Features.Books.QueryHandlers
{

    public class BookQueryHandler(IBookRepository bookRepository, IMapper mapper) :
        IRequestHandler<BookQuery, BookDto>
    {
        public async Task<BookDto> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetByIdAsync(request.Id);
            return mapper.Map<BookDto>(book);
        }
    }
}
