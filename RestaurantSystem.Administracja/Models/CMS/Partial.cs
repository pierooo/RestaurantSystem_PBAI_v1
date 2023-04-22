using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Administracja.Models.CMS.Abstract;

namespace RestaurantSystem.Administracja.Models.CMS;

public class Partial : EntityBase
{
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    [Display(Name = "Nazwa komponentu")]
    public string? Title { get; set; }
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    public string? Content { get; set; }
    public bool? IsForMainPage { get; set; }
    public string? PartialType { get; set; }
    public string? PartialButtonName { get; set; }
    public string? PartialButtonUrl { get; set; }
    public int? PageId { get; set; }
    public Page? Page { get; set; }
    public List<PartialEntityBase>? PartialEntityBases { get; set; }
}
