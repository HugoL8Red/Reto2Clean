using Application;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Reto2.Infrastructure;
using Reto2.Infrastructure.Interfaces;

namespace Reto2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IPagoRepository, PagoRepository>();
            builder.Services.AddScoped<IOrderMessage, OrderMessage>();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDbPago"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
