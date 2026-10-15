using MediatR;
using ProductsCleanArchitecture.Application.Products.Dtos;

namespace ProductsCleanArchitecture .Application.Products.Queries.GetProducts;

public record GetProductsQuery() : IRequest<List<ProductDto>>;