using Meicrosoft.Store.Domain.ProductsAggregate;
using Meicrosoft.Store.Infra.Data;

namespace Meicrosoft.Store.Infra.Repositories
{
    public class ProductRepository(ProductContext context) : IProductRepository
    {
        public async Task<Product> CreateAsync(Product product)
        {
            var result = (await context.Product.AddAsync(product)).Entity;
            await context.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateAsync(Product productUpdated)
        {
            context.Product.Update(productUpdated);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            context.Product.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Product.FindAsync(id);
        }
    }
}
