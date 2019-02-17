using Microsoft.EntityFrameworkCore;
using Stamps.Models;

namespace Stamps.Persistence
{
    public class StampsDbContext : DbContext
    {
        public StampsDbContext(DbContextOptions<StampsDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<Continent> Continents { get; set; }
        // Adding Country DbSet is not necessary

        public DbSet<Category> Categories { get; set; }
    }
}