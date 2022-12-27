namespace FlightService.DataTransfer
{
    public class FlightReadTransfer
    {
        public AirportReadTransfer DepartureAirport { get; set; }

        public AirportReadTransfer ArrivalAirport { get; set; }

        public long Id { get; set; }
    }
}
