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
        public List<Order> GetOrderders(Order order);
        public int DeleteOrder(int id);
    }
}
