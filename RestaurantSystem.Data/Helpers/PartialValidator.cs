using RestaurantSystem.Data.Data;

namespace RestaurantSystem.Data.Helpers;

public class PartialValidator
{
    private readonly RestaurantContext context;
    public PartialValidator(RestaurantContext context)
    {
        this.context = context;
    }

    public void ValidatePartialForNewItem(int? partialId)
    {
        var partialType = context.Partial.Single(x => x.Id == partialId).PartialType;
        switch (partialType)
        {
            case (PartialTypes.About):
                ValidatePartialItemsCount(context.AboutPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.Contact):
                ValidatePartialItemsCount(context.ContactPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.CurrentEvent):
                ValidatePartialItemsCount(context.CurrentEventPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.CurrentMenu):
                ValidatePartialItemsCount(context.CurrentMenuPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.Fact):
                ValidatePartialItemsCount(context.FactPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.Hero):
                ValidatePartialItemsCount(context.FactPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.Opinion):
                ValidatePartialItemsCount(context.OpinionPartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            case (PartialTypes.Service):
                ValidatePartialItemsCount(context.ServicePartial.Sum(x => x.PartialId), PartialTypes.About);
                break;
            default: throw new ArgumentException($"Not suported Partial Type {partialType}.");
        }
    }

    private void ValidatePartialItemsCount(int? currentCount, string partialType)
    {
        var maxCount = PartialDefinition.GetMaxCount(partialType);

        if (currentCount < maxCount)
        {
            return;
        }

        throw new ArgumentException($"Typ komponentu pozwala na dodanie maksymalnie {maxCount} elementów. Edytuj istniejący element w komponencie lub wybierz inny komponent.");
    }
}
