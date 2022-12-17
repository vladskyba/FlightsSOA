namespace PlaneTransport.Models
{
    public class PlaneSeat : BaseEntity
    {
        public short Line { get; set; }

        public short Seat { get; set; }

        public bool IsActive { get; set; }

        public long PlaneId { get; set; } 

        public Plane Plane { get; set; }
    }
}
