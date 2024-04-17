using BooksApi.Features.UserBookManagement.Commands;
using BooksApi.Features.UserBookManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Features.UserBookManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookManagementController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        [Route("LoanedBooks")]
        public async Task<IActionResult> LoanedBooks()
        {
            var query = new LoanedBooksQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("PopularBooks")]
        public async Task<IActionResult> PopularBooks()
        {
            var query = new PopularBooksQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("BorrowBookToUser")]
        public async Task<IActionResult> BorrowBookToUser(BorrowBookToUserCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("ReturnBookFromUser")]
        public async Task<IActionResult> ReturnBookFromUser(ReturnBookFromUserCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }
    }
}
