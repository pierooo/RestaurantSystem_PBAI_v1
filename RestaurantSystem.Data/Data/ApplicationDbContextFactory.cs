using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantSystem.Data.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<RestaurantContext>
    {
        public RestaurantContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantContext>();
            optionsBuilder.UseSqlServer("Data Source=PIOTR\\SQLEXPRESS;Initial Catalog=Restaurant_v1;Integrated Security=True");

            return new RestaurantContext(optionsBuilder.Options);
        }
    }
}
