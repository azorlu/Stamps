using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stamps.Controllers.Resources;
using Stamps.Models;
using Stamps.Persistence;

namespace Stamps.Controllers
{
    [Route("/api/stamps")]
    public class StampsController : Controller
    {
        private readonly StampsDbContext context;
        private readonly IMapper mapper;

        public StampsController(StampsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStampAsync([FromBody] StampResource stampResource)
        {
            var stamp = mapper.Map<StampResource, Stamp>(stampResource);
            stamp.LastUpdate = DateTime.Now;
            
            context.Stamps.Add(stamp);
            await context.SaveChangesAsync();

            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }
    }
}