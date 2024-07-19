using MediatR;
using Meicrosoft.Store.Application.Contracts;
using Meicrosoft.Store.Domain.ProductsAggregate;

namespace Meicrosoft.Store.Application.Commands.Update
{
    public class UpdateProductCommand(Product product) : IRequest<ResponseContract>
    {
        public Product Product { get; set; } = product;
    }
}
