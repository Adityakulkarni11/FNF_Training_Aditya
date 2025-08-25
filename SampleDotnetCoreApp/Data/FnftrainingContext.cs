using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleDotnetCoreApp.Data;

public partial class FnftrainingContext : DbContext
{
    public FnftrainingContext()
    {
    }

    public FnftrainingContext(DbContextOptions<FnftrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptTable> DeptTables { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FNFTraining;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptTable>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DeptTabl__014881AEC5B98CC0");

            entity.ToTable("DeptTable");

            entity.Property(e => e.DeptName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB99E3D0C968");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpAddress).HasMaxLength(200);
            entity.Property(e => e.EmpName).HasMaxLength(50);
            entity.Property(e => e.EmpSalary).HasColumnType("money");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Employee__DeptId__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
