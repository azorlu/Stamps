namespace Stamps.Controllers.Resources
{
    public class StampQueryResource
    {
        public int? ContinentId { get; set; }

        public int? CountryId { get; set; }

        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

    }
}