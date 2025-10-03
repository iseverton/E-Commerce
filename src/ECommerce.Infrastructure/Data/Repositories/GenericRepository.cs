using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.Shared.Pagination;
using ECommerce.Infrastructure.Data.Context;
using ECommerce.Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ECommerceDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public bool Exists(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginationResult<T>> GetAllAsync(PagingParams pagingParams,
        Expression<Func<T, bool>>? filter = null, 
        Expression<Func<T, object>>? orderBy = null,
        bool descending = false)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
        {
          query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        }
        return await PaginationHelper.CreatePaginatedAsync(query, 
            pagingParams.PageNumber, pagingParams.PageSize);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
