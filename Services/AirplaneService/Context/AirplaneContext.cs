using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Airplane.Models;

namespace Airplane.Context
{
    public class AirplaneContext : DbContext
    {
        public AirplaneContext(DbContextOptions<AirplaneContext> options) : base(options)
        {

        }

        public DbSet<Plane> Plane { get; set; }

        public DbSet<PlaneSeat> PlaneSeat { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
