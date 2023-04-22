using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Data;
using RestaurantSystem.Administracja.Models.CMS;

namespace RestaurantSystem.Administracja.Controllers
{
    public class AboutPartialController : Controller
    {
        private readonly RestaurantContext _context;

        public AboutPartialController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: AboutPartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.AboutPartial.Include(a => a.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: AboutPartial/Details/5
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

        // GET: AboutPartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id");
            return View();
        }

        // POST: AboutPartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoName,RightTitle,RightContent,RightPhotoName,LeftTitle,LeftContent,LeftPhotoName,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] AboutPartial aboutPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", aboutPartial.PartialId);
            return View(aboutPartial);
        }

        // GET: AboutPartial/Edit/5
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", aboutPartial.PartialId);
            return View(aboutPartial);
        }

        // POST: AboutPartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoName,RightTitle,RightContent,RightPhotoName,LeftTitle,LeftContent,LeftPhotoName,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] AboutPartial aboutPartial)
        {
            if (id != aboutPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutPartial);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", aboutPartial.PartialId);
            return View(aboutPartial);
        }

        // GET: AboutPartial/Delete/5
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

        // POST: AboutPartial/Delete/5
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
