using ECommerce.Application.Common.Interfaces;
using ECommerce.Domain.Products;
using ECommerce.Infrastructure.Data.Context;
using ECommerce.Infrastructure.Data.Repositories;

namespace ECommerce.Infrastructure.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ECommerceDbContext context) : base(context)
    {
    }
}
