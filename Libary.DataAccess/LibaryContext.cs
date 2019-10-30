using Libary.Domain;
using Microsoft.EntityFrameworkCore;

namespace Libary.DataAccess
{
    public class LibaryContext : DbContext
    {
        private readonly string connectionString;

        public LibaryContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<BooksOnHand> BooksOnHands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
    }
}
