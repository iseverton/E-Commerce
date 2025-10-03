using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Shared.Pagination;

public class PagingParams
{
    public const int MaxPageSize = 50;
    public int PageNumber { get; set; }
    private int _pageSize;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
