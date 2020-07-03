using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Display(Name ="City")]
        [Required]
        public string CityName { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}