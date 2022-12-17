namespace Airport.DataTransfer
{
    public class AirportCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public AirportAddressDto AirportAddress { get; set; }
    }
}
