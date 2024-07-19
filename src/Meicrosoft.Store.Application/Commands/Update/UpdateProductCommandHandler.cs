using MediatR;
using Meicrosoft.Store.Application.Contracts;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Serilog;

namespace Meicrosoft.Store.Application.Commands.Update
{
    public class UpdateProductCommandHandler(IProductRepository productRepository, ILogger logger) : IRequestHandler<UpdateProductCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseContract();

            try
            {
                logger.Information("Updating product {id}", request.Product.Id);

                var productCreated = await productRepository.UpdateAsync(request.Product);

                if (productCreated <= 0)
                {
                    logger.Warning("ProductId: {Id} not found", request.Product.Id);

                    response.SetResponse(null, false);
                    
                    return response;
                }

                response.SetResponse(null, true);

                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "{Class} | {Method} | Error when updating product",
                    nameof(UpdateProductCommandHandler),
                    nameof(Handle));

                response.SetResponse(null, false);

                return response;
            }
        }
    }
}
