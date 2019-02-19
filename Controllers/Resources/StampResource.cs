using System;

namespace Stamps.Controllers.Resources
{
    public class StampResource
    {
        public int Id { get; set; }

        public KeyValuePairResource Country { get; set; }

        public KeyValuePairResource Continent { get; set; }

        public KeyValuePairResource Category { get; set; }

        public int YearIssued { get; set; } 

        public string Title { get; set; }

        public string Description { get; set; } 

        public DateTime LastUpdate { get; set; }
    }
}