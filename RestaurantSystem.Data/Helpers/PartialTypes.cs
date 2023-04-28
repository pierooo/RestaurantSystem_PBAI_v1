namespace RestaurantSystem.Data.Helpers;

public class PartialTypes
{
    public const string About = "About";
    public const string AboutPolish = "Komponent dla strony o nas";
    public const string Contact = "Contact";
    public const string ContactPolish = "Komponent dla kontaktu";
    public const string CurrentEvent = "CurrentEvent";
    public const string CurrentEventPolish = "Komponent dla wydarzeń";
    public const string CurrentMenu = "CurrentMenu";
    public const string CurrentMenuPolish = "Komponent dla menu/towarów";
    public const string Fact = "Fact";
    public const string FactPolish = "Komponent dla podsumowań liczbowych";
    public const string Hero = "Hero";
    public const string HeroPolish = "Komponent ze zdjęciem";
    public const string Opinion = "Opinion";
    public const string OpinionPolish = "Komponent dla opinii";
    public const string Service = "Service";
    public const string ServicePolish = "Komponent z trzema boxami";
    public const string LayoutEvents = "LayoutEvents";
    public const string LayoutEventsPolish = "Komponent dla wydarzeń dla wszystkich stron";



    public static string GetPolishType(string type)
    {
        switch (type)
        {
            case (About):
                return AboutPolish;
            case (Contact):
                return ContactPolish;
            case (CurrentEvent):
                return CurrentEventPolish;
            case (CurrentMenu):
                return CurrentMenuPolish;
            case (Fact):
                return FactPolish;
            case (Hero):
                return HeroPolish;
            case (Opinion):
                return OpinionPolish;
            case (Service):
                return ServicePolish;
            case (LayoutEvents):
                return LayoutEventsPolish;
            default:
                return type;
        }
    }

    public List<KeyAndValue> GetForSelector()
    {
        return new List<KeyAndValue>() {
        new KeyAndValue(AboutPolish, About),
        new KeyAndValue(ContactPolish, Contact),
        new KeyAndValue(CurrentEventPolish, CurrentEvent),
        new KeyAndValue(CurrentMenuPolish, CurrentMenu),
        // TODO: feature new KeyAndValue(FactPolish, Fact),
        new KeyAndValue(HeroPolish, Hero),
        // TODO: feature new KeyAndValue(OpinionPolish, Opinion),
        new KeyAndValue(ServicePolish, Service),
        new KeyAndValue(LayoutEventsPolish, LayoutEvents)
        };
    }
}
