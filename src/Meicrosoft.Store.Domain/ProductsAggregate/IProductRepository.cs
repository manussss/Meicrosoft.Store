namespace Meicrosoft.Store.Domain.ProductsAggregate
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
    }
}
