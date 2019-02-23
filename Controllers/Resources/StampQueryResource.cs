using Stamps.Core.Models;

namespace Stamps.Controllers.Resources
{
    public class StampQueryResource : QueryObject
    {
        public int? ContinentId { get; set; }

        public int? CountryId { get; set; }
    }
}