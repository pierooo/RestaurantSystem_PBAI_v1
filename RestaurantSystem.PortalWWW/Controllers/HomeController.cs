using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Data.CMS.Abstract;
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

        public IActionResult Index(int? id)
        {
            ViewBag.ModelCompany = context.Company.Single(x => x.IsActive);
            ViewBag.ModelPage = context.Page.Where(x => x.IsActive).OrderBy(x => x.Position).ToList();

            if (id == null)
            {
                id = context.Page.First().Id;
            }

            var page = context.Page.Find(id);

            var partials = context.Partial.Where(x => x.PageId == page.Id).ToList();

            return View(new PageWithPartials(page, partials));
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