using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Product : EntityBase
{
    [Display(Name = "Nazwa")]
    [MaxLength(50, ErrorMessage = "Nazwa może zawierać max 50 znaków")]
    public string? Name { get; set; }
    [Display(Name = "Opis")]
    public string? Description { get; set; }
    [Display(Name = "Składniki")]
    public string? Ingredients { get; set; }
    [Display(Name = "Alergeny")]
    public string? Allergens { get; set; }
    [Display(Name = "Cena brutto")]
    public decimal? UnitPriceGross { get; set; }
    [Display(Name = "VAT")]
    public decimal? VAT { get; set; }
    [Display(Name = "Zdjęcie")]
    public string? PhotoName { get; set; }
    [Display(Name = "Kategoria")]
    public int? CategoryId { get; set; }
    [Display(Name = "Kategoria")]
    public Category? Category { get; set; }
    public List<CurrentMenuPartial>? CurrentMenuPartials { get; set; }
}
