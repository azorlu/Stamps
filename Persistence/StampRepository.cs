using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Core;
using Stamps.Core.Models;
using Stamps.Extensions;

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

        public async Task<IEnumerable<Stamp>> GetStampsAsync(StampQuery queryObj)
        {
            var query = context.Stamps
                .Include(s => s.Country)
                  .ThenInclude(c => c.Continent)
                .Include(s => s.Category)
                .AsQueryable();

            if (queryObj.ContinentId.HasValue)
            {
                query = query.Where(s => s.Country.ContinentId == queryObj.ContinentId.Value);
            }

            if (queryObj.CountryId.HasValue)
            {
                query = query.Where(s => s.Country.Id == queryObj.CountryId.Value);
            }

            var columnsMap = new Dictionary<string, Expression<Func<Stamp, object>>>()
            {
                ["continent"] = v => v.Country.Continent.Name,
                ["country"] = v => v.Country.Name,
                ["title"] = v => v.Title
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

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