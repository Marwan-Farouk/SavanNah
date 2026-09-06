using SavanNah.DataAccess.Repositories.OrderProducts;
using SavanNah.DataAccess.Repositories.Orders;
using SavanNah.Models.Models.OrderModel;
using System.Linq.Expressions;

namespace SavanNah.Business.Managers.OrderManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderManager(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            this._orderRepository = orderRepository;
            this._orderProductRepository = orderProductRepository;
        }
        public async Task<Order> Create(Order entity)
        {
            return await _orderRepository.Create(entity);
        }

        public async Task<bool> Delete(Order entity)
        {
            return await _orderRepository.Delete(entity);
        }

        public async Task<Order> Get(Expression<Func<Order, bool>> filter, string[]? includes)
        {
            return await _orderRepository.Get(filter, includes);
        }

        public async Task<IEnumerable<Order>> GetAll(Expression<Func<Order, bool>>? filter, string[]? includes)
        {
            return await _orderRepository.GetAll(filter, includes);
        }
        public Order Update(Order entity)
        {
            return _orderRepository.Update(entity);
        }
        public async Task<int> Save()
        {
            return await _orderRepository.Save();
        }

    }
}
