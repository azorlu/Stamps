using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stamps.Core;
using Stamps.Core.Models;

namespace Stamps.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly StampsDbContext context;

        public PhotoRepository(StampsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync(int stampId)
        {
            return await context.Photos
            .Where(p => p.StampId == stampId)
            .ToListAsync();
        }
    }
}