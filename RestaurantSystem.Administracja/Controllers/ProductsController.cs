using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Administracja.Controllers.Abstract;
using RestaurantSystem.Data.Data;
using RestaurantSystem.Data.Data.CMS;
using RestaurantSystem.Data.Helpers;

namespace RestaurantSystem.Administracja.Controllers
{
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(RestaurantContext context, PartialValidator partialvalidator)
            : base(context, partialvalidator)
        {
        }

        public override async Task<List<Product>> GetEntityList()
        {
            return await context.Product.Include(p => p.Category).ToListAsync();
        }

        // GET: Products/Create
        public override async Task SetSelectList()
        {
            ViewData["CategoryId"] = new SelectList(await context.Category.ToListAsync(), "Id", "Name");
        }

        // GET: Products/Edit/5
        public override async Task<Product> GetEntity(int? id)
        {
            return await context.Product.FindAsync(id);
        }

        // POST: Products/Delete/5
        public override void RemoveEntity(Product product)
        {
            context.Product.Remove(product);
        }
    }
}
