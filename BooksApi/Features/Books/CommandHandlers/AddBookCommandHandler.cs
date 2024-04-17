using BooksApi.Core.Entities;
using BooksApi.Features.Books.Commands;
using BooksApi.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace BooksApi.Features.Books.CommandHandlers
{
    public class AddBookCommandHandler(
        IBookRepository _bookRepository, 
        IValidator<AddBookCommand> _validator
    ) : IRequestHandler<AddBookCommand, bool>
    {
        public async Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if(validationResult.IsValid is false)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Genre = request.Genre,
                Description = request.Description,
                CoverImage = request.CoverImage,
                PublishedDate = request.PublishedDate
            };

            var response = await _bookRepository.CreateAsync(book);

            return response is not null;
        }
    }
}
