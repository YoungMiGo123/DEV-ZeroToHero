using BooksApi.Features.Books.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Features.Books.Queries
{
    public class BookQuery : IRequest<BookDto>
    {
        [FromQuery]
        public Guid Id { get; set; }
    }
}
