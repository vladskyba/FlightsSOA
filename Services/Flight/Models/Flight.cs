using Flight.Models.Replications;
using System;

namespace Flight.Models
{
    public class Flight : BaseEntity
    {
        public long DepartureAirportId { get; set; }

        public Airport DepartureAirport { get; set; }

        public long ArrivalAirportId { get; set; }

        public Airport ArrivalAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public long AirplaneId { get; set; }

        public decimal Cost { get; set; }
    }
}
