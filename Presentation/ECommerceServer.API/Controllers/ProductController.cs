using ECommerceServer.Application.Repositories.ProductRepositories;
using ECommerceServer.Application.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    [HttpGet]
    public async Task Get()
    {
        await _productWriteRepository.AddRangeAsync(new()
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 10, CreatedDate = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 20, CreatedDate = DateTime.UtcNow },
            new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 30, CreatedDate = DateTime.UtcNow },
        });

        await _productWriteRepository.SaveAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _productReadRepository.GetByIdAsync(id);
        return Ok(data);
    }
}
