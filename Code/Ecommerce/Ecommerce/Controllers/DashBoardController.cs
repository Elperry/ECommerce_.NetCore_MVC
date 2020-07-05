using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Authorize(Roles ="admin")]
    public class DashBoardController : Controller
    {

        public DashBoardController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        public IActionResult Index()
        {
            ViewBag.ItemSales = DbContext.OrderItems.Sum(e => e.Quantity);
            ViewBag.NewOrders = DbContext.Orders.Count();
            ViewBag.TotalProducts = DbContext.Products.Count(e => e.ProductUnitInStock > 0);
            ViewBag.Users = DbContext.Users.Count();
            return View();
        }
        public IActionResult Index33()
        {
            return View();
        }
    }
}
