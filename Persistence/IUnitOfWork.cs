using System.Threading.Tasks;

namespace Stamps.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}