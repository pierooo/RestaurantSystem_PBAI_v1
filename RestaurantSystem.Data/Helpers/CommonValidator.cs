using RestaurantSystem.Data.Data;

namespace RestaurantSystem.Data.Helpers;

public class CommonValidator
{
    public static void AssertCompanyState(RestaurantContext context, bool creationState)
    {
        if (context.Company.Any(x => x.IsActive) && creationState)
        {
            throw new ArgumentException("Tylko jedna pozycja może być aktywna w danym momencie. Zmień flagę aktywnej pozycji jesli chcesz ustawić te dane jako aktywne.");
        }
    }

    public static void AssertLayoutPartial(RestaurantContext context, bool creationState)
    {
        var state = context.Partial.FirstOrDefault(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive);
        if (state != null && creationState == true)
        {
            throw new ArgumentException($"Tylko jedna pozycja wydarzeń dla wszystkich stron może być aktywna w danym momencie. Aktywna pozycja to: {state.Name}");
        }
    }


}
