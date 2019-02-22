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
    public class CountriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICountryRepository repository;

        public CountriesController(IMapper mapper, ICountryRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet("/api/Countries")]
        public async Task<IEnumerable<CountryResource>> GetCountriesAsync() {
            var Countries = await repository.GetCountriesAsync();

            return mapper.Map<IEnumerable<Country>, List<CountryResource>>(Countries);
        }
    }
}