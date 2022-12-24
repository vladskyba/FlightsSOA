using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Airplane.Models;

namespace Airplane.ModelsConfigurations
{
    internal class PlaneSeatConfigurator : BaseEntityConfigurator<PlaneSeat>
    {
        public override void Configure(EntityTypeBuilder<PlaneSeat> planeSeat)
        {
            base.Configure(planeSeat);

            planeSeat.ToTable("plane_seat")
                .HasKey(t => t.Id);

            planeSeat.HasOne(s => s.Plane)
                .WithMany(p => p.Seats)
                .HasForeignKey(k => k.PlaneId)
                .IsRequired();
        }
    }
}