using ECommerceServer.Application.Repositories.CustomerRepositories;
using ECommerceServer.Application.Repositories.OrderRepositories;
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
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;

    public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _orderWriteRepository = orderWriteRepository;
        _customerWriteRepository = customerWriteRepository;
    }

    [HttpGet]
    public async Task Get()
    {
        var cid = Guid.NewGuid();
        await _customerWriteRepository.AddAsync(new() { Name = "asdasd", Id=cid });
        await _orderWriteRepository.AddAsync(new() { Description = "asdasd", Address="asdasdasd", CustomerId= cid });
        await _orderWriteRepository.SaveAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var data = await _productReadRepository.GetByIdAsync(id);
        return Ok(data);
    }
}
