using Meicrosoft.Store.Domain.ProductsAggregate;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Store.Infra.Data
{
    public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
