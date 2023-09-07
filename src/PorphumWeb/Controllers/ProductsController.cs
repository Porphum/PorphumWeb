using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage;
using PorphumReferenceBook.Logic.Storage.Models;
using PorphumSales.Logic.Storage;

namespace PorphumWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ReferenceBookContext _context;
        private readonly SalesContext _salesContext;

        public ProductsController(ReferenceBookContext context, SalesContext salesContext)
        {
            _context = context;
            _salesContext = salesContext;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var docs = _salesContext.Documents.ToList();
            var referenceBookContext = _context.Products.Include(p => p.Group);
            return View(await referenceBookContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Set<ProductGroup>(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cost,GroupId")] Product product)
        {
            var group = await _context.Set<ProductGroup>().FirstOrDefaultAsync(x => x.Id == product.GroupId);
            
            if (group is null)
            {
                ViewData["GroupId"] = new SelectList(_context.Set<ProductGroup>(), "Id", "Name", product.GroupId);
                return View(product);
            }
            product.Group = group;

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Set<ProductGroup>(), "Id", "Name", product.GroupId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Cost,GroupId")] Product product)
        {
            if (id != product.Id)
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
                    if (!ProductExists(product.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Set<ProductGroup>(), "Id", "Name", product.GroupId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ReferenceBookContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
