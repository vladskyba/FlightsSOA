using Flight.Models.Replications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.ModelsConfigurations
{
    public class AirportAddressEntityConfigurator : ReplicationBaseConfigurator<AirportAddress>
    {
        public override void Configure(EntityTypeBuilder<AirportAddress> airportAddress)
        {
            base.Configure(airportAddress);

            airportAddress.ToTable(nameof(AirportAddress).ToSnakeCase())
                .HasKey(t => t.Id);

            airportAddress.Property(a => a.Country)
                .HasColumnName(nameof(AirportAddress.Country).ToSnakeCase());

            airportAddress.Property(a => a.City)
                .HasColumnName(nameof(AirportAddress.City).ToSnakeCase());

            airportAddress.Property(a => a.Zip)
                .HasColumnName(nameof(AirportAddress.Zip).ToSnakeCase());

            airportAddress.Property(a => a.AirportId)
                .HasColumnName(nameof(AirportAddress.AirportId).ToSnakeCase());
        }
    }
}