using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class User : IdentityUser
    {
        [Display(Name="full name")]
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }


        //tell the group to add this field
        [Display(Name = "Image")]
        public string img { get; set; }

        public virtual Country Country { get; set; }
        public virtual City City { get; set; }

    }
}
