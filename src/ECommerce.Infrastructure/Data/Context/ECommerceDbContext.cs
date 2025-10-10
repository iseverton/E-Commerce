using ECommerce.Domain.Identity;
using ECommerce.Domain.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Data.Context;

public class ECommerceDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
    {
    }
     public DbSet<Product> Products { get; set; }
}
