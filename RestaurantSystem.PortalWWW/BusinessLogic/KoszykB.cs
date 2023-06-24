using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Data.Sklep;

namespace RestaurantSystem.PortalWWW.BusinessLogic
{
    public class KoszykB
    {
        private readonly RestaurantContext _context;
        private string IdSesjiKoszyka;
        public KoszykB(RestaurantContext context, HttpContext httpContext)
        {
            _context = context;
            this.IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }
        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }
        public void DodajDoKoszyka(Product towar)
        {
            //Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var elementKoszyka =
               (
                   from element in _context.CartItem
                   where element.SessionId == this.IdSesjiKoszyka && element.ProductId == towar.Id
                   select element
               ).FirstOrDefault();
            // jeżeli brak tego towaru w koszyku
            if (elementKoszyka == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                elementKoszyka = new CartItem()
                {
                    SessionId = this.IdSesjiKoszyka,
                    ProductId = towar.Id,
                    Product = _context.Product.Find(towar.Id),
                    Quantity = 1,
                    CreatedAt = DateTime.Now
                };
                //i dodajemy do kolekcji lokalne
                _context.CartItem.Add(elementKoszyka);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                elementKoszyka.Quantity++;
            }
            // Zapisujemy zmiany do bazy
            _context.SaveChanges();
        }
        public async Task<List<CartItem>> GetElementyKoszyka()
        {
            return await
               _context.CartItem.Where(e => e.SessionId == this.IdSesjiKoszyka).Include(e => e.Product).ToListAsync();
        }
        public async Task<decimal> GetRazem()
        {
            var item =
                (
                from element in _context.CartItem
                where element.SessionId == this.IdSesjiKoszyka
                select (decimal?)element.Quantity * element.Product.UnitPriceGross
                );
            return await item.SumAsync() ?? decimal.Zero;
        }
    }
}
