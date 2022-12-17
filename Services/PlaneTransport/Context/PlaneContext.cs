using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlaneTransport.Models;

namespace PlaneTransport.Context
{
    public class PlaneContext : DbContext
    {
        public PlaneContext(DbContextOptions<PlaneContext> options) : base(options)
        {

        }

        public DbSet<Plane> Plane { get; set; }

        // Apply all of Entities Configurations presented in EntitiesConfigurations folder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
