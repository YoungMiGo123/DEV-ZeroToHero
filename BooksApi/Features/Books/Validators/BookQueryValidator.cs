using BooksApi.Features.Books.Queries;
using FluentValidation;

namespace BooksApi.Features.Books.Validators
{
    public class BookQueryValidator : AbstractValidator<BookQuery>
    {
        public BookQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
