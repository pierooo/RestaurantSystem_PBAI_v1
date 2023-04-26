using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;

namespace RestaurantSystem.Administracja.Controllers
{
    public class CurrentMenuPartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public CurrentMenuPartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: CurrentMenuPartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.CurrentMenuPartial.Include(c => c.Partial).Include(c => c.Product);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: CurrentMenuPartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CurrentMenuPartial == null)
            {
                return NotFound();
            }

            var currentMenuPartial = await _context.CurrentMenuPartial
                .Include(c => c.Partial)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentMenuPartial == null)
            {
                return NotFound();
            }

            return View(currentMenuPartial);
        }

        // GET: CurrentMenuPartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: CurrentMenuPartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,ProductId,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentMenuPartial currentMenuPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentMenuPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", currentMenuPartial.PartialId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", currentMenuPartial.ProductId);
            return View(currentMenuPartial);
        }

        // GET: CurrentMenuPartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CurrentMenuPartial == null)
            {
                return NotFound();
            }

            var currentMenuPartial = await _context.CurrentMenuPartial.FindAsync(id);
            if (currentMenuPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", currentMenuPartial.PartialId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", currentMenuPartial.ProductId);
            return View(currentMenuPartial);
        }

        // POST: CurrentMenuPartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,ProductId,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentMenuPartial currentMenuPartial)
        {
            if (id != currentMenuPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentMenuPartial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentMenuPartialExists(currentMenuPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", currentMenuPartial.PartialId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", currentMenuPartial.ProductId);
            return View(currentMenuPartial);
        }

        // GET: CurrentMenuPartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CurrentMenuPartial == null)
            {
                return NotFound();
            }

            var currentMenuPartial = await _context.CurrentMenuPartial
                .Include(c => c.Partial)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentMenuPartial == null)
            {
                return NotFound();
            }

            return View(currentMenuPartial);
        }

        // POST: CurrentMenuPartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CurrentMenuPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.CurrentMenuPartial'  is null.");
            }
            var currentMenuPartial = await _context.CurrentMenuPartial.FindAsync(id);
            if (currentMenuPartial != null)
            {
                _context.CurrentMenuPartial.Remove(currentMenuPartial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentMenuPartialExists(int id)
        {
          return (_context.CurrentMenuPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
