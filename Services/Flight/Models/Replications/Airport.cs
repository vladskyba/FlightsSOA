namespace Flight.Models.Replications
{
    public class Airport : ExternalBase
    {
        public string Name { get; set; }

        public long AirportAddressId { get; set; }

        public AirportAddress AirportAddress { get; set; }
    }
}
