using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class ServicePartial : PartialEntityBase
{
    public string? PhotoName { get; set; }
    public DateTime? EventDate { get; set; }
    public string? EventInfo { get; set; }
    public string? FacebookLink { get; set; }
    public string? LinkedinLink { get; set; }
}
