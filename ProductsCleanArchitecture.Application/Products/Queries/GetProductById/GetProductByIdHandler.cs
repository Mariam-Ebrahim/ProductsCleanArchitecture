using MediatR;
using Microsoft.Extensions.Logging;
using ProductsCleanArchitecture.Application.Interfaces;
using ProductsCleanArchitecture.Application.Products.Dtos;
using ProductsCleanArchitecture.Application.Products.Queries.GetProductById;

namespace ProductsCleanArchitecture.Application.Products.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(IProductRepository repository, ILogger<GetProductByIdHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting product with ID {ProductId}", request.Id);

        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            _logger.LogWarning("Product with ID {ProductId} was not found", request.Id);
            return null;

        }

        return new ProductDto(product.Id, product.Name, product.Price);
    }
}