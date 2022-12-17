using PlaneTransport.Enums;
using System.Collections.Generic;

namespace PlaneTransport.Models
{
    public class Plane : BaseEntity
    {
        public string Name { get; set; }

        public PlaneType PlaneType { get; set; }

        public ICollection<PlaneSeat> Seats { get; set; }
    }
}
