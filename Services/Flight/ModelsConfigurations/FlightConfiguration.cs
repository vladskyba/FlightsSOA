using Flight.Models.Replications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.ModelsConfigurations
{
    public class FlightConfiguration : BaseEntityConfigurator<Models.Flight>
    {
        public override void Configure(EntityTypeBuilder<Models.Flight> flight)
        {
            base.Configure(flight);

            flight.ToTable("flight")
                .HasKey(t => t.Id);

            //flight.HasOne(t => t.ArrivalAirport)
            //    .WithMany(a => a.ArrivalFlights)
            //    .HasForeignKey(key => key.ArrivalAirportId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired();

            flight.HasOne(t => t.DepartureAirport)
                .WithMany(a => a.DepartureFlights)
                .HasForeignKey(key => key.DepartureAirportId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
