using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsCleanArchitecture.Application.Products.Queries.GetProducts;
using ProductsCleanArchitecture.Application.Products.Commands.CreateProduct;
using ProductsCleanArchitecture.Application.Products.Commands.UpdateProduct;
using ProductsCleanArchitecture.Application.Products.Commands.DeleteProduct;
using ProductsCleanArchitecture.Application.Products.Queries.GetProductById;
using ProductsCleanArchitecture.API.Contracts;
namespace ProductsCleanArchitecture.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] ProductRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand(request.Name, request.Price);
        var id = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var products = await _sender.Send(new GetProductsQuery(), cancellationToken);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id), cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] ProductRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdateProductCommand(id, request.Name, request.Price);
        var updated = await _sender.Send(command, cancellationToken);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _sender.Send(new DeleteProductCommand(id), cancellationToken);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}