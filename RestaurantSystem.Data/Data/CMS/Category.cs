using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Category : EntityBase
{
    [Display(Name = "Nazwa")]
    [MaxLength(50, ErrorMessage = "Nazwa może zawierać max 50 znaków")]
    public string? Name { get; set; }

    [Display(Name = "Opis")]
    public string? Description { get; set; }
    public string? PhotoName { get; set; }
    public List<Product>? Products { get; set; }
}
