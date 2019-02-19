using System.Threading.Tasks;

namespace Stamps.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}