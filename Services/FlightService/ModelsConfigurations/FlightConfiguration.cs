using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.ModelsConfigurations
{
    public class FlightConfiguration : BaseEntityConfigurator<Models.Flight>
    {
        public override void Configure(EntityTypeBuilder<Models.Flight> flight)
        {
            base.Configure(flight);

            flight.ToTable(nameof(Models.Flight).ToSnakeCase())
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
                .HasColumnName(nameof(Models.Flight.DepartureTime).ToSnakeCase());

            flight.Property(a => a.ArrivalTime)
                .HasColumnName(nameof(Models.Flight.ArrivalTime).ToSnakeCase());

            flight.Property(a => a.DepartureAirportId)
                .HasColumnName(nameof(Models.Flight.DepartureAirportId).ToSnakeCase());

            flight.Property(a => a.AirplaneId)
                .HasColumnName(nameof(Models.Flight.AirplaneId).ToSnakeCase());

            flight.Property(x => x.Cost).HasColumnType("decimal")
                .HasColumnName(nameof(Models.Flight.Cost).ToSnakeCase());
        }
    }
}
