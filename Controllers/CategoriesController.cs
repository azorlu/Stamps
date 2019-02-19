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
        private readonly StampsDbContext context;
        private readonly IMapper mapper;

        public CategoriesController(StampsDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/categories")]
        public async Task<IEnumerable<KeyValuePairResource>> GetCategoriesAsync() {
            var categories = await context.Categories.ToListAsync();

            return mapper.Map<List<Category>, List<KeyValuePairResource>>(categories);
        }
    }
}