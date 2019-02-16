using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamps.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public string Name { get; set; }        

        public int ContinentId { get; set; }
        public Continent Continent { get; set; }
    
    }
}