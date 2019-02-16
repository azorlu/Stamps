using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stamps.Controllers.Resources
{
    public class ContinentResource
    {
        public int Id { get; set; } 
        
        public string Name { get; set; }
        public ICollection<CountryResource> Countries { get; set; }

        public ContinentResource() => Countries = new Collection<CountryResource>();
    }
}