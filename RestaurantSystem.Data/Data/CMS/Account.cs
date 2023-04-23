using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Account : EntityBase
{
    [MaxLength(150, ErrorMessage = "Tytuł może zawierać max 150 znaków")]
    [Display(Name = "Nazwisko")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Imię jest wymagana")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    [Display(Name = "Imię")]
    public string? FirstName { get; set; }

    [Display(Name = "Notatki")]

    public string? Notes { get; set; }
    [MaxLength(150, ErrorMessage = "Login może zawierać max 150 znaków")]
    [Display(Name = "Login")]
    public string? Username { get; set; }

    [Display(Name = "Hasło")]
    public string? Password { get; set; }
    public string? Salt { get; set; }

    [Display(Name = "Konto pracownika")]
    public bool IsEmployee { get; set; } = false;
}
