using SavanNah.Models.Models.OrderModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.OrderManager
{
    public interface IOrderManager
    {
        Task<IEnumerable<Order>> GetAll(Expression<Func<Order, bool>>? filter, string[]? includes);
        Task<Order> Get(Expression<Func<Order, bool>> filter, string[]? includes);
        Task<Order> Create(Order entity);
        Order Update(Order entity);
        Task<bool> Delete(Order entity);
        Task<int> Save();
    }
}
