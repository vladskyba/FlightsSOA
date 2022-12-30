using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationService.Models;

namespace ReservationService.ModelsConfigurations
{
    public class ReservationTicketConfigurator : BaseEntityConfigurator<ReservationTicket>
    {
        public override void Configure(EntityTypeBuilder<ReservationTicket> ticket)
        {
            base.Configure(ticket);

            ticket.ToTable(nameof(ticket).ToSnakeCase())
                .HasKey(t => t.Id);

            ticket.HasOne(t => t.Reservation)
                .WithMany(r => r.Tickets)
                .HasForeignKey(key => key.ReservationId)
                .HasConstraintName("fk_reservation_id");

            ticket.Property(a => a.PersonName)
                .HasColumnName(nameof(ReservationTicket.PersonName).ToSnakeCase());

            ticket.Property(a => a.PersonLastName)
                .HasColumnName(nameof(ReservationTicket.PersonLastName).ToSnakeCase());

            ticket.Property(a => a.PersonSurname)
                .HasColumnName(nameof(ReservationTicket.PersonSurname).ToSnakeCase());

            ticket.Property(a => a.DocumentIdentifier)
                .HasColumnName(nameof(ReservationTicket.DocumentIdentifier).ToSnakeCase());

            ticket.Property(a => a.PersonBirthDate)
                .HasColumnName(nameof(ReservationTicket.PersonBirthDate).ToSnakeCase());
        }
    }
}
