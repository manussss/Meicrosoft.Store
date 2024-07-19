using MediatR;
using Meicrosoft.Store.Application.Commands;
using Meicrosoft.Store.Application.Queries.Interface;
using Meicrosoft.Store.Domain.ProductsAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Meicrosoft.Store.API.Controllers
{
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

            return Ok(result.Product);
        }
    }
}
