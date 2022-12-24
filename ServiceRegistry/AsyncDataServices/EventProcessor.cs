using Airport.DataTransfer.Messaging;
using Microsoft.Extensions.DependencyInjection;
using ServicesRegistry.Enums;
using ServicesRegistry.Models;
using ServicesRegistry.Repositories;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceRegistry.AsyncDataServices
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessEvent(string message)
        {
            var publishedSettings = JsonSerializer.Deserialize<ServiceSettingsPublished>(message);

            switch (publishedSettings.Event)
            {
                case "airport-service.register":
                {
                    await RegisterService(publishedSettings, ServiceType.Airport);
                    Console.WriteLine("Airport service registered!");
                    break;
                }
                case "airplane-service.register":
                {
                    await RegisterService(publishedSettings, ServiceType.Airplane);
                    Console.WriteLine("Airplane service registered!");
                    break;
                }
                default:
                    break;
            }
        }

        private async Task RegisterService(ServiceSettingsPublished publishedSettings, ServiceType service)
        {
            var serviceSettings = new ServiceSettings
            {
                Entered = DateTime.UtcNow,
                Service = service,
                Name = publishedSettings.Name,
                Port = publishedSettings.Port
            };

            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<ServiceSettings>>();
                    var upserted = await repository.UpsertAsync(serviceSettings);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}, {exception.StackTrace}");
            }
        }
    }
}
