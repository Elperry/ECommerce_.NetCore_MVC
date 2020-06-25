using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Display(Name ="Supplier")]
        [Required]
        public string SupplierName { get; set; }

        [Display(Name = "Address")]
        public string SupplierAddress { get; set; }
    }
}
