using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamps.Controllers.Resources;
using Stamps.Core.Models;
using Stamps.Core;
using System.Collections.Generic;

namespace Stamps.Controllers
{
    [Route("/api/stamps")]
    public class StampsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IStampRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public StampsController(IMapper mapper, 
            IStampRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStampAsync([FromBody] SaveStampResource stampResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stamp = mapper.Map<SaveStampResource, Stamp>(stampResource);
            stamp.LastUpdate = DateTime.Now;

            repository.Add(stamp);
            await unitOfWork.CompleteAsync();

            stamp = await repository.GetStampAsync(stamp.Id);

            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStampAsync(int id, [FromBody] SaveStampResource stampResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stamp = await repository.GetStampAsync(id);

            if (stamp == null)
                return NotFound();

            mapper.Map<SaveStampResource, Stamp>(stampResource, stamp);
            stamp.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            stamp = await repository.GetStampAsync(id);
            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStampAsync(int id)
        {
            var stamp = await repository.GetStampAsync(id, includeRelated: false);

            if (stamp == null)
                return NotFound();

            repository.Remove(stamp);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStampAsync(int id)
        {
            var stamp = await repository.GetStampAsync(id);
           
           if (stamp == null)
                return NotFound();

            var result = mapper.Map<Stamp, StampResource>(stamp);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<StampResource>> GetStampsAsync(StampQueryResource filterResource) 
        {
            var filter = mapper.Map<StampQueryResource, StampQuery>(filterResource);
            var stamps = await repository.GetStampsAsync(filter);
            var result = mapper.Map<IEnumerable<Stamp>, IEnumerable<StampResource>>(stamps);

            return result;
        }

    }
}