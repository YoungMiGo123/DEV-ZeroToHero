using AutoMapper;
using BooksApi.Features.Books.Dtos;
using BooksApi.Features.UserBookManagement.Queries;
using BooksApi.Infrastructure.Repositories;
using MediatR;

namespace BooksApi.Features.UserBookManagement.QueryHandlers
{
    public class LoanedBooksQueryHandler(
        IBookRepository _bookRepository,
        IMapper _mapper
    ) : IRequestHandler<LoanedBooksQuery, IEnumerable<BookDto>>
    {
        public Task<IEnumerable<BookDto>> Handle(LoanedBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.GetAll().Where(x => x.IsLoanedOut);
            var mappedBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return Task.FromResult(mappedBooks);
        }
    }
}
