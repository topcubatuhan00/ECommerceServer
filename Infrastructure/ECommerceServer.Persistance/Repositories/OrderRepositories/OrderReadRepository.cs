using ECommerceServer.Application.Repositories.OrderRepositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistance.Contexts;

namespace ECommerceServer.Persistance.Repositories.OrderRepositories;

public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(ECommerceServerDbContext dbContext) : base(dbContext)
    {
    }
}
