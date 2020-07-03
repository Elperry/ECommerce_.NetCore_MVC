using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment environment;
        private static int CountPerPage { get; set; } = 10;

        public static string pagination(int totalRecords , int pageNum , int pageCapacity , string s)
        {
            string p = "";


            int numOfPages = (totalRecords + pageCapacity - 1) / pageCapacity;
            for (var i = 1; i <= numOfPages; i++)
            {
                if (i == pageNum)
                {
                    p+="<li> <a class=\"pagination__link pagination__link--active\" >" + i + "</a> </li>";
                }
                else
                {
                    p += "<li> <a class=\"pagination__link \" href=\"/Products/Index?page="+i+"&s="+s+"\" onclick=\"ajaxRender(event)\">" + i + "</a> </li>";
                }
            }
            return p;
        }
        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        // GET: Products

        public async Task<IActionResult> Index(int page=1,string s="")
        {
            page--;
            var applicationDbContext = _context.Products.Include(p => p.Category).Include(p=>p.Offer).Where(e=>e.ProductName.ToLower().Contains(s.ToLower()) || e.ProductDescrition.ToLower().Contains(s.ToLower()));
            ViewBag.count = applicationDbContext.Count();
            ViewBag.countPerPage = CountPerPage;
            var result = applicationDbContext.Skip(page * CountPerPage).Take(CountPerPage);
            ViewBag.pagecount = result.Count();
            ViewBag.page = page+1;
            ViewBag.search = s;
            ViewBag.pagination = pagination(applicationDbContext.Count(), page + 1, CountPerPage,s);
            return View(await result.ToListAsync());
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescrition,ProductUnitInStock,ProductUnitPrice,OfferId,ProductImgUrl,CategoryId")] Product product, List<IFormFile> file)
        {
            try
            {
                foreach(var f in file)
                {
                    if (f.Length > 0)
                    {
                        product.ProductImgUrl = @$"Home/images/{Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "")}.png";
                        var filePath = Path.Combine(environment.WebRootPath, product.ProductImgUrl);
                        //product.ProductImgUrl = @"~/" + product.ProductImgUrl;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await f.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception)
            {

               // throw;
            }

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescrition,ProductUnitInStock,ProductUnitPrice,OfferId,CategoryId")] Product product, List<IFormFile> file)
        {
            try
            {
                foreach (var f in file)
                            {
                                if (f.Length > 0)
                                {
                        product.ProductImgUrl = @$"Home/images/{Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "")}.png";

                        var filePath = Path.Combine(environment.WebRootPath, product.ProductImgUrl);
                                using (var stream = System.IO.File.Create(filePath))
                                    {
                                        await f.CopyToAsync(stream);
                                    }
                                }
                            }
            }
            catch (Exception)
            {

                throw;
            }
            
            if (string.IsNullOrEmpty(product.ProductImgUrl))
            {
                var p = _context.Products.Single(p => p.CategoryId == id);
                product.ProductImgUrl = p.ProductImgUrl;
                _context.Entry(p).State = EntityState.Detached;
            }
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
