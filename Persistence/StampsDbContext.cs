using Microsoft.EntityFrameworkCore;
using Stamps.Core.Models;

namespace Stamps.Persistence
{
    public class StampsDbContext : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
        
        public DbSet<Country> Countries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public StampsDbContext(DbContextOptions<StampsDbContext> options)
        : base(options)
        {
            
        }
    }
}