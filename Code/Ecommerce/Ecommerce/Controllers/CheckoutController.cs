using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Controllers
{
    public class CheckoutController : Controller
    {
        ApplicationDbContext db;
        CheckoutViewModel model;
        public CheckoutController(ApplicationDbContext _db)
        {
            db = _db;
            model = new CheckoutViewModel();
        }
        public IActionResult OrderDetails()
        {
            var cartProductCookie = Request.Cookies["CartProducts"];
            int quantity = 0;
            if (cartProductCookie != null && cartProductCookie != "")
            {

                model.CartProductIDs = cartProductCookie.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = db.Products.Where(p => model.CartProductIDs.Contains(p.ProductId)).ToList();
                foreach (var product in model.CartProducts)
                {
                    quantity = model.CartProductIDs.Count(x => x == product.ProductId);
                    model?.Order?.Add(product.ProductId, quantity);
                }
            }
            ViewBag.CountryId = new SelectList(db.Countries.ToList(), "CountryId", "CountryName", 1);
            ViewBag.CityId = new SelectList(db.Cities.ToList(), "CityId", "CityName", 1);
            return View(model);
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel PersonalInfo)
        {
            var cartProductCookie = Request.Cookies["CartProducts"];
            int quantity = 0;
            model.CartProductIDs = cartProductCookie.Split('-').Select(x => int.Parse(x)).ToList();
            model.CartProducts = db.Products.Where(p => model.CartProductIDs.Contains(p.ProductId)).ToList();
            if (cartProductCookie != null && cartProductCookie != "")
            {
                decimal _totalPrice = Convert.ToDecimal(model.CartProducts.Sum(x => x.ProductUnitPrice * model.CartProductIDs.Count(p => x.ProductId == p)));
                Order newOrder = new Order
                {
                    UserName = PersonalInfo.OrderData.UserName,
                    UserEmail = PersonalInfo.OrderData.UserEmail,
                    Telephone = PersonalInfo.OrderData.Telephone,
                    CountryId = PersonalInfo.OrderData.Country.CountryId,
                    CityId = PersonalInfo.OrderData.City.CityId,
                    OrderDate = DateTime.Now,
                    Status = Status.Preparing,
                    Taxes = 0.05m * _totalPrice /100,
                    Discount = 0.0m,
                    TotalPrice = _totalPrice
                };
                db.Orders.Add(newOrder);
                db.SaveChanges();

                var latestOrder = db.Orders.Max(x => x.OrderId);
                foreach (var product in model.CartProducts)
                {
                    quantity = model.CartProductIDs.Count(x => x == product.ProductId);
                    model?.Order?.Add(product.ProductId, quantity);
                    db.OrderItems.Add(new OrderItems
                    {
                        OrderId = latestOrder,
                        ProductId = product.ProductId,
                        Quantity = quantity,
                        UnitPrice = product.ProductUnitPrice
                    });
                    db.SaveChanges();
                }

            }
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddSeconds(30);
            Response.Cookies.Append("Checkout", "true", option); 
            return RedirectToAction("Index","Home");
        }
    }
}
