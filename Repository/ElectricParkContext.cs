using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ElectricParkContext : DbContext
    {
        public ElectricParkContext(DbContextOptions<ElectricParkContext> options) : base(options) { AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<ChargeSession> ChargeSessions { get; set; }
        public virtual DbSet<CompanyOwner> CompanyOwners { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
