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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            /* var country = await context.Countries.FindAsync(stampResource.CountryId);
            if (country == null)
            {
                ModelState.AddModelError("CountryId", "Invalid CountryId.");
                return BadRequest(ModelState);
            } */

            var stamp = mapper.Map<StampResource, Stamp>(stampResource);
            stamp.LastUpdate = DateTime.Now;

            context.Stamps.Add(stamp);
            await context.SaveChangesAsync();

            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStampAsync(int id, [FromBody] StampResource stampResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stamp = await context.Stamps.FindAsync(id);
            if (stamp == null)
                return NotFound();

            mapper.Map<StampResource, Stamp>(stampResource, stamp);
            stamp.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStampAsync(int id)
        {
            var stamp = await context.Stamps.FindAsync(id);
            if (stamp == null)
                return NotFound();

            context.Remove(stamp);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStampAsync(int id)
        {
            var stamp = await context.Stamps.FindAsync(id);
            if (stamp == null)
                return NotFound();

            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }
    }
}