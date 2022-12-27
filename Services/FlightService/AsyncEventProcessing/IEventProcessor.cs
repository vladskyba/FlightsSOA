using System.Threading.Tasks;

namespace FlightService.AsyncEventProcessing
{
    public interface IEventProcessor
    {
        public Task ProcessEvent(string message);
    }
}
