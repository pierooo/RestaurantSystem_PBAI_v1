﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
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
            ViewBag.ModelCompany = await context.Company.SingleOrDefaultAsync(x => x.IsActive);
            ViewBag.ModelLayoutEvents = await context.Partial.Include(p => p.CurrentEventPartials).FirstOrDefaultAsync(x => x.IsForMainPage == true) ?? new Partial();
            ViewBag.ModelPage = await context.Page.Where(x => x.IsActive).OrderBy(x => x.Position).ToListAsync();

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