using BooksApi.Features.Books.Commands;
using BooksApi.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Features.Books
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookManagementController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        [Route("Book")]
        public async Task<IActionResult> Book(BookQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("Books")]
        public async Task<IActionResult> Books()
        {
            var query = new BooksQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("QueryBooks")]
        public async Task<IActionResult> QueryBooks(BookSearchQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result);
        }


        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBook(AddBookCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook(DeleteBookCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }
    }
}
