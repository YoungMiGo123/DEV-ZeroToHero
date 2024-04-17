using BooksApi.Core.Entities;

namespace BooksApi.Infrastructure.Repositories
{
    public interface IUserBookRepository : IGenericRepository<UserBook>
    {
        Task<UserBook> GetUserBookByBookIdAndUserIdAsync(Guid bookId, string userId);
        Task<IEnumerable<UserBook>> GetBorrowedBooksByUserIdAsync(string userId);
    }
}

