using Microsoft.EntityFrameworkCore;
using BookTrackerApp.Models;

namespace BookTrackerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}