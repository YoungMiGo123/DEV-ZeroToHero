using BooksApi.Core.Models;

namespace BooksApi.Core.Utility
{
    public interface IAppDbContextInitializer
    {
        Task SeedDatabase();
    }
}