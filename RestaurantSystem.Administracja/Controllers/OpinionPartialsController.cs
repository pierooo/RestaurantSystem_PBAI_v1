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
    public class OpinionPartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public OpinionPartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: OpinionPartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.OpinionPartial.Include(o => o.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: OpinionPartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OpinionPartial == null)
            {
                return NotFound();
            }

            var opinionPartial = await _context.OpinionPartial
                .Include(o => o.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opinionPartial == null)
            {
                return NotFound();
            }

            return View(opinionPartial);
        }

        // GET: OpinionPartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id");
            return View();
        }

        // POST: OpinionPartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,Date,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] OpinionPartial opinionPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opinionPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", opinionPartial.PartialId);
            return View(opinionPartial);
        }

        // GET: OpinionPartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OpinionPartial == null)
            {
                return NotFound();
            }

            var opinionPartial = await _context.OpinionPartial.FindAsync(id);
            if (opinionPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", opinionPartial.PartialId);
            return View(opinionPartial);
        }

        // POST: OpinionPartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,Date,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] OpinionPartial opinionPartial)
        {
            if (id != opinionPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinionPartial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpinionPartialExists(opinionPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Partial, "Id", "Id", opinionPartial.PartialId);
            return View(opinionPartial);
        }

        // GET: OpinionPartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OpinionPartial == null)
            {
                return NotFound();
            }

            var opinionPartial = await _context.OpinionPartial
                .Include(o => o.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opinionPartial == null)
            {
                return NotFound();
            }

            return View(opinionPartial);
        }

        // POST: OpinionPartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OpinionPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.OpinionPartial'  is null.");
            }
            var opinionPartial = await _context.OpinionPartial.FindAsync(id);
            if (opinionPartial != null)
            {
                _context.OpinionPartial.Remove(opinionPartial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinionPartialExists(int id)
        {
          return (_context.OpinionPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
