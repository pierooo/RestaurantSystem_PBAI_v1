using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Administracja.Models.CMS.Abstract;

namespace RestaurantSystem.Administracja.Models.CMS;

public class Company : EntityBase
{
    [MaxLength(250, ErrorMessage = "Nazwa może zawierać max 250 znaków")]
    [Display(Name = "Nazwa")]
    public string? Name { get; set; }
    [Display(Name = "Opis")]
    public string? Description { get; set; }
    [Display(Name = "Tytuł")]
    public string? WebsiteTitlePart { get; set; }
    [Display(Name = "Góra prawa - Tytuł")]
    public string? TopbarRightTitle { get; set; }
    [Display(Name = "Góra prawa - Treść")]
    public string? TopBarRightInfo { get; set; }
    [Display(Name = "Góra prawa - Zdjęcie")]
    public string? TopBarRightPhotoName { get; set; }
    [Display(Name = "Góra środek - Tytuł")]
    public string? TopbarCenterTitle { get; set; }
    [Display(Name = "Góra prawa - Zdjęcie")]
    public string? TopBarCenterPhotoName { get; set; }
    [Display(Name = "Góra lewa - Tytuł")]
    public string? TopbarLeftTitle { get; set; }
    [Display(Name = "Góra lewa - Treść")]
    public string? TopBarLeftInfo { get; set; }
    [Display(Name = "Góra prawa - Info")]
    public string? TopBarLeftPhotoName { get; set; }
    [Display(Name = "Stopka box - Tytuł")]
    public string? FooterLeftBoxTitle { get; set; }
    [Display(Name = "Stopka box - Zdjęcie")]
    public string? FooterLeftBoxPhotoName { get; set; }
    [Display(Name = "Stopka box - Treść")]
    public string? FooterLeftBoxDescription { get; set; }
    [Display(Name = "Stopka lewa - tytuł")]
    public string? FooterLeftInfoTitle { get; set; }
    [Display(Name = "Stopka lewa - Adres")]
    public string? FooterLeftInfoAddress { get; set; }
    [Display(Name = "Stopka lewa - Email")]
    public string? FooterLeftInfoEmail { get; set; }
    [Display(Name = "Stopka lewa - Nr tel.")]
    public string? FooterLeftInfoPhone { get; set; }
    [Display(Name = "Stopka lewa - Twitter link")]
    public string? FooterLeftInfoTwitterLink { get; set; }
    [Display(Name = "Stopka lewa - Facebook link")]
    public string? FooterLeftInfoFacebookLink { get; set; }
    [Display(Name = "Stopka lewa - Linkedin link")]
    public string? FooterLeftInfoLinkedinLink { get; set; }
    [Display(Name = "Stopka środek - Tytuł")]
    public string? FooterCenterInfoTitle { get; set; }
    [Display(Name = "Stopka prawa - Tytuł")]
    public string? FooterRightInfoTitle { get; set; }
    [Display(Name = "Stopka prawa - Treść")]
    public string? FooterRightInfoDescription { get; set; }
    [Display(Name = "Stopka prawa - Przycisk nazwa")]
    public string? FooterRightInfoButtonName { get; set; }
    [Display(Name = "Stopka prawa - Przycisk odnośnik")]
    public string? FooterRightInfoButtonUrl { get; set; }
    [Display(Name = "Stopka dół - Prawa autorskie")]
    public string? FooterBottom { get; set; }
    [Display(Name = "Widok bierzących wydarzeń")]
    public int? CurrentEventsPartialId { get; set; }
    [Display(Name = "Widok bierzących wydarzeń")]
    public CurrentEventPartial? CurrentEventPartial { get; set; }
    [Display(Name = "Widok kontaktu")]
    public int? ContactPartialId { get; set; }
    [Display(Name = "Widok kontaktu")]
    public ContactPartial? ContactPartial { get; set; }
}
