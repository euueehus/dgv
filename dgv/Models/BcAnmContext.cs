using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dgv.Models;

public partial class BcAnmContext : DbContext
{
    public BcAnmContext()
    {
    }

    public BcAnmContext(DbContextOptions<BcAnmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Factory> Factories { get; set; }

    public virtual DbSet<IsSadataBase> IsSadatabases { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-AKOFLG1V\\SQLEXPRESS;Database=BC_ANM;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpolyeeId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpolyeeId).ValueGeneratedNever();
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Account");

            entity.HasOne(d => d.Factory).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FactoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Factory");
        });

        modelBuilder.Entity<Factory>(entity =>
        {
            entity.ToTable("Factory");

            entity.Property(e => e.FactoryId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.FactoryCode).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<IsSadataBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("IsSAdataBase");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MachinelId);

            entity.ToTable("Machine");

            entity.Property(e => e.MachinelId).ValueGeneratedNever();
            entity.Property(e => e.MachineCreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");

            entity.HasOne(d => d.Factory).WithMany(p => p.Machines)
                .HasForeignKey(d => d.FactoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Machine_Factory");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.CostMoney).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.ServiceCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Account");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductNo).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Factory).WithMany(p => p.Products)
                .HasForeignKey(d => d.FactoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Factory");

            entity.HasOne(d => d.Machinel).WithMany(p => p.Products)
                .HasForeignKey(d => d.MachinelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Machine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
