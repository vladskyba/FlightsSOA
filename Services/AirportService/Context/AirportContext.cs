using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Airport.Context
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {

        }

        public DbSet<Models.Airport> Airport { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
