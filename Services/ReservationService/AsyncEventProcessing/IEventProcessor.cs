using System.Threading.Tasks;

namespace ReservationService.AsyncEventProcessing
{
    public interface IEventProcessor
    {
        public Task ProcessEvent(string message);
    }
}
