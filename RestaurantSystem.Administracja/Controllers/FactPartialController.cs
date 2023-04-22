using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Administracja.Data;
using RestaurantSystem.Administracja.Models.CMS;
using RestaurantSystem.Administracja.Models.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class FactPartialController : BaseController
    {
        public FactPartialController(RestaurantContext context, PartialValidator partialvalidator) : base(context, partialvalidator)
        {
        }

        // GET: FactPartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.FactPartial.Include(f => f.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: FactPartial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FactPartial == null)
            {
                return NotFound();
            }

            var factPartial = await _context.FactPartial
                .Include(f => f.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factPartial == null)
            {
                return NotFound();
            }

            return View(factPartial);
        }

        // GET: FactPartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id");
            return View();
        }

        // POST: FactPartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Count,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] FactPartial factPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", factPartial.PartialId);
            return View(factPartial);
        }

        // GET: FactPartial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FactPartial == null)
            {
                return NotFound();
            }

            var factPartial = await _context.FactPartial.FindAsync(id);
            if (factPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", factPartial.PartialId);
            return View(factPartial);
        }

        // POST: FactPartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Count,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] FactPartial factPartial)
        {
            if (id != factPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factPartial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactPartialExists(factPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", factPartial.PartialId);
            return View(factPartial);
        }

        // GET: FactPartial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FactPartial == null)
            {
                return NotFound();
            }

            var factPartial = await _context.FactPartial
                .Include(f => f.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factPartial == null)
            {
                return NotFound();
            }

            return View(factPartial);
        }

        // POST: FactPartial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FactPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.FactPartial'  is null.");
            }
            var factPartial = await _context.FactPartial.FindAsync(id);
            if (factPartial != null)
            {
                _context.FactPartial.Remove(factPartial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactPartialExists(int id)
        {
            return (_context.FactPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
