using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Worker.Application
{
    public class WorkerService : IWorkerService
    {
        private readonly ConnectionFactory _factory;

        public WorkerService()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost", // Use IP or domain for remote brokers
                Port = 5672,            // Use 5671 for SSL
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };
        }

        public async Task<string> GetMessage(string message)
        {
            try
            {
                using var connection = await _factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();
                {
                    // 2. Ensure the queue exists
                    string queueName = message;
                    await channel.QueueDeclareAsync(queueName, durable: false, exclusive: false, autoDelete: false);

                    // 3. Setup the consumer
                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.ReceivedAsync += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($" [x] Received {message}");

                        // Acknowledge the message if autoAck is false
                        // await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
                    };

                    // 4. Start consuming
                    await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
                    return "Consumer finished";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
