using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationService.Models.Replications;

namespace ReservationService.ModelsConfigurations
{
    public class FlightConfiguration : ReplicationBaseConfigurator<Flight>
    {
        public override void Configure(EntityTypeBuilder<Flight> flight)
        {
            base.Configure(flight);

            flight.ToTable(nameof(Flight).ToSnakeCase())
                .HasKey(t => t.Id);

            flight.HasOne(t => t.ArrivalAirport)
                .WithMany(a => a.ArrivalFlights)
                .HasForeignKey(key => key.ArrivalAirportId)
                .HasConstraintName("fk_arrival_airport")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            flight.HasOne(t => t.DepartureAirport)
                .WithMany(a => a.DepartureFlights)
                .HasForeignKey(key => key.DepartureAirportId)
                .HasConstraintName("fk_departure_airport")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            flight.Property(a => a.DepartureTime)
                .HasColumnName(nameof(Flight.DepartureTime).ToSnakeCase());

            flight.Property(a => a.ArrivalTime)
                .HasColumnName(nameof(Flight.ArrivalTime).ToSnakeCase());

            flight.Property(a => a.DepartureAirportId)
                .HasColumnName(nameof(Flight.DepartureAirportId).ToSnakeCase());

            flight.Property(a => a.AirplaneId)
                .HasColumnName(nameof(Flight.AirplaneId).ToSnakeCase());

            flight.Property(x => x.Cost).HasColumnType("decimal")
                .HasColumnName(nameof(Flight.Cost).ToSnakeCase());
        }
    }
}
