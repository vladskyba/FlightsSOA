using System;

namespace Flight.DataTransfer
{
    public class FlightBaseTransfer
    {
        public AirportReadTransfer DepartureAirport { get; set; }

        public AirportReadTransfer ArrivalAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public long AirplaneId { get; set; }

        public decimal Cost { get; set; }
    }
}
