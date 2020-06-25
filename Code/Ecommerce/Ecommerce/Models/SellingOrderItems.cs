using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class SellingOrderItems
    {
        
        public int ProductId { get; set; }
        public int SellingOrderId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName ="money")]
        [Display(Name ="Unit Price")]
        public decimal UnitPrice { get; set; }

      
        public virtual SellingOrder SellingOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
