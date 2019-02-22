using System.Collections.Generic;
using System.Threading.Tasks;
using Stamps.Core.Models;

namespace Stamps.Core
{
    public interface ICountryRepository
    {
         Task<IEnumerable<Country>> GetCountriesAsync();
    }
}