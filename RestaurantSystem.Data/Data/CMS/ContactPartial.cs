using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class ContactPartial : EntityBase
{
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    public string? Title { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    public string? Content { get; set; }

    [Display(Name = "Box lewy - Tytuł")]
    public string? CompanyDataTitle { get; set; }
    [Display(Name = "Box lewy - Treść")]
    public string? CompanyDataContent { get; set; }
    [Display(Name = "Box środek - Tytuł")]
    public string? ContactDataTitle { get; set; }
    [Display(Name = "Box środek - Treść")]
    public string? ContactDataContent { get; set; }
    [Display(Name = "Box prawy - Tytuł")]
    public string? PhoneDataTitle { get; set; }
    [Display(Name = "Box prawy - Treść")]
    public string? PhoneDataContent { get; set; }
    [Display(Name = "Texbox 1 - Treść")]
    public string? FormName { get; set; }
    [Display(Name = "Texbox 2 - Treść")]
    public string? FormEmail { get; set; }
    [Display(Name = "Texbox 3 - Treść")]
    public string? FormTitle { get; set; }
    [Display(Name = "Texbox 4 - Treść")]
    public string? FormContent { get; set; }
    [Display(Name = "Przycisk - Treść")]
    public string? FormButtonName { get; set; }
    [Display(Name = "Komponent")]
    public int PartialId { get; set; }
    public Partial? Partial { get; set; }
}
