using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityFrameworkCoreSamples.Models;

namespace EntityFrameworkCoreSamples.Data
{
    public partial class WorkshopTestProjectDbContext : DbContext
    {
        public WorkshopTestProjectDbContext()
        {
        }

        public WorkshopTestProjectDbContext(DbContextOptions<WorkshopTestProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryHist> CountryHists { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyHist> CurrencyHists { get; set; }
        public virtual DbSet<DomainType> DomainTypes { get; set; }
        public virtual DbSet<DomainTypeHist> DomainTypeHists { get; set; }
        public virtual DbSet<DomainValue> DomainValues { get; set; }
        public virtual DbSet<DomainValueHist> DomainValueHists { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductHist> ProductHists { get; set; }
        public virtual DbSet<ProductsInStock> ProductsInStocks { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockHist> StockHists { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<TenantHist> TenantHists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserGroupHist> UserGroupHists { get; set; }
        public virtual DbSet<UserHist> UserHists { get; set; }
        public virtual DbSet<UserRight> UserRights { get; set; }
        public virtual DbSet<UserRightHist> UserRightHists { get; set; }
        public virtual DbSet<UserRightsRole> UserRightsRoles { get; set; }
        public virtual DbSet<UserRightsRoleHist> UserRightsRoleHists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WorkshopTestProjectDb");
                optionsBuilder.UseSqlServer("Data Source=LOCALHOST\\LOCALDB;Initial Catalog=WorkshopTestProjectDb; Trusted_Connection=True; TrustServerCertificate=True");
            }
    }
    //@"Server=LOCALHOST\LOCALDB; Database=WorkshopTestProjectDb; Trusted_Connection=True; TrustServerCertificate=True"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "core");

                entity.HasIndex(e => e.CurrencyId, "ix_coreCountry_CurrencyId");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreCountry_ModifiedUser");

                entity.Property(e => e.Id).HasComment("Id der Währung");

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Country")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryKey).HasMaxLength(3);

                entity.Property(e => e.ModifiedDate).HasComment("Datum der letzten Änderung");

                entity.Property(e => e.ModifiedUser).HasComment("Id des Benutzers der die letzte Änderung vorgenommen hat");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("fk_CoreCountry_CoreCurrency_CurrencyId");

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreCountry_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<CountryHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkCountry_Hist_Id");

                entity.ToTable("Country_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_Country_Hist_CountryId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CountryKey).HasMaxLength(3);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreCurrency_ModifiedUser");

                entity.Property(e => e.Currency1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Currency");

                entity.Property(e => e.CurrencyParts)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iso)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.Currencies)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreCurrency_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<CurrencyHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkCurrency_Hist_Id");

                entity.ToTable("Currency_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_Currency_Hist_CurrencyId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Currency).HasMaxLength(200);

                entity.Property(e => e.CurrencyParts).HasMaxLength(200);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.Iso).HasMaxLength(3);

                entity.Property(e => e.Region).HasMaxLength(200);
            });

            modelBuilder.Entity<DomainType>(entity =>
            {
                entity.ToTable("DomainType", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreDomainType_ModifiedUser");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')")
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.DomainTypes)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreDomainType_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<DomainTypeHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkDomainType_Hist_Id");

                entity.ToTable("DomainType_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_DomainType_Hist_DomainTypeId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.Mode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<DomainValue>(entity =>
            {
                entity.ToTable("DomainValue", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreDomainValue_ModifiedUser");

                entity.HasIndex(e => e.TenantId, "ix_coreDomainValue_TenantId");

                entity.HasIndex(e => e.TypeId, "ix_coreDomainValue_TypeId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Unit).HasMaxLength(100);

                entity.Property(e => e.ValueC).HasMaxLength(400);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.DomainValues)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreDomainValue_CoreUser_ModifiedUser");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.DomainValues)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreDomainValue_CoreTenant_TenantId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DomainValues)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreDomainValue_CoreDomainType_TypeId");
            });

            modelBuilder.Entity<DomainValueHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkDomainValue_Hist_Id");

                entity.ToTable("DomainValue_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_DomainValue_Hist_DomainValueId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.Unit).HasMaxLength(100);

                entity.Property(e => e.ValueC).HasMaxLength(400);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "core");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreProduct_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<ProductHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkProduct_Hist_Id");

                entity.ToTable("Product_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_Product_Hist_ProductId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.ProductName).HasMaxLength(200);
            });

