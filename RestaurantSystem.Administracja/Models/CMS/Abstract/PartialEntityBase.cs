﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestaurantSystem.Administracja.Models.CMS.Abstract;

public abstract class PartialEntityBase : EntityBase
{
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")] 
    public string? Title { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    [MaxLength(150, ErrorMessage = "Sub tytuł może zawierać max 150 znaków")]
    public string? SubTitle { get; set; }
    [Display(Name = "Podaj jeśli widok tego wymaga")]
    public string? Content { get; set; }
    [Display(Name = "Częściowy widok do którego będzie należeć tworzona pozycja")]
    public int? PartialId { get; set; }
    public Partial? Partial { get; set; }
}
