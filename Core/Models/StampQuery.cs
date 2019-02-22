using Stamps.Extensions;

namespace Stamps.Core.Models
{
    public class StampQuery : IQueryObject
    {
        public int? CountryId {get; set; }

        public int? ContinentId { get; set; }

        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }
        
        public byte PageSize { get; set; }

    }
}