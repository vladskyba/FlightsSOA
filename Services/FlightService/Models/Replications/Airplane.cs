using FlightService.Models;
using FlightService.Models.Replications;
using System.Collections.Generic;

namespace FlightService.Models.Replications
{
    public class Airplane : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<AirplaneSeat> Seats { get; set; }
    }
}
