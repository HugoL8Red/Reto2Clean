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

        /// <summary>
        /// Creacion de orden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
            return 1;
        }

        /// <summary>
        /// Eliminar orden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(1);
            return 0;
        }

        /// <summary>
        /// Obtener order por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrder(id);
        }

        /// <summary>
        /// Obtener ordenes
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        /// <summary>
        /// Actualizar orden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }
    }
}
