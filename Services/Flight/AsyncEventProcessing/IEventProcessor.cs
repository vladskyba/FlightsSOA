using System.Threading.Tasks;

namespace Flight.AsyncEventProcessing
{
    public interface IEventProcessor
    {
        public Task ProcessEvent(string message);
    }
}
