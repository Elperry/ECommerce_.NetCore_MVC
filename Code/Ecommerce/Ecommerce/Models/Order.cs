using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        [Display(Name ="Name")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "phone")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }


        public Status Status { get; set; }


        [Column(TypeName ="money")]
        public decimal Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal Taxes { get; set; }

        [Display(Name = "Total Price")]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
        [NotMapped]
        public decimal Sum { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; } = new HashSet<OrderItems>();

        public virtual User User { get; set; }

    }
    public enum Status{
        Pending,Delivered,Shipping,Preparing
    }
}
