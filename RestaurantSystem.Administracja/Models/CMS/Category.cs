using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Administracja.Models.CMS.Abstract;

namespace RestaurantSystem.Administracja.Models.CMS;

public class Category : EntityBase
{
    [MaxLength(50, ErrorMessage = "Nazwa może zawierać max 50 znaków")]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoName { get; set; }
    public List<Product>? Products { get; set; }
}
