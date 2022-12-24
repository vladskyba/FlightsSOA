using Airport.AsyncDataServices;
using Airport.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Airport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();

            using (var database = app.Services.CreateScope().ServiceProvider.GetService<AirportContext>())
            {
                database.Database.Migrate();
            }

            var messageBus = app.Services.GetService<IMessageBusClient>();
            messageBus.RegisterService();

            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
