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
    public class CompanyController : Controller
    {
        private readonly RestaurantContext _context;

        public CompanyController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Company.Include(c => c.ContactPartial);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.ContactPartial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            ViewData["ContactPartialId"] = new SelectList(_context.ContactPartial, "Id", "Discriminator");
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,WebsiteTitlePart,TopbarRightTitle,TopBarRightInfo,TopBarRightPhotoName,TopbarCenterTitle,TopBarCenterPhotoName,TopbarLeftTitle,TopBarLeftInfo,TopBarLeftPhotoName,FooterLeftBoxTitle,FooterLeftBoxPhotoName,FooterLeftBoxDescription,FooterLeftInfoTitle,FooterLeftInfoAddress,FooterLeftInfoEmail,FooterLeftInfoPhone,FooterLeftInfoTwitterLink,FooterLeftInfoFacebookLink,FooterLeftInfoLinkedinLink,FooterCenterInfoTitle,FooterRightInfoTitle,FooterRightInfoDescription,FooterRightInfoButtonName,FooterRightInfoButtonUrl,FooterBottom,CurrentEventsPartialId,ContactPartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactPartialId"] = new SelectList(_context.ContactPartial, "Id", "Discriminator", company.ContactPartialId);
            return View(company);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["ContactPartialId"] = new SelectList(_context.ContactPartial, "Id", "Discriminator", company.ContactPartialId);
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,WebsiteTitlePart,TopbarRightTitle,TopBarRightInfo,TopBarRightPhotoName,TopbarCenterTitle,TopBarCenterPhotoName,TopbarLeftTitle,TopBarLeftInfo,TopBarLeftPhotoName,FooterLeftBoxTitle,FooterLeftBoxPhotoName,FooterLeftBoxDescription,FooterLeftInfoTitle,FooterLeftInfoAddress,FooterLeftInfoEmail,FooterLeftInfoPhone,FooterLeftInfoTwitterLink,FooterLeftInfoFacebookLink,FooterLeftInfoLinkedinLink,FooterCenterInfoTitle,FooterRightInfoTitle,FooterRightInfoDescription,FooterRightInfoButtonName,FooterRightInfoButtonUrl,FooterBottom,CurrentEventsPartialId,ContactPartialId,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            ViewData["ContactPartialId"] = new SelectList(_context.ContactPartial, "Id", "Discriminator", company.ContactPartialId);
            return View(company);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.ContactPartial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'RestaurantContext.Company'  is null.");
            }
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
