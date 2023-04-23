using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class HeroPartial : PartialEntityBase
{
    public string? PhotoName { get; set; }
    public string? HeroButtonName { get; set; }
    public string? HeroButtonUrl { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoModalTitle { get; set; }
}
