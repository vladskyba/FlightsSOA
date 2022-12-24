using AutoMapper;
using Flight.DataTransfer.Messaging;
using Flight.Models.Replications;
using Flight.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flight.AsyncEventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public async Task ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            Console.WriteLine($"Event determined: {eventType}");

            switch (eventType)
            {
                case EventType.AirportPushed:
                    await AddAirport(message);
                    Console.WriteLine("Airport Pushed to database!");
                    break;
                default:
                    break;
            }
        }

        private async Task AddAirport(string publishedMessage)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Airport>>();
                    var deserrialized = JsonSerializer.Deserialize<AirportPublished>(publishedMessage);
                    var airportEntity = _mapper.Map<Airport>(deserrialized);
                    var upserted = await repository.UpsertAsync(airportEntity);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}, {exception.StackTrace}");
            }
        }

        private static EventType DetermineEvent(string message)
        {
            var eventType = JsonSerializer.Deserialize<PublishedBase>(message);
            Console.WriteLine($"Event: {eventType.Event}");

            switch (eventType.Event)
            {
                case "airport.pushed":
                    return EventType.AirportPushed;
                default:
                    return EventType.Unrecognized;
            }
        }
    }
    
    enum EventType
    {
        Unrecognized,
        AirportPushed
    }
}
