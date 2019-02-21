using System.Collections.Generic;
using System.Threading.Tasks;
using Stamps.Core.Models;

namespace Stamps.Core
{
    public interface IStampRepository
    {
        Task<Stamp> GetStampAsync(int id, bool includeRelated = true);
        void Add(Stamp stamp);
        void Remove(Stamp stamp);
        Task<IEnumerable<Stamp>> GetStampsAsync(Filter filter);
    }
}