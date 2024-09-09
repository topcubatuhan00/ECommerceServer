using ECommerceServer.Application.Repositories.CustomerRepositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistance.Contexts;

namespace ECommerceServer.Persistance.Repositories.CustomerRepositories;

public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(ECommerceServerDbContext dbContext) : base(dbContext)
    {
    }
}
