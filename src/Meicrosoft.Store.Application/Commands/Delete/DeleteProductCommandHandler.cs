using MediatR;
using Meicrosoft.Store.Application.Contracts;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Serilog;

namespace Meicrosoft.Store.Application.Commands.Delete
{
    public class DeleteProductCommandHandler(IProductRepository productRepository, ILogger logger) : IRequestHandler<DeleteProductCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseContract();

            try
            {
                var product = await productRepository.GetByIdAsync(request.Id);

                if (product == null)
                {
                    logger.Warning("ProductId {Id} not found", request.Id);

                    response.SetResponse(null, false);

                    return response;
                }

                logger.Information("Deleting product {id}", request.Id);

                await productRepository.DeleteAsync(product);
                response.SetResponse(null, true);

                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "{Class} | {Method} | Error when deleting product",
                    nameof(DeleteProductCommandHandler),
                    nameof(Handle));

                response.SetResponse(null, false);

                return response;
            }
        }
    }
}
