using Microsoft.EntityFrameworkCore;
using Stamps.Models;

namespace Stamps.Persistence
{
    public class StampsDbContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
        // Adding Country DbSet is not necessary

        public DbSet<Category> Categories { get; set; }

        public DbSet<Stamp> Stamps { get; set; }

        public StampsDbContext(DbContextOptions<StampsDbContext> options)
        : base(options)
        {
            
        }
    }
}