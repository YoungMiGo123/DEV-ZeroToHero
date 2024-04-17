using BooksApi.Core.Entities;
using BooksApi.Core.Models;
using BooksApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace BooksApi.Core.Utility
{
    public class AppDbContextInitializer(IWebHostEnvironment _webHostEnvironment, AppDbContext _context) : IAppDbContextInitializer
    {
        public async Task SeedDatabase()
        {
            _context.Database.Migrate();

            if (!_context.Books.Any())
            {
                var bookSeedModels = GetBookSeedModels();
                var books = bookSeedModels.Select(x => new Book
                {
                    Author = x.Author ?? string.Empty,
                    CoverImage = x.CoverImage ?? string.Empty,
                    Description = x.Description ?? string.Empty,
                    Genre = string.Join(",", x.Genre) ?? string.Empty,
                    PublishedDate = 
                    int.TryParse(x.PublicationYear, CultureInfo.InvariantCulture, out var result) ? 
                    new DateTime(Convert.ToInt32(x.PublicationYear,CultureInfo.InvariantCulture), 1, 1) : 
                    new DateTime(1980, 1, 1),
                    Title = x.Title ?? string.Empty,
                });

                await _context.Books.AddRangeAsync(books);
                _context.SaveChanges();
            }
        }
        private List<BookSeedModel> GetBookSeedModels()
        {
            var pathToFile = @$"{_webHostEnvironment.WebRootPath}\SeedData\books_Seed_Data.json";
            var data = JsonConvert.DeserializeObject<List<BookSeedModel>>(File.ReadAllText(pathToFile));
            return data;
        }
    }
}
