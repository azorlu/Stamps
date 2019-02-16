using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamps.Controllers.Resources;
using Stamps.Models;
using Stamps.Persistence;

namespace Stamps.Controllers
{

    public class ContinentsController : Controller
    {
        private readonly StampsDbContext context;
        private readonly IMapper mapper;
        public ContinentsController(StampsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/continents")]
        public async Task<IEnumerable<ContinentResource>> GetContinentsAsync() {
            var continents = await context.Continents.Include(c => c.Countries).ToListAsync();

            return mapper.Map<List<Continent>, List<ContinentResource>>(continents);
        }
    }
}