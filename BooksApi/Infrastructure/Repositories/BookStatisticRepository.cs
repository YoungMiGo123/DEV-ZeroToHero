using BooksApi.Core.Entities;
using BooksApi.Infrastructure.Contexts;

namespace BooksApi.Infrastructure.Repositories
{
    public class BookStatisticRepository(AppDbContext context) : GenericRepository<BookStatistic>(context), IBookStatisticRepository
    {
     
    }
}

