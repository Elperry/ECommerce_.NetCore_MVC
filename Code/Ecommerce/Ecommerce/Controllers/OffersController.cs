using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using System.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using SQLitePCL;

namespace Ecommerce.Controllers
{
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static int CountPerPage { get; set; } = 10;

        public static string pagination(int totalRecords, int pageNum, int pageCapacity, string s)
        {
            string p = "";


            int numOfPages = (totalRecords + pageCapacity - 1) / pageCapacity;
            for (var i = 1; i <= numOfPages; i++)
            {
                if (i == pageNum)
                {
                    p += "<li> <a class=\"pagination__link pagination__link--active\" >" + i + "</a> </li>";
                }
                else
                {
                    p += "<li> <a class=\"pagination__link \" href=\"/Products/Index?page=" + i + "&s=" + s + "\" onclick=\"ajaxRender(event)\">" + i + "</a> </li>";
                }
            }
            return p;
        }
        public OffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index(int page = 1, string s = "")
        {
            page--;
            var applicationDbContext = _context.Offers.Include(o => o.Product).Where(e => e.OfferName.ToLower().Contains(s.ToLower()) || e.Product.ProductName.ToLower().Contains(s.ToLower()));
            ViewBag.count = applicationDbContext.Count();
            ViewBag.countPerPage = CountPerPage;
            var result = applicationDbContext.Skip(page * CountPerPage).Take(CountPerPage);
            ViewBag.pagecount = result.Count();
            ViewBag.page = page + 1;
            ViewBag.search = s;
            ViewBag.pagination = pagination(applicationDbContext.Count(), page + 1, CountPerPage, s);
            return View(await result.ToListAsync());
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OfferId == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfferId,OfferName,ProductId,Sale,DateFrom,DateTo")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offer);
                await _context.SaveChangesAsync();
                var p = _context.Products.Where(ee => ee.ProductId == offer.ProductId).FirstOrDefault();
                p.OfferId = offer.OfferId;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", offer.ProductId);
            return View(offer);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", offer.ProductId);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfferId,OfferName,ProductId,Sale,DateFrom,DateTo")] Offer offer)
        {
            if (id != offer.OfferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var o = _context.Offers.Single(ee => ee.OfferId == id);
                    var p = _context.Products.Where(ee => ee.ProductId == o.ProductId).FirstOrDefault();
                    p.OfferId =null;
                    await _context.SaveChangesAsync();
                    _context.Entry(o).State = EntityState.Detached;
                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                    p = _context.Products.Where(ee => ee.ProductId == offer.ProductId).FirstOrDefault();
                    p.OfferId = offer.OfferId;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.OfferId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", offer.ProductId);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OfferId == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
            return _context.Offers.Any(e => e.OfferId == id);
        }
    }
}
