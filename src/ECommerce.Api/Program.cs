using ECommerce.Application.Handlers.Products;
using ECommerce.Application.Queries.Products;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Data.Context;
using ECommerce.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDatabase")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListProductsQueryHandler).Assembly));

builder.Services.AddScoped<IProductRepository,ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
