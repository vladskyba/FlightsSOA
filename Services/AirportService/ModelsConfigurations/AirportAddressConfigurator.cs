using Airport.Models;
using Airport.ModelsConfigurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.ModelsConfigurations
{
    internal class AirportAddressEntityConfigurator : BaseEntityConfigurator<AirportAddress>
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

            airportAddress.HasIndex(nameof(AirportAddress.City)).IsUnique();
            airportAddress.HasIndex(nameof(AirportAddress.Country)).IsUnique();
            airportAddress.HasIndex(nameof(AirportAddress.Zip)).IsUnique();
        }
    }
}