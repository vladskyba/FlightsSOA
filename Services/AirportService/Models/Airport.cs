namespace Airport.Models
{
    public class Airport: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long AirportAddressId { get; set; }

        public bool IsActive { get; set; }

        public AirportAddress AirportAddress { get; set; }
    }
}
