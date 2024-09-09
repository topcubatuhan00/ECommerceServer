using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities.Common;
using ECommerceServer.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceServer.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ECommerceServerDbContext _context;
        public WriteRepository(ECommerceServerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry =  await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var data = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            return Remove(data);

        }

        public bool RemoveRange(List<T> entity)
        {
            Table.RemoveRange(entity);
            return true;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public bool Update(T entity)
        {
            EntityEntry<T> entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
