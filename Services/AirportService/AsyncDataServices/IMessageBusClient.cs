using Airport.DataTransfer.Messaging;

namespace Airport.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PuslishCreatedAirport(AirportPublished airportPublished);
    }
}
