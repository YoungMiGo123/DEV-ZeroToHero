using BooksApi.Features.Books.Queries;
using FluentValidation;

namespace BooksApi.Features.Books.Validators
{
    public class BookSearchQueryValidator : AbstractValidator<BookSearchQuery>
    {
        public BookSearchQueryValidator()
        {
            RuleFor(x => x.SearchQuery)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);
        }
    }
}
