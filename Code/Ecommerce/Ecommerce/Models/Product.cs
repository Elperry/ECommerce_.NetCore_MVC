using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name ="Product")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Descrition")]
        public string ProductDescrition { get; set; }

        [Display(Name = "Unit In Stock")]
        public int ProductUnitInStock { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName ="money")]
        public decimal ProductUnitPrice { get; set; }

        [Required]
        public string ProductImgUrl { get; set; }

        public int? OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
