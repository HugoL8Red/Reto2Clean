using Application;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
