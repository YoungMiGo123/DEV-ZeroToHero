using BooksApi.Features.Books.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Features.Books.Queries
{
    public class BookSearchQuery : IRequest<IEnumerable<BookDto>>
    {
        [FromQuery]
        public string? SearchQuery { get; set; }
    }
}
