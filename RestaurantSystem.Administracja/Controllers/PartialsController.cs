using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class PartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public PartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Partials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Partial.Include(x => x.Page);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Partials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Partial == null)
            {
                return NotFound();
            }

            var @partial = await _context.Partial
                .Include(x => x.Page)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@partial == null)
            {
                return NotFound();
            }

            return View(@partial);
        }

        // GET: Partials/Create
        public IActionResult Create()
        {
            ViewData["PageId"] = new SelectList(_context.Page, "Id", "Title");
            var partialTypes = new PartialTypes().GetForSelector();
            ViewData["PartialType"] = new SelectList(partialTypes, "Value", "Key");
            return View();
        }

        // POST: Partials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Title,SubTitle,Content,IsForMainPage,PartialType,PartialButtonName,PartialButtonUrl,Position,PageId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] Partial @partial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@partial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PageId"] = new SelectList(_context.Page, "Id", "Title", @partial.PageId);
            var partialTypes = new PartialTypes().GetForSelector();
            ViewData["PartialType"] = new SelectList(partialTypes, "Value", "Key", @partial.PartialType);
            return View(@partial);
        }

        // GET: Partials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Partial == null)
            {
                return NotFound();
            }

            var @partial = await _context.Partial.FindAsync(id);
            if (@partial == null)
            {
                return NotFound();
            }
            ViewData["PageId"] = new SelectList(_context.Page, "Id", "Title", @partial.PageId);
            var partialTypes = new PartialTypes().GetForSelector();
            ViewData["PartialType"] = new SelectList(partialTypes, "Value", "Key", @partial.PartialType);
            return View(@partial);
        }

        // POST: Partials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Title,SubTitle,Content,IsForMainPage,PartialType,PartialButtonName,PartialButtonUrl,Position,PageId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] Partial @partial)
        {
            if (id != @partial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@partial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartialExists(@partial.Id))
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
            ViewData["PageId"] = new SelectList(_context.Page, "Id", "Title", @partial.PageId);
            var partialTypes = new PartialTypes().GetForSelector();
            ViewData["PartialType"] = new SelectList(partialTypes, "Value", "Key", @partial.PartialType);
            return View(@partial);
        }

        // GET: Partials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Partial == null)
            {
                return NotFound();
            }

            var @partial = await _context.Partial
                .Include(x => x.Page)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@partial == null)
            {
                return NotFound();
            }

            return View(@partial);
        }

        // POST: Partials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Partial == null)
            {
                return Problem("Entity set 'RestaurantContext.Partial'  is null.");
            }
            var @partial = await _context.Partial.FindAsync(id);
            if (@partial != null)
            {
                _context.Partial.Remove(@partial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartialExists(int id)
        {
          return (_context.Partial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
