using Stamps.Extensions;

namespace Stamps.Core.Models
{
    public class StampQuery : QueryObject
    {
        public int? CountryId {get; set; }

        public int? ContinentId { get; set; }
    }
}