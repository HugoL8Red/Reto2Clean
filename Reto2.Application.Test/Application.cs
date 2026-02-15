using Application;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace Reto2.Application.Test
{
    public class Application
    {
        [Fact]
        public void CreateOrder()
        {
            var mockRepo = new Mock<IOrderRepository>();
            // Set up the mock to return a specific user when GetUserById(1) is called
            mockRepo.Setup(repo => repo.CreateOrder(new Order { Id = 1, Name = "Test User", Date = new DateTime() }));

            var service = new OrderService(mockRepo.Object);

            // Act
            string result = service.CreateOrder(1);

            // Assert
            Assert.Equal("Test User", result);
        }
    }
}
