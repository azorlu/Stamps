using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamps.Core.Models
{
    [Table("Stamps")]
    public class Stamp
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int YearIssued { get; set; } 

        [Required(ErrorMessage="Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; } 

        public DateTime LastUpdate { get; set; }

        public Stamp()
        {
            
        }

    }
}