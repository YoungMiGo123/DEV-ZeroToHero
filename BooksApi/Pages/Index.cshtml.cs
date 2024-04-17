using BooksApi.Features.Books.Dtos;
using BooksApi.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApi.Pages
{
    public class IndexModel(ISender _sender) : PageModel
    {
        public IEnumerable<BookDto> Books { get; set; }
        public async Task OnGet()
        {
            var query = new BooksQuery();
            Books = await _sender.Send(query);
        }
    }
}
