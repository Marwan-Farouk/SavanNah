using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models.OrderModel;

namespace SavanNah.DataAccess.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
