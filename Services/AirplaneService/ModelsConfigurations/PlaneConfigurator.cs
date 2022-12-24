using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Airplane.Models;

namespace Airplane.ModelsConfigurations
{
    internal class PlaneConfigurator : BaseEntityConfigurator<Plane>
    {
        public override void Configure(EntityTypeBuilder<Plane> plane)
        {
            base.Configure(plane);

            plane.ToTable("plane")
                .HasKey(t => t.Id);

            plane.HasMany(p => p.Seats)
                .WithOne(s => s.Plane)
                .HasForeignKey(k => k.PlaneId)
                .IsRequired();
        }
    }
}