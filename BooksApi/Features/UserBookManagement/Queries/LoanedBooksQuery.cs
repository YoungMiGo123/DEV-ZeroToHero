using BooksApi.Features.Books.Dtos;
using MediatR;

namespace BooksApi.Features.UserBookManagement.Queries
{
    public class LoanedBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }
}
