using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities.Common;
using ECommerceServer.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceServer.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly ECommerceServerDbContext _dbContext;
    public ReadRepository(ECommerceServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public DbSet<T> Table => _dbContext.Set<T>();

    public IQueryable<T> GetAll() => Table;

    public async Task<T> GetByIdAsync(string id)
    => await Table.FindAsync(Guid.Parse(id));

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
    => await Table.FirstOrDefaultAsync(expression);

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
    => Table.Where(expression); 
}
