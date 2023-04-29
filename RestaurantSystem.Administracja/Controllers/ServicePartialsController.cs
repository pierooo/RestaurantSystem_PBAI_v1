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
    public class ServicePartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public ServicePartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: ServicePartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.ServicePartial.Include(s => s.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: ServicePartials/Details/5
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

        // GET: ServicePartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Service), "Id", "Name");
            return View();
        }

        // POST: ServicePartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ServicePartial servicePartial)
        {
            try
            {
                PartialValidator.ValidatePartialForNewItem(_context, servicePartial.PartialId);
                if (ModelState.IsValid)
                {
                    _context.Add(servicePartial);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania elementu: " + ex.Message);
            }

            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Service), "Id", "Name", servicePartial.PartialId);
            return View(servicePartial);
        }

        // GET: ServicePartials/Edit/5
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
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Service), "Id", "Name", servicePartial.PartialId);
            return View(servicePartial);
        }

        // POST: ServicePartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,PhotoName,EventDate,EventInfo,FacebookLink,LinkedinLink,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ServicePartial servicePartial)
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
                    return RedirectToAction(nameof(Index));
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
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania elementu: " + ex.Message);
                }
            }
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Service), "Id", "Name", servicePartial.PartialId);
            return View(servicePartial);
        }

        // GET: ServicePartials/Delete/5
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

        // POST: ServicePartials/Delete/5
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
