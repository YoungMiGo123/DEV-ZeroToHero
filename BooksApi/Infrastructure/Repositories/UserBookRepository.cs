using BooksApi.Core.Entities;
using BooksApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Repositories
{
    public class UserBookRepository(AppDbContext context) : GenericRepository<UserBook>(context), IUserBookRepository
    {
        public async Task<UserBook> GetUserBookByBookIdAndUserIdAsync(Guid bookId, string userId)
        {
            return await context.Set<UserBook>()
                .FirstOrDefaultAsync(ub => ub.BookId == bookId && ub.UserId == userId);
        }

        public async Task<IEnumerable<UserBook>> GetBorrowedBooksByUserIdAsync(string userId)
        {
            return await context.Set<UserBook>()
                .Where(ub => ub.UserId == userId && ub.ReturnedAt == null)
                .ToListAsync();
        }

    }
}

