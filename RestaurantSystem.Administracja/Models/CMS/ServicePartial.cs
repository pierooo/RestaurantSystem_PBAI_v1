using RestaurantSystem.Administracja.Models.CMS.Abstract;

namespace RestaurantSystem.Administracja.Models.CMS;

public class ServicePartial : PartialEntityBase
{
    public string? PhotoName { get; set; }
    public DateTime? EventDate { get; set; }
    public string? EventInfo { get; set; }
    public string? FacebookLink { get; set; }
    public string? LinkedinLink { get; set; }
}
