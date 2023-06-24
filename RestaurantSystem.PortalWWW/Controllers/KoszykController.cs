using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Helpers;
using RestaurantSystem.PortalWWW.BusinessLogic;
using RestaurantSystem.PortalWWW.Models.Sklep;

namespace RestaurantSystem.PortalWWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly RestaurantContext context;
        public KoszykController(RestaurantContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.ModelCompany = await context.Company?.SingleOrDefaultAsync(x => x.IsActive) ?? new Company();
            var partialWithEventForLayout = await context.Partial.Include(p => p.CurrentEventPartials).FirstOrDefaultAsync(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive == true);

            ViewBag.Category = await context.Category.ToListAsync();

            KoszykB koszyk = new KoszykB(this.context, this.HttpContext);
            var daneDoKoszyka = new DaneDoKoszyka
            {
                ElementyKoszyka = await koszyk.GetElementyKoszyka(),
                Razem = await koszyk.GetRazem()
            };
            return View(daneDoKoszyka);
        }
        public async Task<ActionResult> DodajDoKoszyka(int id)
        {
            KoszykB koszyk = new KoszykB(this.context, this.HttpContext);
            koszyk.DodajDoKoszyka(await context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }

    }

}
