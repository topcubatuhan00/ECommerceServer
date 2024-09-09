using ECommerceServer.Domain.Entities.Common;

namespace ECommerceServer.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}
