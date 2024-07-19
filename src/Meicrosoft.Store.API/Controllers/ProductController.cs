using MediatR;
using Meicrosoft.Store.Application.Commands.Create;
using Meicrosoft.Store.Application.Commands.Delete;
using Meicrosoft.Store.Application.Commands.Update;
using Meicrosoft.Store.Application.Queries.Interface;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Meicrosoft.Store.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController(IMediator mediator, IProductQuery query) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await query.GetAllAsync();

            if (products == null || !products.Any())
                return NoContent();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var product = await query.GetByIdAsync(id);

            if (product == null) return NoContent();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            var result = await mediator.Send(new CreateProductCommand(product));

            if (!result.Success)
                return BadRequest();

            return Created(nameof(GetByIdAsync), result.Product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Product product)
        {
            var result = await mediator.Send(new UpdateProductCommand(product));

            if (!result.Success)
                return NoContent();

            //todo review http code responses
            return Ok(result.Product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await mediator.Send(new DeleteProductCommand(id));

            if (!result.Success)
                return NoContent();

            //todo review http code responses
            return Ok();
        }
    }
}
