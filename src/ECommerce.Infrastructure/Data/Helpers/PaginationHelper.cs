using ECommerce.Application.Common.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Helpers;

public class PaginationHelper
{
    public static async Task<PaginationResult<T>> CreatePaginatedAsync<T>(
    IQueryable<T> query, int pageNumber, int pageSize)
    {
        var count = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginationResult<T>
        {
            Metadata = new PaginationMetadata
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = count
            },
            Items = items
        };
    }
}
