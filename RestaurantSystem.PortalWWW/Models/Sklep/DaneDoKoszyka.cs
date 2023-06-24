using RestaurantSystem.Data.Data.Sklep;

namespace RestaurantSystem.PortalWWW.Models.Sklep
{
    public class DaneDoKoszyka
    {
        public List<CartItem> ElementyKoszyka { get; set; }
        public decimal Razem { get; set; }
    }

}
