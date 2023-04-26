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
    public class HeroPartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public HeroPartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: HeroPartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.HeroPartial.Include(h => h.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: HeroPartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HeroPartial == null)
            {
                return NotFound();
            }

            var heroPartial = await _context.HeroPartial
                .Include(h => h.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heroPartial == null)
            {
                return NotFound();
            }

            return View(heroPartial);
        }

        // GET: HeroPartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id");
            return View();
        }

        // POST: HeroPartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,PhotoName,HeroButtonName,HeroButtonUrl,VideoTitle,VideoModalTitle,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] HeroPartial heroPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heroPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", heroPartial.PartialId);
            return View(heroPartial);
        }

        // GET: HeroPartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HeroPartial == null)
            {
                return NotFound();
            }

            var heroPartial = await _context.HeroPartial.FindAsync(id);
            if (heroPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", heroPartial.PartialId);
            return View(heroPartial);
        }

        // POST: HeroPartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,PhotoName,HeroButtonName,HeroButtonUrl,VideoTitle,VideoModalTitle,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] HeroPartial heroPartial)
        {
            if (id != heroPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heroPartial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroPartialExists(heroPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", heroPartial.PartialId);
            return View(heroPartial);
        }

        // GET: HeroPartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HeroPartial == null)
            {
                return NotFound();
            }

            var heroPartial = await _context.HeroPartial
                .Include(h => h.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heroPartial == null)
            {
                return NotFound();
            }

            return View(heroPartial);
        }

        // POST: HeroPartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HeroPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.HeroPartial'  is null.");
            }
            var heroPartial = await _context.HeroPartial.FindAsync(id);
            if (heroPartial != null)
            {
                _context.HeroPartial.Remove(heroPartial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeroPartialExists(int id)
        {
          return (_context.HeroPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
