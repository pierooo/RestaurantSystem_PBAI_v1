using RestaurantSystem.Administracja.Models.CMS.Abstract;

namespace RestaurantSystem.Administracja.Models.CMS;

public class CurrentMenuPartial : PartialEntityBase
{
    public int? ProductId { get; set; }
    public List<Company>? Companies { get; set; }
}
