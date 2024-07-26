using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Model.Configurations;
using Projekt.Model.Entities;

namespace Projekt.Model
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; } 
        public DbSet<Publisher> Publishers { get; set; }


        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
