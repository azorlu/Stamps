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

        public async Task<QueryResult<Stamp>> GetStampsAsync(StampQuery queryObj)
        {
            var result = new QueryResult<Stamp>();

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

            // ToDo :: needs refactoring
            var columnsMap = new Dictionary<string, Expression<Func<Stamp, object>>>()
            {
                ["continent"] = v => v.Country.Continent.Name,
                ["country"] = v => v.Country.Name,
                ["category"] = v => v.Category.Name,
                ["title"] = v => v.Title
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;

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