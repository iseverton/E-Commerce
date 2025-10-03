namespace ECommerce.Domain.Shared.Pagination;

public class PaginationResult<T>
{
    public IReadOnlyList<T> Items { get; set; } = [];
    public PaginationMetadata Metadata { get; set; } = default!;
}
