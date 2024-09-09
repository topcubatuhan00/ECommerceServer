using ECommerceServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.Persistance.Contexts;

public class ECommerceServerDbContext : DbContext
{
    public ECommerceServerDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
}
