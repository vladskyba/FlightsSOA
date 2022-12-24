using System;

namespace Flight.DataTransfer
{
    public class FlightBaseTransfer
    {
        public long DepartureAirportId { get; set; }

        public long ArrivalAirportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public long AirplaneId { get; set; }

        public decimal Cost { get; set; }
    }
}
