using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderService.GetOrder(id);
        }

        [HttpPost]
        public int CreateOrder(Order order)
        {
            var orderId = _orderService.CreateOrder(order);
            return 0;
        }
    }
}
