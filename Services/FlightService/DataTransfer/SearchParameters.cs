using System;

namespace FlightService.DataTransfer
{
    public class SearchParameters
    {
        public long? DepartureAirportId { get; set; }

        public long? ArrivalAirportId { get; set; }

        public DateTime StartDeparture { get; set; }

        public DateTime EndDeparture { get; set; }
    }
}
