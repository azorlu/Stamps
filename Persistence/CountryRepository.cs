using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Core;
using Stamps.Core.Models;

namespace Stamps.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private readonly StampsDbContext context;

        public CountryRepository(StampsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await context.Countries.ToListAsync();
        }
    }
}