using System.Threading.Tasks;
using Stamps.Models;

namespace Stamps.Persistence
{
    public interface IStampRepository
    {
         Task<Stamp> GetStampAsync(int id, bool includeRelated = true);
         void Add(Stamp stamp);
         void Remove(Stamp stamp);
    }
}