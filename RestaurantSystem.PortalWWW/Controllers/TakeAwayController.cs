using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Helpers;

namespace RestaurantSystem.PortalWWW.Controllers
{
    public class TakeAwayController : Controller
    {
        private readonly RestaurantContext context;

        public TakeAwayController(RestaurantContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelCompany = await context.Company?.SingleOrDefaultAsync(x => x.IsActive) ?? new Company();
            var partialWithEventForLayout = await context.Partial.Include(p => p.CurrentEventPartials).FirstOrDefaultAsync(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive == true);

            ViewBag.Category = await context.Category.ToListAsync();

            if (id == null)
            {
                return View(await context.Product.Where(x => x.IsActive).ToListAsync());
            }

            return View(await context.Product.Where(x => x.CategoryId == id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.ModelCompany = await context.Company?.SingleOrDefaultAsync(x => x.IsActive) ?? new Company();
            var partialWithEventForLayout = await context.Partial.Include(p => p.CurrentEventPartials).FirstOrDefaultAsync(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive == true);
            ViewBag.Category = await context.Category.ToListAsync();

            return View(await context.Product.SingleOrDefaultAsync(x => x.Id == id));
        }
    }
}
