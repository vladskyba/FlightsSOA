using Airport.DataTransfer.Messaging;

namespace Airport.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PuslishAirport(AirportPublished airportPublished);

        void RegisterService();
    }
}
