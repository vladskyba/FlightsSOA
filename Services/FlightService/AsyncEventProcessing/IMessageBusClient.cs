using FlightService.Models;

namespace FlightService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void RegisterService();

        void PushMessage<T>(T entity, string eventType)
            where T : class;
    }
}
