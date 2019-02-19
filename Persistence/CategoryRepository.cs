using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Core;
using Stamps.Core.Models;

namespace Stamps.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StampsDbContext context;

        public CategoryRepository(StampsDbContext context)
        {
            this.context = context;
        }
        
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }
    }
}