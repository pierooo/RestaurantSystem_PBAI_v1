using System.ComponentModel.DataAnnotations;

namespace RestaurantSystem.Administracja.Models.CMS.Abstract;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "Aktywne")]
    public bool IsActive { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedById { get; set; }
}
