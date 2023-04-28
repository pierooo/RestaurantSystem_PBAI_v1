namespace RestaurantSystem.Data.Helpers;

public class PartialDefinition
{
    public static int GetMaxCount(string partialType)
    {
        switch (partialType)
        {
            case (PartialTypes.About):
                return 1;
                break;
            case PartialTypes.Contact:
                return 1;
                break;
            case PartialTypes.Fact:
                return 4;
                break;
            case PartialTypes.Hero:
                return 1;
                break;
            case PartialTypes.Opinion:
                return 10;
                break;
            case PartialTypes.Service:
                return 3;
                break;
            case PartialTypes.LayoutEvents:
                return 3;
                break;
            default: return int.MaxValue;
        }
    }
}
