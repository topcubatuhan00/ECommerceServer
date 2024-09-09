using ECommerceServer.Application.Repositories.ProductRepositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistance.Contexts;

namespace ECommerceServer.Persistance.Repositories.ProductRepositories;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ECommerceServerDbContext dbContext) : base(dbContext)
    {
    }
}
