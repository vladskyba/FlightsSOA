using Microsoft.Extensions.DependencyInjection;
using ReservationService.DateTransfer.Messaging;
using ReservationService.Models;
using ReservationService.Models.Replications;
using ReservationService.Repositories;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservationService.AsyncEventProcessing
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
            var deserrialized = JsonSerializer.Deserialize<IncomingMessage<Flight>>(message);

            switch (deserrialized.Event)
            {
                case "flight.created":
                    await HandleReplication(deserrialized.EntityPayload);
                    Console.WriteLine("Flight pushed to database!");
                    break;
                default:
                    break;
            }
        }

        private async Task HandleReplication<T>(T entity)
            where T : BaseEntity
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<T>>();
                await repository.UpsertAsync(entity);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurs while handling replication: {exception.Message}, {exception.StackTrace}");
            }
        }
    }
}
