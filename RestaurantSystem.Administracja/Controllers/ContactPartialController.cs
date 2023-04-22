using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Administracja.Data;
using RestaurantSystem.Administracja.Models.CMS;
using RestaurantSystem.Administracja.Models.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class ContactPartialController : BaseController
    {
        public ContactPartialController(RestaurantContext context, PartialValidator partialvalidator) : base(context, partialvalidator)
        {
        }

        // GET: ContactPartial
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.ContactPartial.Include(c => c.Partial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: ContactPartial/Details/5
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

        // GET: ContactPartial/Create
        public IActionResult Create()
        {
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id");
            return View();
        }

        // POST: ContactPartial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyDataTitle,CompanyDataContent,ContactDataTitle,ContactDataContent,PhoneDataTitle,PhoneDataContent,FormName,FormEmail,FormTitle,FormContent,FormButtonName,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ContactPartial contactPartial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactPartial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", contactPartial.PartialId);
            return View(contactPartial);
        }

        // GET: ContactPartial/Edit/5
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
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", contactPartial.PartialId);
            return View(contactPartial);
        }

        // POST: ContactPartial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyDataTitle,CompanyDataContent,ContactDataTitle,ContactDataContent,PhoneDataTitle,PhoneDataContent,FormName,FormEmail,FormTitle,FormContent,FormButtonName,Title,SubTitle,Content,PartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] ContactPartial contactPartial)
        {
            if (id != contactPartial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactPartial);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartialId"] = new SelectList(_context.Set<Partial>(), "Id", "Id", contactPartial.PartialId);
            return View(contactPartial);
        }

        // GET: ContactPartial/Delete/5
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

        // POST: ContactPartial/Delete/5
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
