using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class SellingOrder
    {
        public int SellingOrderId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
      
       
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Discount { get; set; } = 0.0m;

        [Column(TypeName = "money")]
        
        public decimal Taxes { get; set; } = 0.0m;

        [Column(TypeName = "money")]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        [NotMapped]
        public decimal Sum { get; set; }

        public virtual ICollection<SellingOrderItems> SellingOrderItems { get; set; } = new HashSet<SellingOrderItems>();

        public virtual Supplier Supplier { get; set; }
       
    }
  
}
