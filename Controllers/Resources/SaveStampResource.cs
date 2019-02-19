using System;
using System.ComponentModel.DataAnnotations;

namespace Stamps.Controllers.Resources
{
    public class SaveStampResource
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int CategoryId { get; set; }

        public int YearIssued { get; set; } 

        [Required(ErrorMessage="Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; } 

        public SaveStampResource()
        {
            
        }
    }
}