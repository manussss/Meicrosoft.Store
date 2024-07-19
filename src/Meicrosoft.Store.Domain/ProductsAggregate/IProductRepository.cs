namespace Meicrosoft.Store.Domain.ProductsAggregate
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<int> UpdateAsync(Product productUpdated);
        Task DeleteAsync(Product product);
        Task<Product?> GetByIdAsync(Guid id);
    }
}
