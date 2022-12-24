namespace Flight.DataTransfer.Messaging
{
    public class AirportPublished : PublishedBase
    {
        public string Name { get; set; }

        public AirportAdressPublished AirportAddress { get; set; }
    }
}
