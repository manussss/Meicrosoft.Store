using Meicrosoft.Store.Domain.ProductsAggregate;
using Meicrosoft.Store.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Store.Infra.Repositories
{
    public class ProductRepository(ProductContext context) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Product.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            return (await context.Product.AddAsync(product)).Entity;
        }
    }
}
