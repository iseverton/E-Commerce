using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Products.Queries.ListProducts;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.Data.Context;
using ECommerce.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ListProductsQueryHandler).Assembly));


// add services from infrastructure layer
builder.Services.AddInfrastructure(builder.Configuration);

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
