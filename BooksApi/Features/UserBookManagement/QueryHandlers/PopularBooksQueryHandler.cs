using AutoMapper;
using BooksApi.Features.Books.Dtos;
using BooksApi.Features.UserBookManagement.Queries;
using BooksApi.Infrastructure.Repositories;
using MediatR;

namespace BooksApi.Features.UserBookManagement.QueryHandlers
{
    public class PopularBooksQueryHandler(
        IBookRepository _bookRepository,
        IMapper _mapper
    ) : IRequestHandler<PopularBooksQuery, IEnumerable<BookDto>>
    {
        public Task<IEnumerable<BookDto>> Handle(PopularBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.GetAll().Where(x => x.IsPopular);
            var mappedBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return Task.FromResult(mappedBooks);
        }
    }
}
