using BE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BE.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }        
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<AppointmentReview> AppointmentReviews { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(b => b.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(b => b.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.ServicePackage)
                .WithMany(sp => sp.Subscriptions)
                .HasForeignKey(s => s.ServicePackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.SubscriptionDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Subscription>()
                .Property(s => s.Total)
                .HasColumnType("decimal(18, 2)");
            
            modelBuilder.Entity<ServicePackage>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Subscription)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.AppointmentDetail)
                .WithOne(ad => ad.Appointment)
                .HasForeignKey<AppointmentDetail>(ad => ad.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppointmentDetail>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<AppointmentDetail>()
                .Property(b => b.UpdatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<ServiceType>()
                .HasMany(st => st.ServicePackages)
                .WithOne(sp => sp.ServiceType)
                .HasForeignKey(sp => sp.ServiceTypeId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Shift)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ShiftId);

            modelBuilder.Entity<IdentityRole>().HasData(DataSeeder.ListRole.ToArray());
            //modelBuilder.Entity<ServiceType>().HasData(DataSeeder.ListServiceType.ToArray());
            //modelBuilder.Entity<ServicePackage>().HasData(DataSeeder.ListServicePackage.ToArray());
            modelBuilder.Entity<Shift>().HasData(DataSeeder.ListShift.ToArray());

        }
    }
}
