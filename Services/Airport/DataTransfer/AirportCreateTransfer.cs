namespace Airport.DataTransfer
{
    public class AirportCreateTransfer
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public AirportAdressReadTransfer AirportAddress { get; set; }
    }
}
