using System.Threading.Tasks;

namespace Stamps.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StampsDbContext context;

        public UnitOfWork(StampsDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}