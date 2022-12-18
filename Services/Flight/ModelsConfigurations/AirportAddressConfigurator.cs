using Flight.Models.Replications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.ModelsConfigurations
{
    public class AirportAddressEntityConfigurator : BaseEntityConfigurator<AirportAddress>
    {
        public override void Configure(EntityTypeBuilder<AirportAddress> airport)
        {
            base.Configure(airport);

            airport.ToTable("airport_address")
                .HasKey(t => t.Id);
        }
    }
}