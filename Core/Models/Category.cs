using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamps.Core.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}