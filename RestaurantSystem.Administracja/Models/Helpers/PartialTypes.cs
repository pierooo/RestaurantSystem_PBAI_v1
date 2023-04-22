namespace RestaurantSystem.Administracja.Models.Helpers;

public class PartialTypes
{
    public const string About = "About";
    public const string Contact = "Contact";
    public const string CurrentEvent = "CurrentEvent";
    public const string CurrentMenu = "CurrentMenu";
    public const string Fact = "Fact";
    public const string Hero = "Hero";
    public const string Opinion = "Opinion";
    public const string Service = "Service";

    public List<string> Get()
    {
        return new List<string>() {
        About,
        Contact,
        CurrentEvent,
        CurrentMenu,
        Fact,
        Hero,
        Opinion,
        Service,
        };
    }

    public List<KeyAndValue> GetForSelector()
    {
        return new List<KeyAndValue>() {
        new KeyAndValue("Komponent dla strony o nas", About),
        new KeyAndValue("Komponent dla kontaktu", Contact),
        new KeyAndValue("Komponent dla wydarzeń", CurrentEvent),
        new KeyAndValue("Komponent dla menu/towarów", CurrentMenu),
        new KeyAndValue("Komponent dla podsumowań liczbowych", Fact),
        new KeyAndValue("Komponent ze zdjęciem", Hero),
        new KeyAndValue("Komponent dla opinii", Opinion),
        new KeyAndValue("Komponent z trzema boxami", Service),
        };
    }
}
