using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db;
        public ProductController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult PrdDetails(int id)
        {
            if (id == null)
                return RedirectToAction("Error", "Home");

            // var product = db.Products.Find(id);
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            const int numOfRelated = 4;
            if (product is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                var relatedProducts = db.Products.OrderByDescending(p => p.ProductId).Take(4)
                    .Where(p => p.CategoryId == product.CategoryId);
                ViewBag.product = product;
                int size = relatedProducts.Count();
                if (size < numOfRelated)
                {
                    for (int i = 0; i < numOfRelated - size; i++)
                    {
                        relatedProducts.ToList().Add(product);
                    }
                }
                return View(relatedProducts);
            }
        }
    }
}