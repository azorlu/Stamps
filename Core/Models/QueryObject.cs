using Stamps.Extensions;

namespace Stamps.Core.Models
{
    public class QueryObject : IQueryObject
    {
        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }
        
        public byte PageSize { get; set; }

    }
}