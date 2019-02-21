using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Core;
using Stamps.Core.Models;

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

        public async Task<IEnumerable<Stamp>> GetStampsAsync(Filter filter)
        {
            var query = context.Stamps
                .Include(s => s.Country)
                  .ThenInclude(c => c.Continent)
                .Include(s => s.Category)
                .AsQueryable();
            
            if (filter.ContinentId.HasValue) {
                query = query.Where(s => s.Country.ContinentId == filter.ContinentId.Value);
            }
            
            return await query.ToListAsync();

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