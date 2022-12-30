using System.Collections.Generic;

namespace FlightService.Models.Replications
{
    public class Airport : BaseEntity
    {
        public string Name { get; set; }

        public long AirportAddressId { get; set; }

        public bool IsActive { get; set; }

        public AirportAddress AirportAddress { get; set; }

        public ICollection<Flight> DepartureFlights { get; set; }

        public ICollection<Flight> ArrivalFlights { get; set; }
    }
}
