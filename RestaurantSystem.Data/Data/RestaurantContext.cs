using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data.Sklep;

namespace RestaurantSystem.Data.Data;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public DbSet<RestaurantSystem.Data.Data.CMS.Category> Category { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.Product>? Product { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.Account>? Account { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.AboutPartial>? AboutPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.ContactPartial>? ContactPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.CurrentEventPartial>? CurrentEventPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.CurrentMenuPartial>? CurrentMenuPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.FactPartial>? FactPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.HeroPartial>? HeroPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.OpinionPartial>? OpinionPartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.ServicePartial>? ServicePartial { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.Page>? Page { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.Company>? Company { get; set; }

    public DbSet<RestaurantSystem.Data.Data.CMS.Partial>? Partial { get; set; }

    public DbSet<CartItem> CartItem { get; set; }
}
