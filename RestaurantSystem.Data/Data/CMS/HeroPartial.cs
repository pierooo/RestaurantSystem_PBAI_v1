using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class HeroPartial : EntityBase
{
    [Display(Name = "Tytuł 1 linia")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    public string? Title { get; set; }
    [Display(Name = "Tytuł 2 linia")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    [Display(Name = "Tytuł 3 linia")]
    public string? Content { get; set; }
    [Display(Name = "Zdjęcie")]
    public string? PhotoName { get; set; }
    [Display(Name = "Przycisk napis")]
    public string? HeroButtonName { get; set; }
    [Display(Name = "Adres url przycisku")]
    public string? HeroButtonUrl { get; set; }
    [Display(Name = "Tytuł wideo")]
    public string? VideoTitle { get; set; }
    [Display(Name = "Tytuł okna wideo")]
    public string? VideoModalTitle { get; set; }
    [Display(Name = "Komponent")]
    public int PartialId { get; set; }
    [Display(Name = "Komponent")]
    public Partial? Partial { get; set; }
}
