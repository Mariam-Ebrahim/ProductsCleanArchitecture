using MediatR;
using ProductsCleanArchitecture.Application.Products.Dtos;

namespace ProductsCleanArchitecture.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;