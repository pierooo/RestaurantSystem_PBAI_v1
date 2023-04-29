using RestaurantSystem.Data.Data;

namespace RestaurantSystem.Data.Helpers;

public class CommonValidator
{
    public static void AssertCompanyState(RestaurantContext context, bool creationState, int? id = -1)
    {
        if (context.Company.Any(x => x.IsActive && x.Id != id) && creationState)
        {
            throw new ArgumentException("Tylko jedna pozycja może być aktywna w danym momencie. Zmień flagę aktywnej pozycji jesli chcesz ustawić te dane jako aktywne.");
        }
    }

    public static void AssertLayoutPartial(RestaurantContext context, bool creationState, int? id = -1)
    {
        var state = context.Partial.FirstOrDefault(x => x.PartialType == PartialTypes.LayoutEvents && x.IsActive && x.Id != id);
        if (state != null && creationState == true)
        {
            throw new ArgumentException($"Tylko jedna pozycja wydarzeń dla wszystkich stron może być aktywna w danym momencie. Aktywna pozycja to: {state.Name}");
        }
    }


}
