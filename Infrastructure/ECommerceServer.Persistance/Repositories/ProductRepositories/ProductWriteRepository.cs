using ECommerceServer.Application.Repositories.Repositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistance.Contexts;

namespace ECommerceServer.Persistance.Repositories.ProductRepositories;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(ECommerceServerDbContext dbContext) : base(dbContext)
    {
    }
}
