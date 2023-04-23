using RestaurantSystem.Data.Data.CMS;

namespace RestaurantSystem.PortalWWW.Models;

public class PageWithPartials
{
    public Page Page { get; set; }

    public List<Partial>? Partials { get; set; }

    public PageWithPartials(Page page, List<Partial> partials)
    {
        this.Page = page;
        this.Partials = partials;
    }
}
