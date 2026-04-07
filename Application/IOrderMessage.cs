using Domain.Entities;
using System.Text;

namespace Application
{
    public interface IOrderMessage
    {
         public Task SendMessageAsync(Order message, string queueName);
    }
}
