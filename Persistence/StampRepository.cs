using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Models;

namespace Stamps.Persistence
{
    public class StampRepository : IStampRepository
    {
        private readonly StampsDbContext context;

        public StampRepository(StampsDbContext context)
        {
            this.context = context;
        }
        public async Task<Stamp> GetStampAsync(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Stamps.FindAsync(id);

            return await context.Stamps
                .Include(s => s.Country)
                  .ThenInclude(c => c.Continent)
                .Include(s => s.Category)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(Stamp stamp)
        {
            context.Stamps.Add(stamp);
        }

        public void Remove(Stamp stamp)
        {
            context.Stamps.Remove(stamp);
        }
    }
}