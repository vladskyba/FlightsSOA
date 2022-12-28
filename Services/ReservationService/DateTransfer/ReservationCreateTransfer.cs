using ReservationService.Models;
using System.Collections.Generic;

namespace ReservationService.DateTransfer
{
    public class ReservationCreateTransfer
    {
        public long UserId { get; set; }

        public long FlightId { get; set; }

        public ICollection<TicketBaseTransfer> Tickets { get; set; }

        public string Email { get; set; }
    }
}
