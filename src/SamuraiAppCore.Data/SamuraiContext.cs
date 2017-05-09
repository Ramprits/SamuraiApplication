using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamuraiAppCore.Domain.Model;

namespace SamuraiAppCore.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Talk> Talks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Camp>()
         .Property(c => c.Moniker)
         .IsRequired();
            builder.Entity<Camp>()
              .Property(c => c.RowVersion)
              .ValueGeneratedOnAddOrUpdate()
              .IsConcurrencyToken();
            builder.Entity<Speaker>()
              .Property(c => c.RowVersion)
              .ValueGeneratedOnAddOrUpdate()
              .IsConcurrencyToken();
            builder.Entity<Talk>()
              .Property(c => c.RowVersion)
              .ValueGeneratedOnAddOrUpdate()
              .IsConcurrencyToken();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = .; Database = SamuraiData; Trusted_Connection = True; ");
        }
    }
}