using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext db;

        public RoleController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        //public ActionResult AssignUserToRole()
        //{
        //    ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
        //    ViewBag.Roles = new SelectList(db.Roles, "Name", "Name");
        //    return View();
        //}
        //[HttpPost]
        //public async Task<ActionResult> AssignUserToRoleAsync(string Id, string Name)
        //{

        //  // await _userManager.AddToRoleAsync(Id, Name);
        //    ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
        //    ViewBag.Roles = new SelectList(db.Roles, "Name", "Name");

        //    return View();
        //}
    }
}
