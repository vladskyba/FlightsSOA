using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Flight.Context
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }

        public DbSet<Models.Flight> Flight { get; set; }

        // Apply all of Entities Configurations presented in EntitiesConfigurations folder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
