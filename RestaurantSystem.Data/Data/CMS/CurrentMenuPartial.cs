using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class CurrentMenuPartial : PartialEntityBase
{
    public int? ProductId { get; set; }
    public List<Company>? Companies { get; set; }
}
