using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "admin")]
    public class SupplierController : Controller
    {
        ApplicationDbContext Db;
        public SupplierController(ApplicationDbContext _Db)
        {
            Db = _Db;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var AppContext = Db.Suppliers;
            return View(await AppContext.ToListAsync());
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
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Supplier supplier = await Db.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Db.Entry(supplier).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await Db.Suppliers.FindAsync(id);
            Db.Suppliers.Remove(supplier);
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}