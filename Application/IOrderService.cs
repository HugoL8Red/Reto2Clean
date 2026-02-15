using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IOrderService
    {
        public int CreateOrder(Order order);
        public int UpdateOrder(Order order);
        public Order GetOrder(int id);
        public int GetOrderders(Order order);
        public int DeleteOrder(int id);
    }
}
