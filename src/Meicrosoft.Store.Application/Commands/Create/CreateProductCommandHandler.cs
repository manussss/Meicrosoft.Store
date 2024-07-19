using MediatR;
using Meicrosoft.Store.Application.Contracts;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Serilog;

namespace Meicrosoft.Store.Application.Commands.Create
{
    public class CreateProductCommandHandler(IProductRepository productRepository, ILogger logger) : IRequestHandler<CreateProductCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseContract();

            try
            {
                logger.Information("Creating product {id}", request.Product.Id);

                var product = request.Product;
                product.CalculatePrice();

                var productCreated = await productRepository.CreateAsync(product);

                response.SetResponse(productCreated, true);

                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "{Class} | {Method} | Error when creating product",
                    nameof(CreateProductCommandHandler),
                    nameof(Handle));
                
                response.SetResponse(null, false);

                return response;
            }
        }
    }
}
