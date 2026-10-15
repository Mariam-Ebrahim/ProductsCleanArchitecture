using MediatR;
using ProductsCleanArchitecture.Application.Interfaces;
using ProductsCleanArchitecture.Application.Products.Dtos;
using ProductsCleanArchitecture.Application.Products.Queries.GetProducts;

namespace ProductsCleanArchitecture.Application.Products.Queries.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>> Handle(
        GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products
            .Select(p => new ProductDto(p.Id, p.Name, p.Price))
            .ToList();
    }
}