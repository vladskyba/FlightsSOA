namespace Flight.AsyncEventProcessing
{
    public interface IEventProcessor
    {
        public void ProcessEvent(string message);
    }
}
