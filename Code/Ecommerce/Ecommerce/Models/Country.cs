using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        [Display(Name = "Country")]
        [Required]
        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}