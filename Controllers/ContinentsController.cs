using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stamps.Controllers.Resources;
using Stamps.Core;
using Stamps.Core.Models;
using Stamps.Persistence;

namespace Stamps.Controllers
{
    public class ContinentsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IContinentRepository repository;

        public ContinentsController(IMapper mapper, IContinentRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet("/api/continents")]
        public async Task<IEnumerable<ContinentResource>> GetContinentsAsync() {
            var continents = await repository.GetContinentsAsync();

            return mapper.Map<IEnumerable<Continent>, List<ContinentResource>>(continents);
        }
    }
}