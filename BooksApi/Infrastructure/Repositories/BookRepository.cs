using BooksApi.Core.Entities;
using BooksApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Repositories
{
    public class BookRepository(AppDbContext context) : GenericRepository<Book>(context), IBookRepository
    {
        public async Task<Book> GetBookByTitleAsync(string title)
        {
            return await context.Set<Book>().FirstOrDefaultAsync(b => b.Title == title);
        }

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await context.Set<Book>().Where(b => !b.IsLoanedOut).ToListAsync();
        }

    }
}

