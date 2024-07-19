using MediatR;
using Meicrosoft.Store.Application.Contracts;
using Meicrosoft.Store.Domain.ProductsAggregate;

namespace Meicrosoft.Store.Application.Commands.Create
{
    public class CreateProductCommand : IRequest<ResponseContract>
    {
        public Product Product { get; set; }

        public CreateProductCommand(Product product)
        {
            Product = product;
        }
    }
}
