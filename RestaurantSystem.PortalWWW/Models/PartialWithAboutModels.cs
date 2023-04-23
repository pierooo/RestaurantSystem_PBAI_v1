using RestaurantSystem.Data.Data.CMS;

namespace RestaurantSystem.PortalWWW.Models;

public class PartialWithAboutModels
{
    public Partial Partial { get; set; }
    public List<AboutPartial> AboutPartials { get; set; }

    public PartialWithAboutModels(Partial partial, List<AboutPartial> aboutPartials)
    {
        this.Partial = partial;
        this.AboutPartials = aboutPartials;
    }
}
