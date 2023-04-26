using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Partial : EntityBase
{
    [Display(Name = "Nazwa komponentu")]
    public string? Name { get; set; }
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    [Display(Name = "Tytuł komponentu")]
    public string? Title { get; set; }
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    public string? Content { get; set; }
    public bool? IsForMainPage { get; set; }
    public string? PartialType { get; set; }
    public string? PartialButtonName { get; set; }
    public string? PartialButtonUrl { get; set; }
    public int? Position { get; set; }
    public int PageId { get; set; }
    public Page? Page { get; set; }
    public List<AboutPartial>? AboutPartials { get; set; }
    public List<ContactPartial>? ContactPartials { get; set; }
    public List<CurrentEventPartial>? CurrentEventPartials { get; set; }
    public List<CurrentMenuPartial>? CurrentMenuPartials { get; set; }
    public List<FactPartial>? FactPartials { get; set; }
    public List<HeroPartial>? HeroPartials { get; set; }
    public List<OpinionPartial>? OpinionPartials { get; set; }
    public List<ServicePartial>? ServicePartials { get; set; }
}
