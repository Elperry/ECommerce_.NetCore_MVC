using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        ApplicationDbContext Db;
        private readonly IWebHostEnvironment hosting;
        public CategoryController(ApplicationDbContext _Db, IWebHostEnvironment _hosting)
        {
            Db = _Db;
            hosting = _hosting;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(Db.Categories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category, IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    category.ImageUrl = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "")+".png";
                    string path = @$"Home/images/{category.ImageUrl}";
                    var filePath = Path.Combine(hosting.WebRootPath, path);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                category.ImageUrl = "";
                Db.Categories.Add(category);
                Db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                Db.Categories.Add(category);
                Db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = Db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Category category, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                Category oldCategory = Db.Categories.Find(id);
                try
                {
                    if (file.Length > 0)
                    {
                        category.ImageUrl = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "") + ".png";
                        string path = @$"Home/images/{category.ImageUrl}";
                        var filePath = Path.Combine(hosting.WebRootPath, path);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    oldCategory.CategoryName = category.CategoryName;
                    oldCategory.CategoryDescription = category.CategoryDescription;

                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                oldCategory.CategoryName = category.CategoryName;
                oldCategory.CategoryDescription = category.CategoryDescription;
                oldCategory.ImageUrl = category.ImageUrl;

                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await Db.Categories.FindAsync(id);
            Db.Categories.Remove(category);
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}

