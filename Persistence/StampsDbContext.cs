using Microsoft.EntityFrameworkCore;

namespace Stamps.Persistence
{
    public class StampsDbContext : DbContext
    {
        public StampsDbContext(DbContextOptions<StampsDbContext> options)
        : base(options)
        {
            
        }
    }
}