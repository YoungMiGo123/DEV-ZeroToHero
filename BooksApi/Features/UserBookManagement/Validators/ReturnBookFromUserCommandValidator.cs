using BooksApi.Features.UserBookManagement.Commands;
using FluentValidation;

namespace BooksApi.Features.UserBookManagement.Validators
{
    public class ReturnBookFromUserCommandValidator : AbstractValidator<ReturnBookFromUserCommand>
    {
        public ReturnBookFromUserCommandValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.BookCondition)
                .IsInEnum();    
        }
    }
}
