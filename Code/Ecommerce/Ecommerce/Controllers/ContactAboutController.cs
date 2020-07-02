using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ContactAboutController : Controller
    {
        ApplicationDbContext db;
        public ContactAboutController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult About()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Message m)
        {
            if (m != null)
            {
                db.Messages.Add(m);
                db.SaveChanges();
            }
            return LocalRedirect("/Home/Index");
        }
    }
}
