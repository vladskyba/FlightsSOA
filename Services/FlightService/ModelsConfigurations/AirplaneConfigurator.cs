using FlightService.Models.Replications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.ModelsConfigurations
{
    internal class AirplaneConfigurator : ReplicationBaseConfigurator<Airplane>
    {
        public override void Configure(EntityTypeBuilder<Airplane> plane)
        {
            base.Configure(plane);

            plane.ToTable(nameof(Airplane).ToSnakeCase())
                .HasKey(t => t.Id);

            plane.HasMany(p => p.Seats)
                .WithOne(s => s.Plane)
                .HasForeignKey(k => k.PlaneId)
                .IsRequired();
        }
    }
}