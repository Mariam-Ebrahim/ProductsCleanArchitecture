using MediatR;
using ProductsCleanArchitecture.Application.Interfaces;
using ProductsCleanArchitecture.Application.Products.Commands.CreateProduct;
using ProductsCleanArchitecture.Domain.Entities;

namespace ProductsCleanArchitecture.Application.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}