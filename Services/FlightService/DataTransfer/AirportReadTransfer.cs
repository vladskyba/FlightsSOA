namespace FlightService.DataTransfer
{
    public class AirportReadTransfer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public AirportAdressReadTransfer AirportAddress { get; set; }
    }
}
