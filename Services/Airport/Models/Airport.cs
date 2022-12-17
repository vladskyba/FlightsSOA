namespace Airport.Models
{
    public class AirportEntity: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long AirportAddressId { get; set; }

        public AirportAddress AirportAddress { get; set; }
    }
}
