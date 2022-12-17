using Airport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.ModelsConfigurations
{
    internal class AirportEntityConfigurator : BaseEntityConfigurator<AirportEntity>
    {
        public override void Configure(EntityTypeBuilder<AirportEntity> airport)
        {
            base.Configure(airport);

            airport.ToTable("airport")
                .HasKey(t => t.Id);

            airport.HasOne(t => t.AirportAddress)
                .WithOne(st => st.Airport)
                .HasForeignKey<AirportEntity>(key => key.AirportAddressId)
                .IsRequired();
        }
    }
}