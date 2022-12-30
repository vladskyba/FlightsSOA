using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReservationService.Models;
using ReservationService.Models.Replications;

namespace ReservationService.Context
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {

        }

        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<ReservationTicket> Tickets { get; set; }

        public DbSet<Flight> FlightsReplications { get; set; }

        // Apply all of Entities Configurations presented in EntitiesConfigurations folder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
