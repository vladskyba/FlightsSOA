using Airplane.Enums;
using System.Collections.Generic;

namespace Airplane.Models
{
    public class Plane : BaseEntity
    {
        public string Name { get; set; }

        public PlaneType PlaneType { get; set; }

        public ICollection<PlaneSeat> Seats { get; set; }
    }
}
