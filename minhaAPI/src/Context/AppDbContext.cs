using src.Models;
using Microsoft.EntityFrameworkCore;

namespace src.Context
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //DbSet<> mapaeia o modelos das tabelas do BD
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}