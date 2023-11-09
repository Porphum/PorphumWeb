using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumWeb.Controllers
{
    public class ProductGroupsController : Controller
    {
        private readonly ReferenceBookContext _context;

        public ProductGroupsController(ReferenceBookContext context)
        {
            _context = context;
        }

        // GET: ProductGroups
        public async Task<IActionResult> Index()
        {
              return _context.ProductsGroups != null ? 
                          View(await _context.ProductsGroups.ToListAsync()) :
                          Problem("Entity set 'ReferenceBookContext.ProductsGroups'  is null.");
        }

        // GET: ProductGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductsGroups == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductsGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // GET: ProductGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productGroup);
        }

        // GET: ProductGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductsGroups == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductsGroups.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }
            return View(productGroup);
        }

        // POST: ProductGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductGroup productGroup)
        {
            if (id != productGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductGroupExists(productGroup.Id))
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
            return View(productGroup);
        }

        // GET: ProductGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductsGroups == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductsGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // POST: ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductsGroups == null)
            {
                return Problem("Entity set 'ReferenceBookContext.ProductsGroups'  is null.");
            }
            var productGroup = await _context.ProductsGroups.FindAsync(id);
            if (productGroup != null)
            {
                _context.ProductsGroups.Remove(productGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductGroupExists(int id)
        {
          return (_context.ProductsGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
