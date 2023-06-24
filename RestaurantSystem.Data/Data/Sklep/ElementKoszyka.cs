using System.ComponentModel.DataAnnotations;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Data.CMS.Abstract;

namespace RestaurantSystem.Data.Data.Sklep
{
    public class CartItem : EntityBase
    {
        public string? SessionId { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
