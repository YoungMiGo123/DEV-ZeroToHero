using BooksApi.Features.Books.Dtos;
using MediatR;

namespace BooksApi.Features.Books.Queries
{
    public class  BooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }
}
