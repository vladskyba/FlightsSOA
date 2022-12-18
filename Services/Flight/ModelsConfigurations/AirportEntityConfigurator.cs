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

            airport.ToTable(nameof(Airport).ToSnakeCase())
                .HasKey(t => t.Id);

            airport.HasOne(t => t.AirportAddress)
                .WithOne(st => st.Airport)
                .HasForeignKey<Airport>(key => key.AirportAddressId)
                .IsRequired();

            airport.Property(a => a.AirportAddressId)
                .HasColumnName(nameof(Airport.AirportAddressId).ToSnakeCase());

            airport.Property(a => a.Name)
                .HasColumnName(nameof(Airport.Name).ToSnakeCase());

            airport.Property(a => a.IsActive)
                .HasColumnName(nameof(Airport.IsActive).ToSnakeCase());
        }
    }
}