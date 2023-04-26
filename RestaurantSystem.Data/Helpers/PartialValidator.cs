using RestaurantSystem.Data.Data;

namespace RestaurantSystem.Data.Helpers;

public class PartialValidator
{
    public static void ValidatePartialForNewItem(RestaurantContext context, int? partialId)
    {
        var partialType = context.Partial.Single(x => x.Id == partialId).PartialType;
        switch (partialType)
        {
            case (PartialTypes.About):
                ValidatePartialItemsCount(context.AboutPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.About);
                break;
            case (PartialTypes.Contact):
                ValidatePartialItemsCount(context.ContactPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.Contact);
                break;
            case (PartialTypes.CurrentEvent):
                ValidatePartialItemsCount(context.CurrentEventPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.CurrentEvent);
                break;
            case (PartialTypes.CurrentMenu):
                ValidatePartialItemsCount(context.CurrentMenuPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.CurrentMenu);
                break;
            case (PartialTypes.Fact):
                ValidatePartialItemsCount(context.FactPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.Fact);
                break;
            case (PartialTypes.Hero):
                ValidatePartialItemsCount(context.FactPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.Hero);
                break;
            case (PartialTypes.Opinion):
                ValidatePartialItemsCount(context.OpinionPartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.Opinion);
                break;
            case (PartialTypes.Service):
                ValidatePartialItemsCount(context.ServicePartial.Where(x => x.PartialId == partialId).Count(), PartialTypes.Service);
                break;
            default: throw new ArgumentException($"Not suported Partial Type {partialType}.");
        }
    }

    private static void ValidatePartialItemsCount(int? currentCount, string partialType)
    {
        var maxCount = PartialDefinition.GetMaxCount(partialType);

        if (currentCount < maxCount)
        {
            return;
        }

        throw new ArgumentException($"Typ komponentu pozwala na dodanie maksymalnie {maxCount} elementów. Edytuj istniejący element w komponencie lub wybierz inny komponent.");
    }
}
