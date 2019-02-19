using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Core;
using Stamps.Core.Models;

namespace Stamps.Persistence
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly StampsDbContext context;

        public ContinentRepository(StampsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Continent>> GetContinentsAsync()
        {
            return await context.Continents.Include(c => c.Countries).ToListAsync();
        }
    }
}