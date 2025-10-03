using ECommerce.Application.Queries.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository,IMediator mediator)
    {
        _mediator = mediator;
        _productRepository = productRepository;
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(Product product)
    //{
    //    _productRepository.AddAsync(product);
    //    if(!await _productRepository.SaveChangesAsync())
    //    {
    //        BadRequest("Error ao salvar no banco");
    //    }
    //    return Ok("Criado com sucesso");

    //}

    [HttpGet()]
    public async Task<IActionResult> GetAll( [FromQuery] ListProductsQuery query, 
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query,cancellationToken);
        return Ok(result);
    }
}
