using BooksApi.Core.Entities;
using MediatR;

namespace BooksApi.Features.UserBookManagement.Commands
{
    public class ReturnBookFromUserCommand : BorrowBookBaseCommand, IRequest<bool>
    {
        public BookCondition BookCondition { get; set; }
    }
}
