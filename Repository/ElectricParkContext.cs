using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ElectricParkContext : DbContext
    {
        public ElectricParkContext(DbContextOptions<ElectricParkContext> options) : base(options) { }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<ChargeSession> ChargeSessions { get; set; }
        public virtual DbSet<CompanyOwner> CompanyOwners { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasOne(d => d.Company)
                .WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Driver_Company");

                entity.HasMany(d => d.ChargeSessions)
                .WithOne(p => p.Driver)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Driver_ChargeSession");

                entity.HasOne(d => d.Car)
                .WithOne(i => i.Driver)
                .HasForeignKey<Car>(b => b.DriverId);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasMany(d => d.ChargeSessions)
                .WithOne(p => p.Car)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Car_ChargeSession");

                entity.HasOne(d => d.Company)
                .WithMany(p => p.Cars)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Car_Company");
            });

            modelBuilder.Entity<CompanyOwner>(entity =>
            {
                entity.HasMany(d => d.Companies)
                .WithOne(p => p.CompanyOwner)
                .HasForeignKey(d => d.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CompanyOwner_Company");
            });
        }
    }
}
