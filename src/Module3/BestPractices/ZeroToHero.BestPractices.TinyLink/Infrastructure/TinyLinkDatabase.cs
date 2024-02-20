using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Infrastructure
{

    public class TinyLinkDatabase : DbContext 
    {
        public TinyLinkDatabase() {  }
        public TinyLinkDatabase(DbContextOptions<TinyLinkDatabase> options) : base(options) { }

        public DbSet<Link> TinyLinks { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>()
                .HasIndex(l => l.Hash)
                .IsUnique();
        }
    }
    
}
