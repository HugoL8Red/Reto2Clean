using Domain.Entities;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Application
{
    public class OrderMessage : IOrderMessage
    {
        private readonly ConnectionFactory _factory;
        public OrderMessage()
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
        }

        public async Task SendMessageAsync(Order message, string queueName)
        {
            try
            {
                using var connection = await _factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
                await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
