using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class AboutPartial : EntityBase
{
    [Display(Name = "Nazwa")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    public string? Title { get; set; }
    [Display(Name = "Tytuł")]
    [MaxLength(150, ErrorMessage = "Tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    [Display(Name = "Treść")]
    public string? Content { get; set; }
    [Display(Name = "Zdjęcie")]
    public string? PhotoName { get; set; }
    [Display(Name = "Tytuł- prawa")]
    public string? RightTitle { get; set; }
    [Display(Name = "Treść- prawa")]
    public string? RightContent { get; set; }
    public string? RightPhotoName { get; set; }
    [Display(Name = "Tytuł- lewa")]
    public string? LeftTitle { get; set; }
    [Display(Name = "Treść- lewa")]
    public string? LeftContent { get; set; }
    public string? LeftPhotoName { get; set; }
    [Display(Name = "Komponent")]
    public int PartialId { get; set; }
    [Display(Name = "Komponent")]
    public Partial? Partial { get; set; }
}
