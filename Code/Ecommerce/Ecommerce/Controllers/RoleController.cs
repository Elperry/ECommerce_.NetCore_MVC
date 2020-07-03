using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext db;

        public RoleController(UserManager<User> _userManager,ApplicationDbContext _db)
        {
            userManager = _userManager;
            db = _db;
        }

        public IActionResult Index()
        {

            return PartialView(db.Roles.ToList());
        }

        public ActionResult AssignUserToRole()
        {
            ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(db.Roles, "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AssignUserToRoleAsync(string Id, string Name)
        {
            var user = await userManager.GetUserAsync(User);
            await userManager.AddToRoleAsync(user, Name);
            ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(db.Roles, "Name", "Name");

            return Json(new { status =1});
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(string firstName)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Roles.Add(new IdentityRole() { Name = firstName });
                db.SaveChanges();
                return Json(new { status = 1 });
            }
            return Json(new { status = 0 });

        }

        public ActionResult Edit(string Id)
        {
            return PartialView(db.Roles.SingleOrDefault(c=>c.Id==Id));
        }

        [HttpPost]
        public ActionResult Edit(string firstName,string Id)
        {
            var role = db.Roles.SingleOrDefault(c => c.Id.ToLower() == Id.ToLower());
            role.Name = firstName;
            db.SaveChanges();
            return Json(new { status = 1 });
           
           // return Json(new { status = 0 });

        }

        public ActionResult Delete(string Id)
        {
            var role = db.Roles.SingleOrDefault(c => c.Id.ToLower() == Id.ToLower());
            db.Roles.Remove(role);
            db.SaveChanges();
            return Json(new { status = 1 });

        }


    }


}
