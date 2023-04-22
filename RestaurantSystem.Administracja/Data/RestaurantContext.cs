using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Models.CMS;

namespace RestaurantSystem.Administracja.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext (DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.Category> Category { get; set; } = default!;

        public DbSet<RestaurantSystem.Administracja.Models.CMS.Product>? Product { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.Account>? Account { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.AboutPartial>? AboutPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.ContactPartial>? ContactPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.CurrentEventPartial>? CurrentEventPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.CurrentMenuPartial>? CurrentMenuPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.FactPartial>? FactPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.HeroPartial>? HeroPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.OpinionPartial>? OpinionPartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.ServicePartial>? ServicePartial { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.Page>? Page { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.Company>? Company { get; set; }

        public DbSet<RestaurantSystem.Administracja.Models.CMS.Partial>? Partial { get; set; }
    }
}
