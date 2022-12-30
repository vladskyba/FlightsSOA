namespace ReservationService.DataTransfer
{
    public class FlightReadTransfer : FlightBaseTransfer
    {
        public AirportReadTransfer DepartureAirport { get; set; }

        public AirportReadTransfer ArrivalAirport { get; set; }

        public long Id { get; set; }
    }
}
