using Ecommerce.Areas.Identity.Pages.Account.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class CheckoutViewModel
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIDs { get; set; }
        public Dictionary<int, int> Order { get; set; }
        public Order OrderData { get; set; }

    }
}
