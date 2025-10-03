using ECommerce.Application.Queries.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.Shared.Pagination;
using MediatR;
using System.Linq.Expressions;

namespace ECommerce.Application.Handlers.Products;

public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, PaginationResult<Product>>
{
    private readonly IProductRepository _productRepository;
     
    

    public ListProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PaginationResult<Product>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var orderBy = GetSortProperty(request.SortBy);
        
        // tranformar em enum
        bool descending = request.Order?.ToLower() == "desc";

        var products = await _productRepository.GetAllAsync(
            request,
            p => (string.IsNullOrEmpty(request.Brands) || p.Brand == request.Brands) &&
                 (string.IsNullOrEmpty(request.Type) || p.Type == request.Type),
            orderBy: orderBy,
            descending: descending
        );

        return products;
    }
    
    public static Expression<Func<Product, object>> GetSortProperty(string? sortBy)
    {
        return sortBy?.ToLower() switch
        {
            "name" => p => p.Name,
            "price" => p => p.Price,
            "brand" => p => p.Brand,
            "type" => p => p.Type,
            _ => p => p.Name
        };
    }
}
