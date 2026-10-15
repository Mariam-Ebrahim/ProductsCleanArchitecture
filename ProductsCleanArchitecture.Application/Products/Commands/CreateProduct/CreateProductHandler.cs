using MediatR;
using Microsoft.Extensions.Logging;
using ProductsCleanArchitecture.Application.Interfaces;
using ProductsCleanArchitecture.Application.Products.Commands.CreateProduct;
using ProductsCleanArchitecture.Domain.Entities;

namespace ProductsCleanArchitecture.Application.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(IProductRepository repository, ILogger<CreateProductHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<int> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogDebug("Create product request received: {@Request}", request);
        _logger.LogInformation("Creating product {ProductName}", request.Name);

        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        await _repository.AddAsync(product, cancellationToken);
        _logger.LogInformation("Product created successfully. ProductId: {ProductId}", product.Id);

        return product.Id;
    }


}