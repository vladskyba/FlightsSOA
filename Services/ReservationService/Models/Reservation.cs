using ReservationService.Enums;
using ReservationService.Models.Replications;
using System;
using System.Collections.Generic;

namespace ReservationService.Models
{
    public class Reservation : BaseEntity
    {
        public DateTime ReservationDate { get; set; }

        public string Email { get; set; }

        public ReservationStatus Status { get; set; }

        public long FlightId { get; set; }

        public long UserId { get; set; }

        public Flight Flight { get; set; }

        public ICollection<ReservationTicket> Tickets { get; set; }
    }
}
