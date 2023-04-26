using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Page : EntityBase
{
    [Display(Name = "Tytuł")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 150 znaków")]
    public string? Title { get; set; }
    [Display(Name = "Link tytuł")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? LinkTitle { get; set; }
    [Display(Name = "Treść")]
    public string? Content { get; set; }
    [Display(Name = "Pozycja")]
    public int? Position { get; set; }
    public bool IsContactPage { get; set; }
    public bool IsIndexPage { get; set; }
    public List<Partial>? Partials { get; set; }
}
