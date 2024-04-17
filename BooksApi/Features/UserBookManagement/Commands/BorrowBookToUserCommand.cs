using MediatR;

namespace BooksApi.Features.UserBookManagement.Commands
{
    public class BorrowBookToUserCommand : BorrowBookBaseCommand, IRequest<bool>
    {
    }
}
