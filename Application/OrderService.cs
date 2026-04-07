using Domain.Entities;
using Infrastructure.Interfaces;
using Reto2.Domain.Entities;
using Reto2.Infrastructure.Interfaces;
using System.Text.Json;

namespace Application
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPagoRepository _pagoRepository;
        private readonly IOrderMessage _orderMessage;

        public OrderService(IOrderRepository orderRepository, IPagoRepository pagoRepository, IOrderMessage orderMessage)
        {
            _orderRepository = orderRepository;
            _pagoRepository = pagoRepository;
            _orderMessage = orderMessage;
        }

        /// <summary>
        /// Creacion de orden
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);

            //save order
            Pago pago = new Pago()
            {
                OrderId = 1,
                Name = order.Name,
                Total = 10
            };
            
            // var response = _pagoRepository.RealizarPago(pago).Result;

            //send message

            _orderMessage.SendMessageAsync(order, "Order created");

            //if (response == -1)
            //{
            //    return -1;
            //}

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
