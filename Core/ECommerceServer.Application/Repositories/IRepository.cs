using ECommerceServer.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
