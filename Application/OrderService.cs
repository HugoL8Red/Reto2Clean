using Domain.Entities;
using Domain.Interfaces;

namespace Application
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
            return 1;
        }

        public int DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrder(id);
        }

        public int GetOrderders(Order order)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
