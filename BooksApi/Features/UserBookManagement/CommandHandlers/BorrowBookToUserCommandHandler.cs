using BooksApi.Core.Entities;
using BooksApi.Features.UserBookManagement.Commands;
using BooksApi.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BooksApi.Features.UserBookManagement.CommandHandlers
{
    public class BorrowBookToUserCommandHandler(
        IBookRepository _bookRepository,
        IUserBookRepository _userBookRepository,
        UserManager<User> _userManager,
        IValidator<BorrowBookToUserCommand> _validator
    ) : IRequestHandler<BorrowBookToUserCommand, bool>
    {
        public async Task<bool> Handle(BorrowBookToUserCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid is false)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _userManager.FindByIdAsync(request.UserId) ??
                throw new ArgumentException($"{nameof(User)} with Id {request.UserId} not found");

            var book = await _bookRepository.GetByIdAsync(request.BookId) ??
                 throw new ArgumentException($"{nameof(Book)} with Id {request.BookId} not found");

            var userBook = new UserBook
            {
                BookId = book.Id,
                UserId = user.Id,
                BorrowedAt = DateTime.UtcNow
            };

            var response = await _userBookRepository.CreateAsync(userBook);

            if(response is not null)
            {
                book.IsLoanedOut = true;
                await _bookRepository.UpdateAsync(book);
            }

            return response is not null && book.IsLoanedOut;
        }
    }
}
