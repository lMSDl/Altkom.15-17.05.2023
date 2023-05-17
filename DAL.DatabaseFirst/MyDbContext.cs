using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.DatabaseFirst;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Educator> Educators { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<LocalAddress> LocalAddresses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<RemoteAddress> RemoteAddresses { get; set; }

    public virtual DbSet<StandaloneAddress> StandaloneAddresses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<SuperStudent> SuperStudents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=MyDb;Integrated security=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.Street, e.City }, "IX_Addresses_Street_City");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");

            entity.HasMany(d => d.Vehicles).WithMany(p => p.Drivers)
                .UsingEntity<Dictionary<string, object>>(
                    "DriverVehicle",
                    r => r.HasOne<Vehicle>().WithMany().HasForeignKey("VehiclesId"),
                    l => l.HasOne<Driver>().WithMany().HasForeignKey("DriversId"),
                    j =>
                    {
                        j.HasKey("DriversId", "VehiclesId");
                        j.ToTable("DriverVehicle");
                        j.HasIndex(new[] { "VehiclesId" }, "IX_DriverVehicle_VehiclesId");
                    });
        });

        modelBuilder.Entity<Educator>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Educator).HasForeignKey<Educator>(d => d.Id);
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.ToTable("Engine");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<LocalAddress>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.Street, e.City }, "IX_LocalAddresses_Street_City");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(e => e.Pesel, "IX_People_PESEL").IsUnique();

            entity.Property(e => e.Age).HasDefaultValueSql("(NEXT VALUE FOR [NumbersSequence])");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.FullName).HasComputedColumnSql("(([FirstName]+' ')+[LastName])", true);
            entity.Property(e => e.LastName).HasDefaultValueSql("(N'Unknown')");
            entity.Property(e => e.Pesel)
                .HasColumnType("decimal(11, 0)")
                .HasColumnName("PESEL");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.OrdersId, "IX_Product_OrdersId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Orders).WithMany(p => p.Products).HasForeignKey(d => d.OrdersId);
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.ToTable("Registration");

            entity.HasIndex(e => e.VehicleId, "IX_Registration_VehicleId")
                .IsUnique()
                .HasFilter("([VehicleId] IS NOT NULL)");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Vehicle).WithOne(p => p.Registration)
                .HasForeignKey<Registration>(d => d.VehicleId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<RemoteAddress>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.Street, e.City }, "IX_RemoteAddresses_Street_City");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<StandaloneAddress>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Student).HasForeignKey<Student>(d => d.Id);
        });

        modelBuilder.Entity<SuperStudent>(entity =>
        {
            entity.ToTable("SuperStudent");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.SuperStudent).HasForeignKey<SuperStudent>(d => d.Id);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("User");

            entity.Property(e => e.Username).HasDefaultValueSql("('user'+CONVERT([varchar],NEXT VALUE FOR [NumbersSequence]))");
            entity.Property(e => e.Type).HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("Vehicle");

            entity.HasIndex(e => e.EngineId, "IX_Vehicle_EngineId");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Engine).WithMany(p => p.Vehicles).HasForeignKey(d => d.EngineId);
        });
        modelBuilder.HasSequence<int>("NumbersSequence")
            .StartsAt(150L)
            .IncrementsBy(33)
            .HasMin(100L)
            .HasMax(200L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
