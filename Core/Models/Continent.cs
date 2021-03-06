using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamps.Core.Models
{
    [Table("Continents")]
    public class Continent
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }

        public Continent() => Countries = new Collection<Country>();
    }
}