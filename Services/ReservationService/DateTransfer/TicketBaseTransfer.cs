using System;

namespace ReservationService.DateTransfer
{
    public class TicketBaseTransfer
    {
        public string DocumentIdentifier { get; set; }

        public string PersonName { get; set; }

        public string PersonSurname { get; set; }

        public string PersonLastName { get; set; }

        public DateTime PersonBirthDate { get; set; }

        public short Seat { get; set; }

        public short Line { get; set; }
    }
}
