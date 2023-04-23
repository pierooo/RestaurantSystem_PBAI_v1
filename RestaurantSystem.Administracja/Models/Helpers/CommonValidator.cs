using RestaurantSystem.Data.Data;

namespace RestaurantSystem.Administracja.Models.Helpers;

public class CommonValidator
{
    public static void AssertCompanyState(RestaurantContext context, bool creationState)
    {
        if(context.Company.Any(x => x.IsActive) && creationState)
        {
            throw new ArgumentException("Tylko jedna pozycja może być aktywna w danym momencie. Zmień flagę aktywnej pozycji jesli chcesz ustawić te dane jako aktywne.");
        }
    }
}
