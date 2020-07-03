using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
   // [Authorize(Roles = "admin")]
    public class MessagesController : Controller
    {
        ApplicationDbContext db;
        public MessagesController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return PartialView(db.Messages.ToList()) ;
        }
    }
}
