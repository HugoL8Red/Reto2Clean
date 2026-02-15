using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        public int CreateOrder(Order order);
        public Order GetOrder(int id);
        public List<Order> GetOrders();
        public int DeleteOrder(int id);
        public int UpdateOrder(Order order);
    }
}
