using ECommerceServer.Application.Repositories.CustomerRepositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistance.Contexts;

namespace ECommerceServer.Persistance.Repositories.CustomerRepositories;

public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(ECommerceServerDbContext dbContext) : base(dbContext)
    {
    }
}
