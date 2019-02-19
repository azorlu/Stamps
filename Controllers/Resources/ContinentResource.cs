using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stamps.Controllers.Resources
{
    public class ContinentResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Countries { get; set; }

        public ContinentResource() => Countries = new Collection<KeyValuePairResource>();
    }
}