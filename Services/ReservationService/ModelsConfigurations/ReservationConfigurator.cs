using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReservationService.Models;

namespace ReservationService.ModelsConfigurations
{
    public class ReservationConfigurator : BaseEntityConfigurator<Reservation>
    {
        public override void Configure(EntityTypeBuilder<Reservation> reservation)
        {
            base.Configure(reservation);

            reservation.ToTable(nameof(Reservation).ToSnakeCase())
                .HasKey(t => t.Id);

            reservation.HasMany(r => r.Tickets)
                .WithOne(t => t.Reservation)
                .HasForeignKey(key => key.ReservationId)
                .HasConstraintName("fk_reservation_id");

            reservation.Property(a => a.ReservationDate)
                .HasColumnName(nameof(Reservation.ReservationDate).ToSnakeCase());

            reservation.Property(a => a.Status)
                .HasColumnName(nameof(Reservation.Status).ToSnakeCase());

            reservation.Property(a => a.Email)
                .HasColumnName(nameof(Reservation.Email).ToSnakeCase());
        }
    }
}
