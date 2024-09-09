using ECommerceServer.Domain.Entities.Common;

namespace ECommerceServer.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entity);
    bool Remove(T entity);
    bool RemoveRange(List<T> entity);
    Task<bool> RemoveAsync(string id);
    bool Update(T entity);
    Task<int> SaveAsync();
}
