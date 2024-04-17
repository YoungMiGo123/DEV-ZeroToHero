using BooksApi.Features.Books.Commands;
using FluentValidation;

namespace BooksApi.Features.Books.Validators
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);

            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);

            RuleFor(x => x.Genre)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(1024);

            RuleFor(x => x.CoverImage)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PublishedDate)
                .NotEmpty()
                .WithMessage("Published date is required");
        }
    }
}
