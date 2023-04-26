using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.CMS;

public class Product : EntityBase
{
    [MaxLength(50, ErrorMessage = "Nazwa może zawierać max 50 znaków")]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Ingredients { get; set; }
    public string? Allergens { get; set; }
    [Column(TypeName = "money")]
    public decimal? UnitPriceGross { get; set; }
    public decimal? VAT { get; set; }
    public string? PhotoName { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<CurrentMenuPartial>? CurrentMenuPartials { get; set; }
}
