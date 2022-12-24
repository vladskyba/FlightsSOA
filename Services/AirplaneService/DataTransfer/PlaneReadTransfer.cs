using System.Collections.Generic;

namespace Airplane.DataTransfer
{
    public class PlaneReadTransfer : PlaneBaseTransfer
    {
        public long Id { get; set; }

        public ICollection<PlaneSeatReadTransfer> Seats { get; set; }
    }
}
