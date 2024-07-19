using Meicrosoft.Store.Application.Queries.Interface;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Meicrosoft.Store.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Store.Application.Queries
{
    public class ProductQuery(ProductContext context) : IProductQuery
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Product.FindAsync(id);
        }
    }
}
