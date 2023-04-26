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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestaurantSystem.Administracja.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly RestaurantContext _context;

        public CompaniesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return _context.Company != null ?
                        View(await _context.Company.ToListAsync()) :
                        Problem("Entity set 'RestaurantContext.Company'  is null.");
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,WebsiteTitlePart,TopbarRightTitle,TopBarRightInfo,TopBarRightPhotoName,TopbarCenterTitle,TopBarCenterPhotoName,TopbarLeftTitle,TopBarLeftInfo,TopBarLeftPhotoName,FooterLeftBoxTitle,FooterLeftBoxPhotoName,FooterLeftBoxDescription,FooterLeftInfoTitle,FooterLeftInfoAddress,FooterLeftInfoEmail,FooterLeftInfoPhone,FooterLeftInfoTwitterLink,FooterLeftInfoFacebookLink,FooterLeftInfoLinkedinLink,FooterCenterInfoTitle,FooterRightInfoTitle,FooterRightInfoDescription,FooterRightInfoButtonName,FooterRightInfoButtonUrl,FooterBottom,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] Company company)
        {
            try
            {
                CommonValidator.AssertCompanyState(_context, company.IsActive);

                if (ModelState.IsValid)
                {
                    _context.Add(company);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(company);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania elementu: " + ex.Message);
                return View(company);
            }
        }

        // GET: Companies/Edit/5
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
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,WebsiteTitlePart,TopbarRightTitle,TopBarRightInfo,TopBarRightPhotoName,TopbarCenterTitle,TopBarCenterPhotoName,TopbarLeftTitle,TopBarLeftInfo,TopBarLeftPhotoName,FooterLeftBoxTitle,FooterLeftBoxPhotoName,FooterLeftBoxDescription,FooterLeftInfoTitle,FooterLeftInfoAddress,FooterLeftInfoEmail,FooterLeftInfoPhone,FooterLeftInfoTwitterLink,FooterLeftInfoFacebookLink,FooterLeftInfoLinkedinLink,FooterCenterInfoTitle,FooterRightInfoTitle,FooterRightInfoDescription,FooterRightInfoButtonName,FooterRightInfoButtonUrl,FooterBottom,Id,IsActive,CreatedAt,UpdatedAt,UpdatedById")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CommonValidator.AssertCompanyState(_context, company.IsActive);
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
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
                catch(ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas dodawania elementu: " + ex.Message);
                }
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
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
