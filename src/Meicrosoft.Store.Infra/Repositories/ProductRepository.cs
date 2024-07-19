using Meicrosoft.Store.Domain.ProductsAggregate;
using Meicrosoft.Store.Infra.Data;

namespace Meicrosoft.Store.Infra.Repositories
{
    public class ProductRepository(ProductContext context) : IProductRepository
    {
        public async Task<Product> CreateAsync(Product product)
        {
            return (await context.Product.AddAsync(product)).Entity;
        }
    }
}
