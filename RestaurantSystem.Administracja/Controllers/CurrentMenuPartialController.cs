using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Administracja.Data;
using RestaurantSystem.Administracja.Models.CMS;
using RestaurantSystem.Administracja.Models.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class CurrentMenuPartialController : BaseController
    {
        public CurrentMenuPartialController(RestaurantContext context, PartialValidator partialvalidator) : base(context, partialvalidator)
        {
        }

        // GET: CurrentMenuPartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.CurrentMenuPartial.Include(c => c.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: CurrentMenuPartial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CurrentMenuPartial == null)
            {
                return NotFound();
            }

            var currentMenuPartial = await _context.CurrentMenuPartial
                .Include(c => c.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentMenuPartial == null)
            {
                return NotFound();
            }

            return View(currentMenuPartial);
        }

        // GET: CurrentMenuPartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id");
            return View();
        }

        // POST: CurrentMenuPartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentMenuPartial currentMenuPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentMenuPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", currentMenuPartial.PartialId);
            return View(currentMenuPartial);
        }

        // GET: CurrentMenuPartial/Edit/5
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", currentMenuPartial.PartialId);
            return View(currentMenuPartial);
        }

        // POST: CurrentMenuPartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentMenuPartial currentMenuPartial)
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", currentMenuPartial.PartialId);
            return View(currentMenuPartial);
        }

        // GET: CurrentMenuPartial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CurrentMenuPartial == null)
            {
                return NotFound();
            }

            var currentMenuPartial = await _context.CurrentMenuPartial
                .Include(c => c.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentMenuPartial == null)
            {
                return NotFound();
            }

            return View(currentMenuPartial);
        }

        // POST: CurrentMenuPartial/Delete/5
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
