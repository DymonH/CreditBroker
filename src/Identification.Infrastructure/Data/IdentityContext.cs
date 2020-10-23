using Hlopov.CreditBroker.Identification.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hlopov.CreditBroker.Identification.Infrastructure.Data
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArmUser> ArmUsers { get; set; }

        public DbSet<ArmUserPhone> ArmUserPhones { get; set; }

        public DbSet<ArmUserPhoneType> ArmUserPhoneTypes { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<UserDevice> UserDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ArmUser>(ConfigureArmUser);
            builder.Entity<ArmUserPhone>(ConfigureArmUserPhone);
            builder.Entity<ArmUserPhoneType>(ConfigureArmUserPhoneType);
            builder.Entity<Department>(ConfigureDepartment);
            builder.Entity<Position>(ConfigurePosition);
            builder.Entity<UserDevice>(ConfigureUserDevice);
        }

        private void ConfigureArmUser(EntityTypeBuilder<ArmUser> builder)
        {
            builder.ToTable("ArmUsers");
            builder.HasKey(ci => ci.Id);
            builder.HasIndex(ci => ci.Login);
            builder.HasIndex(ci => ci.Name);
            builder.HasIndex(ci => ci.RecoveryToken);
            builder.HasIndex(ci => ci.DepartmentId);

            builder
                .HasOne(ci => ci.Department)
                .WithMany(d => d.ArmUsers);
            
            builder.Property(ci => ci.BirthDate)
                .IsRequired();
            
            builder.Property(ci => ci.CreateDate)
                .IsRequired();
            
            builder.Property(ci => ci.IsActive)
                .IsRequired();
            
            builder.Property(ci => ci.Login)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(ci => ci.PositionId)
                .IsRequired();
        }

        private void ConfigureArmUserPhone(EntityTypeBuilder<ArmUserPhone> builder)
        {
            builder.ToTable("ArmUserPhones");
            builder.HasKey(ci => ci.Id);
            builder.HasIndex(ci => ci.ArmUserId);
            builder.HasIndex(ci => ci.ArmUserPhoneTypeId);

            builder.Property(ci => ci.ArmUserId)
                .IsRequired();

            builder.Property(ci => ci.ArmUserPhoneTypeId)
                .IsRequired();
        }

        private void ConfigureArmUserPhoneType(EntityTypeBuilder<ArmUserPhoneType> builder)
        {
            builder.ToTable("ArmUserPhoneTypes");
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Type)
                .HasMaxLength(255)
                .IsRequired();
        }

        private void ConfigureDepartment(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(ci => ci.Id);
            builder.HasIndex(ci => ci.Name);
            builder.HasIndex(ci => ci.DepartmentHeadId);

            builder
                .HasOne(ci => ci.DepartmentHead)
                .WithMany(u => u.LeadedDepartments);

            builder.Property(ci => ci.Name)
                .HasMaxLength(255)
                .IsRequired();
        }

        private void ConfigurePosition(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .HasMaxLength(255)
                .IsRequired();
        }

        private void ConfigureUserDevice(EntityTypeBuilder<UserDevice> builder)
        {
            builder.ToTable("UserDevices");
            builder.HasKey(ci => ci.Id);
            builder.HasIndex(ci => ci.ArmUserId);
            builder.HasIndex(ci => ci.Token);

            builder.Property(ci => ci.Name)
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(ci => ci.Token)
                .HasMaxLength(1024)
                .IsRequired(false);
        }
    }
}