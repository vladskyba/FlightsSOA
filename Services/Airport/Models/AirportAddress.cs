namespace Airport.Models
{
    public class AirportAddress : BaseEntity
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public int AirportId { get; set; }

        public virtual AirportEntity Airport { get; set; }
    }
}
