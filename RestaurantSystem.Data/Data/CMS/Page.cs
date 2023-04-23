using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Page : EntityBase
{
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 150 znaków")]
    public string? Title { get; set; }
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? LinkTitle { get; set; }
    public string? Content { get; set; }
    public int? Position { get; set; }
    public bool IsContactPage { get; set; }
    public bool IsIndexPage { get; set; }
    public List<Partial>? Partials { get; set; }
}
