using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stamps.Models
{
    public class Continent
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }

        public Continent() => Countries = new Collection<Country>();
    }
}