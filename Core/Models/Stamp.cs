using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stamps.Core.Models
{
    [Table("Stamps")]
    public class Stamp
    {
        public Stamp(int id, int countryId, Country country, int categoryId, Category category, int yearIssued, string title, string description, DateTime lastUpdate)
        {
            this.Id = id;
            this.CountryId = countryId;
            this.Country = country;
            this.CategoryId = categoryId;
            this.Category = category;
            this.YearIssued = yearIssued;
            this.Title = title;
            this.Description = description;
            this.LastUpdate = lastUpdate;

        }
        public int Id { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int YearIssued { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public Stamp()
        {
            Photos = new Collection<Photo>();
        }

    }
}