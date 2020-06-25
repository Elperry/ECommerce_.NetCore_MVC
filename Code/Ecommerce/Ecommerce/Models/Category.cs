using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name ="Category")]
        [Required]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
       
        public string CategoryDescription { get; set; }

        [Display(Name = "image")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
