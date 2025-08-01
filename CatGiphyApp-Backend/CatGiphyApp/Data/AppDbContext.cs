using Microsoft.EntityFrameworkCore;
using CatGiphyApp.Models;

namespace CatGiphyApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<SearchHistory> SearchHistories { get; set; }
    }
}
