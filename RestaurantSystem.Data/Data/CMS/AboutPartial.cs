using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class AboutPartial : PartialEntityBase
{
    public string? PhotoName { get; set; }
    public string? RightTitle { get; set; }
    public string? RightContent { get; set; }
    public string? RightPhotoName { get; set; }
    public string? LeftTitle { get; set; }
    public string? LeftContent { get; set; }
    public string? LeftPhotoName { get; set; }
}
