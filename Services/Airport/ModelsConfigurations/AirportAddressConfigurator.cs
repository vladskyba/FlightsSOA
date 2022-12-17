using Airport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.ModelsConfigurations
{
    internal class AirportAddressEntityConfigurator : BaseEntityConfigurator<AirportAddress>
    {
        public override void Configure(EntityTypeBuilder<AirportAddress> airport)
        {
            base.Configure(airport);

            airport.ToTable("airport_address")
                .HasKey(t => t.Id);
        }
    }
}