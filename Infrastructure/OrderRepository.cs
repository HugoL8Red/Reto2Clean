using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOrder(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrder(Order order)
        {

            var value = _context.Orders.FirstOrDefault(x => x.Id == order.Id);
            value.Name = order.Name;
            value.Date = order.Date;

            _context.SaveChanges();
            return 1;
        }
    }
}
