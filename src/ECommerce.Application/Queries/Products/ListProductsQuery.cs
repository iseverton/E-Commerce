using ECommerce.Domain.Entities;
using ECommerce.Domain.Shared.Pagination;
using MediatR;

namespace ECommerce.Application.Queries.Products;

public class ListProductsQuery : PagingParams,IRequest<PaginationResult<Product>>
{
    public string? Brands { get; set; }
    public string? Type { get; set; }
    public string? SortBy { get; set; }
    public string? Order { get; set; }
}
