using Meicrosoft.Store.Domain.ProductsAggregate;

namespace Meicrosoft.Store.Application.Contracts
{
    public class ResponseContract
    {
        public Product? Product { get; private set; }
        public bool Success { get; private set; }

        public void SetResponse(Product? product, bool success)
        {
            Product = product;
            Success = success;
        }
    }
}
