namespace ECommerce.Domain.Shared.Pagination;

public class PaginationMetadata
{
    public int PageNumber { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
