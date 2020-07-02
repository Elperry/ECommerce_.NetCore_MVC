using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Offer
    {
        public int OfferId { get; set; }

        [Display(Name ="Offer")]
        public string OfferName { get; set; }

        [Display(Name = "Sale %")]
        [Required]
        [Range(.1,.90)]
        [Column(TypeName = "money")]
        public decimal Sale { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]//remember to make validation between 2 dates 
        public DateTime DateTo { get; set; }

        public virtual ICollection<Product> Product { get; set; } = new HashSet<Product>();
    }
}
