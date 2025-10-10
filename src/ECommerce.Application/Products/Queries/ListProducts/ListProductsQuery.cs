
using ECommerce.Application.Common.Pagination;
using ECommerce.Domain.Products;
using MediatR;

namespace ECommerce.Application.Products.Queries.ListProducts;

public class ListProductsQuery : PagingParams,IRequest<PaginationResult<Product>>
{
    public string? Brands { get; set; }
    public string? Type { get; set; }
    public string? SortBy { get; set; }
    public string? Order { get; set; }
}