            modelBuilder.Entity<ProductsInStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductsInStock", "core");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock", "core");

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreStock_CoreUser_ModifiedUser");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreStock_CoreProduct_ProductId");
            });

            modelBuilder.Entity<StockHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkStock_Hist_Id");

                entity.ToTable("Stock_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_Stock_Hist_StockId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreTenant_ModifiedUser");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TenantName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreTenant_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<TenantHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkTenant_Hist_Id");

                entity.ToTable("Tenant_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_Tenant_Hist_TenantId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.TenantName).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "core");

                entity.HasIndex(e => e.BusinessPartnerId, "ix_coreUser_BusinessPartnerId");

                entity.HasIndex(e => e.EmailLinkExtension, "ix_coreUser_EmailLinkExtension");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreUser_ModifiedUser");

                entity.HasIndex(e => e.PasswordLinkExtension, "ix_coreUser_PasswordLinkExtension");

                entity.HasIndex(e => e.State, "ix_coreUser_State");

                entity.HasIndex(e => e.TenantId, "ix_coreUser_TenantId");

                entity.HasIndex(e => e.Login, "ucUserLogin")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "uc_CoreUser_Email")
                    .IsUnique();

                entity.Property(e => e.DomainLogin)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(800);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NewEmail).HasMaxLength(800);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.State).HasDefaultValueSql("((376))");

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.InverseModifiedUserNavigation)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreUser_CoreUser_ModifiedUser");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkUserDomainValuesState");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreUser_CoreTenant_TenantId");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("UserGroup", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreUserGroup_ModifiedUser");

                entity.HasIndex(e => e.Group, "ucUserGroupGroup")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreUserGroup_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<UserGroupHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkUserGroup_Hist_Id");

                entity.ToTable("UserGroup_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_UserGroup_Hist_UserGroupId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Group).HasMaxLength(1000);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");
            });

            modelBuilder.Entity<UserHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkUser_Hist_Id");

                entity.ToTable("User_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_User_Hist_UserId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.DomainLogin).HasMaxLength(60);

                entity.Property(e => e.Email).HasMaxLength(800);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.NewEmail).HasMaxLength(800);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PasswordSalt).HasMaxLength(255);
            });

            modelBuilder.Entity<UserRight>(entity =>
            {
                entity.ToTable("UserRight", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreUserRight_ModifiedUser");

                entity.HasIndex(e => e.Right, "ucUserRightRight")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Right)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.UserRights)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreUserRight_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<UserRightHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkUserRight_Hist_Id");

                entity.ToTable("UserRight_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_UserRight_Hist_UserRightId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.Right).HasMaxLength(1000);
            });

            modelBuilder.Entity<UserRightsRole>(entity =>
            {
                entity.ToTable("UserRightsRole", "core");

                entity.HasIndex(e => e.ModifiedUser, "ix_coreUserRightsRole_ModifiedUser");

                entity.HasIndex(e => e.Role, "ucUserRightsRoleRole")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ModifiedUserNavigation)
                    .WithMany(p => p.UserRightsRoles)
                    .HasForeignKey(d => d.ModifiedUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoreUserRightsRole_CoreUser_ModifiedUser");
            });

            modelBuilder.Entity<UserRightsRoleHist>(entity =>
            {
                entity.HasKey(e => e.HistId)
                    .HasName("pkUserRightsRole_Hist_Id");

                entity.ToTable("UserRightsRole_Hist", "core");

                entity.HasIndex(e => e.Id, "ndx_core_UserRightsRole_Hist_UserRightsRoleId");

                entity.Property(e => e.HistId).HasColumnName("Hist_Id");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.HistAction)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Hist_Action")
                    .IsFixedLength();

                entity.Property(e => e.HistDate).HasColumnName("Hist_Date");

                entity.Property(e => e.Role).HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
