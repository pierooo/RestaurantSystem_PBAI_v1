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
    public class ContactPartialsController : Controller
    {
        private readonly RestaurantContext _context;

        public ContactPartialsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: ContactPartials
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.ContactPartial.Include(c => c.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: ContactPartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactPartial == null)
            {
                return NotFound();
            }

            var contactPartial = await _context.ContactPartial
                .Include(c => c.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPartial == null)
            {
                return NotFound();
            }

            return View(contactPartial);
        }

        // GET: ContactPartials/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Contact), "Id", "Name");
            return View();
        }

        // POST: ContactPartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,Content,CompanyDataTitle,CompanyDataContent,ContactDataTitle,ContactDataContent,PhoneDataTitle,PhoneDataContent,FormName,FormEmail,FormTitle,FormContent,FormButtonName,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ContactPartial contactPartial)
        {
            try
            {
                PartialValidator.ValidatePartialForNewItem(_context, contactPartial.PartialId);
                if (ModelState.IsValid)
                {
                    _context.Add(contactPartial);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania elementu: " + ex.Message);
            }
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Contact), "Id", "Name", contactPartial.PartialId);
            return View(contactPartial);
        }

        // GET: ContactPartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactPartial == null)
            {
                return NotFound();
            }

            var contactPartial = await _context.ContactPartial.FindAsync(id);
            if (contactPartial == null)
            {
                return NotFound();
            }
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Contact), "Id", "Name", contactPartial.PartialId);
            return View(contactPartial);
        }

        // POST: ContactPartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,SubTitle,Content,CompanyDataTitle,CompanyDataContent,ContactDataTitle,ContactDataContent,PhoneDataTitle,PhoneDataContent,FormName,FormEmail,FormTitle,FormContent,FormButtonName,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ContactPartial contactPartial)
        {
            if (id != contactPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PartialValidator.ValidatePartialForNewItem(_context, contactPartial.PartialId);
                    _context.Update(contactPartial);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactPartialExists(contactPartial.Id))
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
            ViewData["PartialId"] = new SelectList(_context.Partial.Where(x => x.PartialType == PartialTypes.Contact), "Id", "Name", contactPartial.PartialId);
            return View(contactPartial);
        }

        // GET: ContactPartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactPartial == null)
            {
                return NotFound();
            }

            var contactPartial = await _context.ContactPartial
                .Include(c => c.Partial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPartial == null)
            {
                return NotFound();
            }

            return View(contactPartial);
        }

        // POST: ContactPartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactPartial == null)
            {
                return Problem("Entity set 'RestaurantContext.ContactPartial'  is null.");
            }
            var contactPartial = await _context.ContactPartial.FindAsync(id);
            if (contactPartial != null)
            {
                _context.ContactPartial.Remove(contactPartial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactPartialExists(int id)
        {
          return (_context.ContactPartial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
