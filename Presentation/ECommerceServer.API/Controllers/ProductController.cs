using ECommerceServer.Application.Repositories.ProductRepositories;
using ECommerceServer.Application.Repositories.Repositories;
using ECommerceServer.Application.ViewModels.ProductModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductController
    (
        IProductReadRepository productReadRepository, 
        IProductWriteRepository productWriteRepository
    )
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = _productReadRepository.GetAll(false);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _productReadRepository.GetByIdAsync(id, false);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VM_Create_Product product)
    {
        await _productWriteRepository.AddAsync(new() { Name=product.Name, Price=product.Price, Stock=product.Stock});
        await _productWriteRepository.SaveAsync();
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Update(VM_Update_Product product)
    {
        var p = await _productReadRepository.GetByIdAsync(product.Id);
        p.Name = product.Name;
        p.Price = product.Price;
        p.Stock = product.Stock;
        await _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveAsync();
        return Ok();
    }
}
