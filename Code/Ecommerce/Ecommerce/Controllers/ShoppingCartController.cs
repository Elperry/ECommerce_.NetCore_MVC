using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
namespace Ecommerce.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db;
        CheckoutViewModel model;
        public ShoppingCartController(ApplicationDbContext _db)
        {
            db = _db;
            model = new CheckoutViewModel();
        }
        public IActionResult EditShoppingCart()
        {
            var cartProductCookie = Request.Cookies["CartProducts"];
            int quantity = 0;
            if (cartProductCookie != null && cartProductCookie != "")
            {

                model.CartProductIDs = cartProductCookie.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = db.Products.Include(ww => ww.Offer).Where(p => model.CartProductIDs.Contains(p.ProductId)).ToList();
                foreach (var product in model.CartProducts)
                {
                    quantity = model.CartProductIDs.Count(x => x == product.ProductId);
                    model?.Order?.Add(product.ProductId, quantity);
                }
            }
            return View(model);
        }
    }
}