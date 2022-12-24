using Airport.ModelsConfigurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.ModelsConfigurations
{
    internal class AirportConfigurator : BaseEntityConfigurator<Models.Airport>
    {
        public override void Configure(EntityTypeBuilder<Models.Airport> airport)
        {
            base.Configure(airport);

            airport.ToTable(nameof(Airport).ToSnakeCase())
                .HasKey(t => t.Id);

            airport.HasOne(t => t.AirportAddress)
                .WithOne(st => st.Airport)
                .HasForeignKey<Models.Airport>(key => key.AirportAddressId)
                .IsRequired();

            airport.Property(a => a.AirportAddressId)
                .HasColumnName(nameof(Models.Airport.AirportAddressId).ToSnakeCase());

            airport.Property(a => a.Name)
                .HasColumnName(nameof(Models.Airport.Name).ToSnakeCase());

            airport.Property(a => a.Description)
                .HasColumnName(nameof(Models.Airport.Description).ToSnakeCase());

            airport.Property(a => a.IsActive)
                .HasColumnName(nameof(Models.Airport.IsActive).ToSnakeCase());
        }
    }
}