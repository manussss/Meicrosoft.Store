using Meicrosoft.Store.Domain.ProductsAggregate;

namespace Meicrosoft.Store.Application.Queries.Interface
{
    public interface IProductQuery
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
    }
}
