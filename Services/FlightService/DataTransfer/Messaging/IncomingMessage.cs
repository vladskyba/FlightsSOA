namespace ReservationService.DateTransfer.Messaging
{
    public class IncomingMessage<T> 
        where T : class
    {
        public long EntityId { get; set; }

        public string Event { get; set; }

        public T EntityPayload { get; set; }
    }
}
