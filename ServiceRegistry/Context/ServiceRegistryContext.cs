using Microsoft.EntityFrameworkCore;
using ServicesRegistry.Models;

namespace ServiceRegistry.Context
{
    public class ServiceRegistryContext : DbContext
    {
        public ServiceRegistryContext(DbContextOptions<ServiceRegistryContext> options) : base(options)
        {

        }

        public DbSet<ServiceSettings> ServiceSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
