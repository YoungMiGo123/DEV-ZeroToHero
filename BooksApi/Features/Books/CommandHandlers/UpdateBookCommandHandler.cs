using BooksApi.Features.Books.Commands;
using BooksApi.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace BooksApi.Features.Books.CommandHandlers
{
    public class UpdateBookCommandHandler
    (
       IBookRepository bookRepository,
       IValidator<UpdateBookCommand> validator
    ) : IRequestHandler<UpdateBookCommand, bool>
    {
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid is false)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var book = await bookRepository.GetByIdAsync(request.Id);
            book.Author = request.Author;
            book.Title = request.Title;
            book.Genre = request.Genre;
            book.Description = request.Description;
            book.CoverImage = request.CoverImage;
            book.PublishedDate = request.PublishedDate;
            book.UpdatedDateTime = DateTime.UtcNow;
            
            

            var response = await bookRepository.UpdateAsync(book);

            return response;
        }
    }
}
