using Flight.Models.Replications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.ModelsConfigurations
{
    internal class AirportEntityConfigurator : BaseEntityConfigurator<Airport>
    {
        public override void Configure(EntityTypeBuilder<Airport> airport)
        {
            base.Configure(airport);

            airport.ToTable("airport")
                .HasKey(t => t.Id);

            airport.HasOne(t => t.AirportAddress)
                .WithOne(st => st.Airport)
                .HasForeignKey<Airport>(key => key.AirportAddressId)
                .IsRequired();
        }
    }
}