using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class CurrentEventPartial : EntityBase
{
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
    public string? Title { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    public string? Content { get; set; }
    [Display(Name = "Zdjęcie")]
    public string? PhotoName { get; set; }
    [Display(Name = "Data wydarzenia")]
    public DateTime? EventDate { get; set; }
    [Display(Name = "Krótki opis")]
    public string? EventInfo { get; set; }
    [Display(Name = "Link wydarzenia- Facebook")]
    public string? FacebookLink { get; set; }
    [Display(Name = "Link wydarzenia- Linkedin")]
    public string? LinkedinLink { get; set; }
    [Required(ErrorMessage = "Komponent musi być wybrany")]
    [Display(Name = "Komponent")]
    public int PartialId { get; set; }
    [Display(Name = "Komponent")]
    public Partial? Partial { get; set; }
}
