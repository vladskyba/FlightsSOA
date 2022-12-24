namespace Flight.DataTransfer.Messaging
{
    public class AirportAdressPublished : PublishedBase
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }
    }
}