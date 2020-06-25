using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class OrderItems
    {
        
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        
        public int Quantity { get; set; }
        [Column(TypeName ="money")]
        [Display(Name ="Price")]
        public decimal UnitPrice { get; set; }

      
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
