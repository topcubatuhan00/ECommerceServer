using ECommerceServer.Application.Repositories.OrderRepositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistance.Contexts;

namespace ECommerceServer.Persistance.Repositories.OrderRepositories;

public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ECommerceServerDbContext dbContext) : base(dbContext)
    {
    }
}
