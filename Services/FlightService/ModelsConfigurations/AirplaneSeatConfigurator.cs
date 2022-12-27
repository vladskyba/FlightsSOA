using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightService.Models.Replications;
using FlightService.ModelsConfigurations;

namespace FlightService.ModelsConfigurations
{
    internal class AirplaneSeatConfigurator : ReplicationBaseConfigurator<AirplaneSeat>
    {
        public override void Configure(EntityTypeBuilder<AirplaneSeat> planeSeat)
        {
            base.Configure(planeSeat);

            planeSeat.ToTable(nameof(AirplaneSeat).ToSnakeCase())
                .HasKey(t => t.Id);

            planeSeat.HasOne(s => s.Plane)
                .WithMany(p => p.Seats)
                .HasForeignKey(k => k.PlaneId)
                .IsRequired();
        }
    }
}