﻿using System.Collections.Generic;

namespace Flight.Models.Replications
{
    public class Airport : ExternalBase
    {
        public string Name { get; set; }

        public long AirportAddressId { get; set; }

        public AirportAddress AirportAddress { get; set; }

        public ICollection<Flight> DepartureFlights { get; set; }

        public ICollection<Flight> ArrivalFlights { get; set; }
    }
}
