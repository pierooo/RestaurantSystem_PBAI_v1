using RestaurantSystem.Data.Data.CMS;

namespace RestaurantSystem.PortalWWW.Models;

public class MenuPartialWithMenu
{
    public CurrentMenuPartial CurrentMenuPartial { get; set; }

    public Product Product { get; set; }

    public MenuPartialWithMenu(CurrentMenuPartial currentMenuPartial, Product product)
    {
        CurrentMenuPartial = currentMenuPartial;
        Product = product;
    }
}
