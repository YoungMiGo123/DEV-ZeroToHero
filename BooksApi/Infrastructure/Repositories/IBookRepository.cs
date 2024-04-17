using BooksApi.Core.Entities;

namespace BooksApi.Infrastructure.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetBookByTitleAsync(string title);
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
    }
}

