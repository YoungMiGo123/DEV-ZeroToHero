using BooksApi.Core.Entities;
using BooksApi.Features.UserBookManagement.Commands;
using FluentValidation;

namespace BooksApi.Features.UserBookManagement.Validators
{
    public class BorrowBookToUserCommandValidator : AbstractValidator<BorrowBookToUserCommand>
    {
        public BorrowBookToUserCommandValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
        }
    }
}
