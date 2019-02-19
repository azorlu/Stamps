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
    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository repository;

        public CategoriesController(IMapper mapper, ICategoryRepository repository) 
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet("/api/categories")]
        public async Task<IEnumerable<KeyValuePairResource>> GetCategoriesAsync() {
            var categories = await repository.GetCategoriesAsync();

            return mapper.Map<IEnumerable<Category>, List<KeyValuePairResource>>(categories);
        }
    }
}