using BooksApi.Core.Entities;
using BooksApi.Features.UserBookManagement.Commands;
using BooksApi.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Features.UserBookManagement.CommandHandlers
{
    public class ReturnBookFromUserCommandHandler(
         IBookRepository _bookRepository,
         IUserBookRepository _userBookRepository,
         UserManager<User> _userManager,
         IValidator<ReturnBookFromUserCommand> _validator,
         IBookStatisticRepository _bookStaticRepository 
    ) : IRequestHandler<ReturnBookFromUserCommand, bool>
    {
        private int TotalBorrowedCountToQualifyAsPopularBook = 3;
        public async Task<bool> Handle(ReturnBookFromUserCommand request, CancellationToken cancellationToken)
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

            var userBook = await _userBookRepository.GetUserBookByBookIdAndUserIdAsync(book.Id, user.Id) ??
                throw new ArgumentException($"{nameof(UserBook)} with UserId {user.Id} and BookId {book.Id} not found");

            userBook.ReturnedAt = DateTime.UtcNow;
            var returnedSuccessfully = await _userBookRepository.UpdateAsync(userBook);

            if (returnedSuccessfully)
            {
                book.IsLoanedOut = false;
                book.BookCondition = request.BookCondition;
                await _bookRepository.UpdateAsync(book);
            }

            var hasBeenReturned = returnedSuccessfully && !book.IsLoanedOut;
            var hasAddedBookStatistics = await RecordBookStatistics(book, userBook);

            return hasBeenReturned && hasAddedBookStatistics;
        }

        private async Task<bool> RecordBookStatistics(Book book, UserBook userBook)
        {
            var hasAddedBookStatistics = false;
            var bookStatistic = await _bookStaticRepository.GetAll().FirstOrDefaultAsync(x => x.BookId == book.Id);

            if (bookStatistic is null)
            {
                bookStatistic = new BookStatistic
                {
                    BookId = book.Id,
                    BorrowedCount = 1,
                    AverageDaysBorrowed = (userBook.ReturnedAt - userBook.BorrowedAt).Value.TotalDays
                };
                var createdNewStats = await _bookStaticRepository.CreateAsync(bookStatistic);
                hasAddedBookStatistics = createdNewStats is not null;
            }
            else
            {
                bookStatistic.BorrowedCount++;
                bookStatistic.AverageDaysBorrowed = _userBookRepository
                    .GetAll()
                    .Where(x => x.BookId == book.Id && x.ReturnedAt != null)
                    .Select(x => (x.ReturnedAt - x.BorrowedAt).Value.TotalDays)
                    .Average();

                var updatedStatistics = await _bookStaticRepository.UpdateAsync(bookStatistic);
                hasAddedBookStatistics = updatedStatistics;
            }

            if(bookStatistic.BorrowedCount >= TotalBorrowedCountToQualifyAsPopularBook)
            {
                book.IsPopular = true;
                await _bookRepository.UpdateAsync(book);
            }

            return hasAddedBookStatistics;
        }
    }
}
