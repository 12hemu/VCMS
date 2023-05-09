using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VCMS411.Models
{
    public partial class VCMS_81411Context : DbContext
    {
        public VCMS_81411Context()
        {
        }

        public VCMS_81411Context(DbContextOptions<VCMS_81411Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ClaimDetails> ClaimDetails { get; set; }
        public virtual DbSet<InsuranceCompanyDetails> InsuranceCompanyDetails { get; set; }
        public virtual DbSet<PolicyDetails> PolicyDetails { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<VehicleDetails> VehicleDetails { get; set; }

        // Unable to generate entity type for table 'dbo.Login_Details'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=VCMS_81411;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimDetails>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("Claim_Details");

                entity.HasIndex(e => e.BankAccountNo)
                    .HasName("UQ__Claim_De__0B35901B68FF9F8B")
                    .IsUnique();

                entity.HasIndex(e => e.DriverLicenseNo)
                    .HasName("UQ__Claim_De__88AD88F2B2EA70DC")
                    .IsUnique();

                entity.HasIndex(e => e.IfscCode)
                    .HasName("UQ__Claim_De__00EF9F3FDF32B7F8")
                    .IsUnique();

                entity.HasIndex(e => e.VehicleBill)
                    .HasName("UQ__Claim_De__DD7DE135E405D4BA")
                    .IsUnique();

                entity.Property(e => e.ClaimId).HasColumnName("Claim_Id");

                entity.Property(e => e.BankAccountNo)
                    .IsRequired()
                    .HasColumnName("Bank_AccountNo")
                    .HasMaxLength(20);

                entity.Property(e => e.BankBranch)
                    .IsRequired()
                    .HasColumnName("Bank_Branch")
                    .HasMaxLength(20);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("Bank_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.ClaimAmount).HasColumnName("Claim_Amount");

                entity.Property(e => e.ClaimDocuments)
                    .IsRequired()
                    .HasColumnName("Claim_Documents")
                    .HasMaxLength(1);

                entity.Property(e => e.ClaimReason)
                    .IsRequired()
                    .HasColumnName("Claim_Reason")
                    .HasMaxLength(50);

                entity.Property(e => e.ClaimStatus)
                    .IsRequired()
                    .HasColumnName("Claim_Status")
                    .HasMaxLength(20);

                entity.Property(e => e.DriverLicenseNo)
                    .IsRequired()
                    .HasColumnName("Driver_License_No")
                    .HasMaxLength(20);

                entity.Property(e => e.IfscCode)
                    .IsRequired()
                    .HasColumnName("IFSC_Code")
                    .HasMaxLength(20);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.VehicleBill)
                    .IsRequired()
                    .HasColumnName("Vehicle_Bill")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.ClaimDetails)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__Claim_Det__Polic__114A936A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClaimDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Claim_Det__User___10566F31");
            });

            modelBuilder.Entity<InsuranceCompanyDetails>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("Insurance_Company_Details");

                entity.HasIndex(e => e.CompanyContact)
                    .HasName("UQ__Insuranc__0713D0CCADE87D64")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyName)
                    .HasName("UQ__Insuranc__F32A5ED9F8B52F2E")
                    .IsUnique();

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasColumnName("Company_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyContact)
                    .IsRequired()
                    .HasColumnName("Company_Contact")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PolicyDetails>(entity =>
            {
                entity.HasKey(e => e.PolicyId);

                entity.ToTable("Policy_Details");

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("Expiry_Date")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyAmount).HasColumnName("Policy_Amount");

                entity.Property(e => e.PolicyName)
                    .IsRequired()
                    .HasColumnName("Policy_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PolicyDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Policy_De__Compa__09A971A2");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.PolicyDetails)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Policy_De__Vehic__08B54D69");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_Details");

                entity.HasIndex(e => e.LicenceNo)
                    .HasName("UQ__User_Det__012F257CEBCF7F8F")
                    .IsUnique();

                entity.HasIndex(e => e.UserContact)
                    .HasName("UQ__User_Det__C84FD24DFCD4D2F6")
                    .IsUnique();

                entity.HasIndex(e => e.UserEmail)
                    .HasName("UQ__User_Det__4C70A05C36110E89")
                    .IsUnique();

                entity.HasIndex(e => e.UserPassword)
                    .HasName("UQ__User_Det__4525F7D8E38BD5F3")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.LicenceNo)
                    .IsRequired()
                    .HasColumnName("Licence_No")
                    .HasMaxLength(50);

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasColumnName("User_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.UserAge).HasColumnName("User_Age");

                entity.Property(e => e.UserContact)
                    .IsRequired()
                    .HasColumnName("User_Contact")
                    .HasMaxLength(10);

                entity.Property(e => e.UserCountry)
                    .IsRequired()
                    .HasColumnName("User_Country")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("User_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("User_Password")
                    .HasMaxLength(50);

                entity.Property(e => e.UserState)
                    .IsRequired()
                    .HasColumnName("User_State")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VehicleDetails>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("Vehicle_Details");

                entity.HasIndex(e => e.VehicleNo)
                    .HasName("UQ__Vehicle___CE6D04645B71C73B")
                    .IsUnique();

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.Property(e => e.FuelType)
                    .IsRequired()
                    .HasColumnName("Fuel_Type")
                    .HasMaxLength(1);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.VehicleModel)
                    .IsRequired()
                    .HasColumnName("Vehicle_Model")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleNo)
                    .IsRequired()
                    .HasColumnName("Vehicle_No")
                    .HasMaxLength(20);

                entity.Property(e => e.VehiclePrice).HasColumnName("Vehicle_Price");

                entity.Property(e => e.VehiclePurchasedDate)
                    .HasColumnName("Vehicle_PurchasedDate")
                    .HasColumnType("date");

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasColumnName("Vehicle_Type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VehicleDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Vehicle_D__User___05D8E0BE");
            });
        }
    }
}
