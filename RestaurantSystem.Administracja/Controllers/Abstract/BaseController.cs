using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Helpers;

namespace RestaurantSystem.Administracja.Controllers.Abstract;

public class BaseController : Controller
{
    protected readonly RestaurantContext _context;
    protected readonly PartialValidator partialvalidator;

    public BaseController(RestaurantContext context, PartialValidator partialvalidator)
    {
        this._context = context;
        this.partialvalidator = partialvalidator;
    }
}
