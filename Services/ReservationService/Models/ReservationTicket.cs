using System;

namespace ReservationService.Models
{
    public class ReservationTicket : BaseEntity
    {
        public string DocumentIdentifier { get; set; }

        public string PersonName { get; set; }

        public string PersonSurname { get; set; }

        public string PersonLastName { get; set; }

        public DateTime PersonBirthDate { get; set; }

        public short Seat { get; set; }

        public short Line { get; set; }

        public long ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
