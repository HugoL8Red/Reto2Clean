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

        public int CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return 1;
        }

        public int DeleteOrder(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
            return 1;
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetOrderders(Order order)
        {
            return _context.Orders.ToList();
        }
    }
}
