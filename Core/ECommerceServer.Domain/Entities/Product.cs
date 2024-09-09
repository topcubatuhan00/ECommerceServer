using ECommerceServer.Domain.Entities.Common;

namespace ECommerceServer.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }
    ICollection<Order> Orders { get; set; }
}
