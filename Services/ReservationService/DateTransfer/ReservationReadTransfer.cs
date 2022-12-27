using ReservationService.Enums;
using System;
using System.Collections.Generic;

namespace ReservationService.DateTransfer
{
    public class ReservationReadTransfer : ReservationBaseTransfer
    {
        public long FlightId { get; set; }

        public DateTime ReservationDate { get; set; }

        public string Email { get; set; }

        public ICollection<TicketReadTransfer> Tickets { get; set; }
    }
}
