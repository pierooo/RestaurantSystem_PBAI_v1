using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class HeroPartial : EntityBase
{
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    public string? Title { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    public string? Content { get; set; }
    [Display(Name = "Komponent")]
    public string? PhotoName { get; set; }
    public string? HeroButtonName { get; set; }
    public string? HeroButtonUrl { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoModalTitle { get; set; }
    [Display(Name = "Komponent")]
    public int PartialId { get; set; }
    public Partial? Partial { get; set; }
}
