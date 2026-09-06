using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models.OrderModel;

namespace SavanNah.DataAccess.Repositories.OrderProducts
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
