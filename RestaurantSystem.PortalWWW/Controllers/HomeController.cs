#nullable enable
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Helpers;
using RestaurantSystem.PortalWWW.Models;

namespace RestaurantSystem.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, RestaurantContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelCompany = await context.Company?.SingleOrDefaultAsync(x => x.IsActive) ?? new Company();
            ViewBag.ModelPage = await context.Page?.Where(x => x.IsActive)?.OrderBy(x => x.Position)?.ToListAsync();
            var partialWithEventForLayout = await context.Partial.Include(p => p.CurrentEventPartials).FirstOrDefaultAsync(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive == true);
            ViewBag.ModelLayoutEvents = partialWithEventForLayout?.CurrentEventPartials.OrderBy(x => x.EventDate).ToList();

            if (id == null)
            {
                var firstPage = await context.Page.FirstAsync<Page>();
                id = firstPage.Id;
            }

            var page = await context.Page
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.AboutPartials)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.ContactPartials)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.CurrentEventPartials)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.CurrentMenuPartials)
                        .ThenInclude(cm => cm.Product)
                            .ThenInclude(pr => pr.Category)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.FactPartials)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.HeroPartials)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.OpinionPartials)
                .Include(p => p.Partials.OrderBy(y => y.Position))
                    .ThenInclude(pt => pt.ServicePartials)
                .FirstOrDefaultAsync(x => x.Id == id);

            page?.Partials?.RemoveAll(x => x.PartialType == PartialTypes.LayoutEvents);

            page = new Page()
            {
                Content = page.Content,
                CreatedAt = page.CreatedAt,
                UpdatedAt = page.UpdatedAt,
                IsContactPage = page.IsContactPage,
                IsIndexPage = page.IsIndexPage,
                IsActive = page.IsActive,
                Title = page.Title,
                LinkTitle = page.LinkTitle,
                Position = page.Position,
                Id = page.Id,
                UpdatedById = page.UpdatedById,
                Partials = page?.Partials?.OrderBy(x => x.Position).ToList()
            };

            return View(page);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}