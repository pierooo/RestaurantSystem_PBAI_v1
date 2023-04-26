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
    public class CurrentEventPartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public CurrentEventPartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: CurrentEventPartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.CurrentEventPartial.Include(c => c.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: CurrentEventPartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CurrentEventPartial == null)
            {
                return NotFound();
            }

            var currentEventPartial = await _context.CurrentEventPartial
                .Include(c => c.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentEventPartial == null)
            {
                return NotFound();
            }

            return View(currentEventPartial);
        }

        // GET: CurrentEventPartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id");
            return View();
        }

        // POST: CurrentEventPartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentEventPartial currentEventPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentEventPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", currentEventPartial.PartialId);
            return View(currentEventPartial);
        }

        // GET: CurrentEventPartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CurrentEventPartial == null)
            {
                return NotFound();
            }

            var currentEventPartial = await _context.CurrentEventPartial.FindAsync(id);
            if (currentEventPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", currentEventPartial.PartialId);
            return View(currentEventPartial);
        }

        // POST: CurrentEventPartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentEventPartial currentEventPartial)
        {
            if (id != currentEventPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentEventPartial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentEventPartialExists(currentEventPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", currentEventPartial.PartialId);
            return View(currentEventPartial);
        }

        // GET: CurrentEventPartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CurrentEventPartial == null)
            {
                return NotFound();
            }

            var currentEventPartial = await _context.CurrentEventPartial
                .Include(c => c.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentEventPartial == null)
            {
                return NotFound();
            }

            return View(currentEventPartial);
        }

        // POST: CurrentEventPartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CurrentEventPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.CurrentEventPartial'  is null.");
            }
            var currentEventPartial = await _context.CurrentEventPartial.FindAsync(id);
            if (currentEventPartial != null)
            {
                _context.CurrentEventPartial.Remove(currentEventPartial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentEventPartialExists(int id)
        {
          return (_context.CurrentEventPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
