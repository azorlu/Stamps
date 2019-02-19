using System.Collections.Generic;
using System.Threading.Tasks;
using Stamps.Core.Models;

namespace Stamps.Core
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}