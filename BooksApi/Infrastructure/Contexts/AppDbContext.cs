using BooksApi.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BooksApi.Infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<BookStatistic> BookStatistics { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .HasQueryFilter(b => !b.IsDeleted);

            builder.Entity<User>()
              .HasQueryFilter(b => !b.IsDeleted);

            builder.Entity<UserBook>()
                .HasQueryFilter(b => !b.IsDeleted);

            builder.Entity<BookStatistic>()
                .HasQueryFilter(b => !b.IsDeleted);

            builder
                .Entity<Book>()
                .Property(d => d.BookCondition)
                .HasConversion<string>();
        }

    }
}
