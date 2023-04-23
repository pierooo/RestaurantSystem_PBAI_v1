using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Administracja.Models.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class HeroPartialController : BaseController
    {
        public HeroPartialController(RestaurantContext context, PartialValidator partialvalidator) : base(context, partialvalidator)
        {
        }

        // GET: HeroPartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.HeroPartial.Include(h => h.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: HeroPartial/Details/5
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

        // GET: HeroPartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id");
            return View();
        }

        // POST: HeroPartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoName,HeroButtonName,HeroButtonUrl,VideoTitle,VideoModalTitle,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] HeroPartial heroPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heroPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", heroPartial.PartialId);
            return View(heroPartial);
        }

        // GET: HeroPartial/Edit/5
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", heroPartial.PartialId);
            return View(heroPartial);
        }

        // POST: HeroPartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoName,HeroButtonName,HeroButtonUrl,VideoTitle,VideoModalTitle,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] HeroPartial heroPartial)
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", heroPartial.PartialId);
            return View(heroPartial);
        }

        // GET: HeroPartial/Delete/5
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

        // POST: HeroPartial/Delete/5
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
