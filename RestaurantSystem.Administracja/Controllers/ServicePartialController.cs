using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Administracja.Data;
using RestaurantSystem.Administracja.Models.CMS;
using RestaurantSystem.Administracja.Models.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class ServicePartialController : BaseController
    {
        public ServicePartialController(RestaurantContext context, PartialValidator partialvalidator) : base(context, partialvalidator)
        {
        }

        // GET: ServicePartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.ServicePartial.Include(s => s.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: ServicePartial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicePartial == null)
            {
                return NotFound();
            }

            var servicePartial = await _context.ServicePartial
                .Include(s => s.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicePartial == null)
            {
                return NotFound();
            }

            return View(servicePartial);
        }

        // GET: ServicePartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id");
            return View();
        }

        // POST: ServicePartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ServicePartial servicePartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicePartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", servicePartial.PartialId);
            return View(servicePartial);
        }

        // GET: ServicePartial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicePartial == null)
            {
                return NotFound();
            }

            var servicePartial = await _context.ServicePartial.FindAsync(id);
            if (servicePartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", servicePartial.PartialId);
            return View(servicePartial);
        }

        // POST: ServicePartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ServicePartial servicePartial)
        {
            if (id != servicePartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePartial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePartialExists(servicePartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", servicePartial.PartialId);
            return View(servicePartial);
        }

        // GET: ServicePartial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicePartial == null)
            {
                return NotFound();
            }

            var servicePartial = await _context.ServicePartial
                .Include(s => s.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicePartial == null)
            {
                return NotFound();
            }

            return View(servicePartial);
        }

        // POST: ServicePartial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicePartial == null)
            {
                return Problem("Entity set 'RestaurantContext.ServicePartial'  is null.");
            }
            var servicePartial = await _context.ServicePartial.FindAsync(id);
            if (servicePartial != null)
            {
                _context.ServicePartial.Remove(servicePartial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicePartialExists(int id)
        {
            return (_context.ServicePartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
