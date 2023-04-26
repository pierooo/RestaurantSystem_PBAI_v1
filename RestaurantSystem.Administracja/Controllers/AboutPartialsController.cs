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
    public class AboutPartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public AboutPartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: AboutPartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.AboutPartial.Include(a => a.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: AboutPartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AboutPartial == null)
            {
                return NotFound();
            }

            var aboutPartial = await _context.AboutPartial
                .Include(a => a.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutPartial == null)
            {
                return NotFound();
            }

            return View(aboutPartial);
        }

        // GET: AboutPartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.About), "Id", "Name");
            return View();
        }

        // POST: AboutPartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,PhotoName,RightTitle,RightContent,RightPhotoName,LeftTitle,LeftContent,LeftPhotoName,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] AboutPartial aboutPartial)
        {
            try
            {
                PartialValidator.ValidatePartialForNewItem(_context, aboutPartial.PartialId);
                if (ModelState.IsValid)
                {
                    _context.Add(aboutPartial);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania elementu: " + ex.Message);
            }

            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.About), "Id", "Name", aboutPartial.PartialId);
            return View(aboutPartial);
        }

        // GET: AboutPartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AboutPartial == null)
            {
                return NotFound();
            }

            var aboutPartial = await _context.AboutPartial.FindAsync(id);
            if (aboutPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.About), "Id", "Name", aboutPartial.PartialId);
            return View(aboutPartial);
        }

        // POST: AboutPartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,PhotoName,RightTitle,RightContent,RightPhotoName,LeftTitle,LeftContent,LeftPhotoName,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] AboutPartial aboutPartial)
        {
            if (id != aboutPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PartialValidator.ValidatePartialForNewItem(_context, aboutPartial.PartialId);
                    _context.Update(aboutPartial);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutPartialExists(aboutPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.About), "Id", "Name", aboutPartial.PartialId);
            return View(aboutPartial);
        }

        // GET: AboutPartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AboutPartial == null)
            {
                return NotFound();
            }

            var aboutPartial = await _context.AboutPartial
                .Include(a => a.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutPartial == null)
            {
                return NotFound();
            }

            return View(aboutPartial);
        }

        // POST: AboutPartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AboutPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.AboutPartial'  is null.");
            }
            var aboutPartial = await _context.AboutPartial.FindAsync(id);
            if (aboutPartial != null)
            {
                _context.AboutPartial.Remove(aboutPartial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutPartialExists(int id)
        {
          return (_context.AboutPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
