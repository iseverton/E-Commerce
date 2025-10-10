using ECommerce.Domain.Identity;
using ECommerce.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        
        services.AddConfigurationDatabase(configuration);

        return services;
    }

    public static IServiceCollection AddConfigurationDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("ECommerceDatabase");

        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }

    public static IServiceCollection AddConfigurationIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
        })
        .AddEntityFrameworkStores<ECommerceDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Repository registrations can be added here
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Other service registrations can be added here
        return services;
    }
}
