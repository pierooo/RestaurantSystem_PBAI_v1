namespace RestaurantSystem.Administracja.Models.Helpers;

public class KeyAndValue
{
    public string Key { get; set; }

    public string Value { get; set; }

    public KeyAndValue(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
