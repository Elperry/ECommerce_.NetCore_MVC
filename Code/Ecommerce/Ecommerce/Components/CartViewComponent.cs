using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Components
{
    public class CartViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext db;
        CheckoutViewModel model;

        public CartViewComponent(ApplicationDbContext db)
        {
            this.db = db;
            model = new CheckoutViewModel();
        }
        public IViewComponentResult Invoke()
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
                    if (product.ProductUnitInStock != 0)
                        model?.Order?.Add(product.ProductId, quantity);
                }
                TempData["name"] = "from shopping cart";

            }
            return View(model);
        }
    }
}
