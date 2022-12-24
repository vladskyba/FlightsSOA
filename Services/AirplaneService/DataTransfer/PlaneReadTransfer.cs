using System.Collections.Generic;

namespace PlaneTransport.DataTransfer
{
    public class PlaneReadTransfer : PlaneBaseTransfer
    {
        public long Id { get; set; }

        public ICollection<PlaneSeatReadTransfer> Seats { get; set; }
    }
}
