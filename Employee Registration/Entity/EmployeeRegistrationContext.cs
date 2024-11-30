using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee_Registration.Entity;

public partial class EmployeeRegistrationContext : DbContext
{
    public EmployeeRegistrationContext()
    {
    }

    public EmployeeRegistrationContext(DbContextOptions<EmployeeRegistrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountryMst> CountryMsts { get; set; }

    public virtual DbSet<EmployeeMst> EmployeeMsts { get; set; }

    public virtual DbSet<StateMst> StateMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Employee Registration;uid=Sachin;password=root;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country___3214EC07B4F26B61");

            entity.ToTable("Country_Mst");

            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Country_Name");
        });

        modelBuilder.Entity<EmployeeMst>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__781134A19F0EE13E");

            entity.ToTable("Employee_Mst");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.MobileNum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Mobile_Num");
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("State_Id");

            entity.HasOne(d => d.Country).WithMany(p => p.EmployeeMsts)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Employee___Count__2A4B4B5E");

            entity.HasOne(d => d.State).WithMany(p => p.EmployeeMsts)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Employee___State__29572725");
        });

        modelBuilder.Entity<StateMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__State_Ms__3214EC07C737E9F9");

            entity.ToTable("State_Mst");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("State_Name");

            entity.HasOne(d => d.Country).WithMany(p => p.StateMsts)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__State_Mst__Count__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
