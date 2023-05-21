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

            ViewBag.Category = await context.Category.ToListAsync(); // przez viewBag przekazujemy z kontrollera do widoku wszystkie rodzaje

            // przy pierwszym wejściu do sklepu Id kategorii jest puste więc wyświetlamy pierwszą kategorię, tak żeby przy pierwszym wejściu do sklepu wyświetlały się towary pierwszej kategorii (potem będą promowane)
            if (id == null)
            {
                var result = await context.Category.FirstAsync();
                id = result.Id;
            }
            // do widoku przekazujemy wszystkie towary danego klikniętego rodzaju lub w przypadku pierwszego wejścia do sklepu wszystkie towary pierwszej kategorii

            return View(await context.Product.Where(x => x.CategoryId == id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id) // w parametrze Id będzie przechowywana Id klikniętego towaru którego szcxzegółyt mamy wyświetlić
        {
            ViewBag.ModelCompany = await context.Company?.SingleOrDefaultAsync(x => x.IsActive) ?? new Company();
            var partialWithEventForLayout = await context.Partial.Include(p => p.CurrentEventPartials).FirstOrDefaultAsync(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive == true);
            ViewBag.Category = await context.Category.ToListAsync(); // przez viewBag przekazujemy z kontrollera do widoku wszystkie rodzaje

            return View(await context.Product.SingleOrDefaultAsync(x => x.Id == id));
        }
    }
}
