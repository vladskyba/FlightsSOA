using System.Threading.Tasks;

namespace ServiceRegistry.AsyncDataServices
{
    public interface IEventProcessor
    {
        public Task ProcessEvent(string message);
    }
}
