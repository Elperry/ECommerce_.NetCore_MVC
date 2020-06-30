using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class SupplierController : Controller
    {
        ApplicationDbContext Db;
        public SupplierController(ApplicationDbContext _Db)
        {
            Db = _Db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(Db.Suppliers.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                Db.Suppliers.Add(supplier);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Supplier supplier = Db.Suppliers.Find(id);
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(supplier).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Supplier supplier = Db.Suppliers.Find(id);
            Db.Suppliers.Remove(supplier);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}