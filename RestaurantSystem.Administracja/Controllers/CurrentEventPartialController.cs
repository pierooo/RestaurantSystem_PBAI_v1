using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class CurrentEventPartialController : BaseController
    {
        public CurrentEventPartialController(RestaurantContext context, PartialValidator partialvalidator) : base(context, partialvalidator)
        {
        }

        // GET: CurrentEventPartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.CurrentEventPartial.Include(c => c.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: CurrentEventPartial/Details/5
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

        // GET: CurrentEventPartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Title");
            return View();
        }

        // POST: CurrentEventPartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentEventPartial currentEventPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentEventPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", currentEventPartial.PartialId);
            return View(currentEventPartial);
        }

        // GET: CurrentEventPartial/Edit/5
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", currentEventPartial.PartialId);
            return View(currentEventPartial);
        }

        // POST: CurrentEventPartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] CurrentEventPartial currentEventPartial)
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", currentEventPartial.PartialId);
            return View(currentEventPartial);
        }

        // GET: CurrentEventPartial/Delete/5
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

        // POST: CurrentEventPartial/Delete/5
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
