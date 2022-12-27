using FlightService.Models.Replications;

namespace FlightService.Models.Replications
{
    public class AirplaneSeat : BaseEntity
    {
        public short Line { get; set; }

        public short Seat { get; set; }

        public bool IsActive { get; set; }

        public long PlaneId { get; set; } 

        public Airplane Plane { get; set; }
    }
}
