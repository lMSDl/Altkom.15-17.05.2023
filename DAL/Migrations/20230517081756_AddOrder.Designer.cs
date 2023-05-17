﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230517081756_AddOrder")]
    partial class AddOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence<int>("NumbersSequence")
                .StartsAt(150L)
                .IncrementsBy(33)
                .HasMin(100L)
                .HasMax(200L)
                .IsCyclic();

            modelBuilder.Entity("DriverVehicle", b =>
                {
                    b.Property<int>("DriversId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("DriversId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("DriverVehicle");
                });

            modelBuilder.Entity("Models.Address", b =>
                {
                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("Street", "City");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Street", "City"), new[] { "ZipCode" });

                    b.ToTable("Addresses", (string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Hash")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies", (string)null);

                    b.HasDiscriminator<int>("Hash").IsComplete(false).HasValue(62809978);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StandaloneAddresses", (string)null);
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR NumbersSequence");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]", true);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Unknown");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("FirstName");

                    b.Property<decimal>("PESEL")
                        .HasPrecision(11)
                        .HasColumnType("decimal(11,0)");

                    b.HasKey("Id");

                    b.HasIndex("PESEL")
                        .IsUnique();

                    b.ToTable("People");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique()
                        .HasFilter("[VehicleId] IS NOT NULL");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("Models.StandaloneAddress", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StandaloneAddresses", (string)null);
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("'user' + CAST(NEXT VALUE FOR NumbersSequence AS varchar)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Username = "admin",
                            Password = "YWRtaW4=",
                            Type = "Admin"
                        },
                        new
                        {
                            Username = "some user",
                            Password = "bm9uZQ==",
                            Type = "Anonymouse"
                        });
                });

            modelBuilder.Entity("Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("EngineId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Models.Inheritance.LocalAddress", b =>
                {
                    b.HasBaseType("Models.Address");

                    b.ToTable("LocalAddresses", (string)null);
                });

            modelBuilder.Entity("Models.Inheritance.RemoteAddress", b =>
                {
                    b.HasBaseType("Models.Address");

                    b.ToTable("RemoteAddresses", (string)null);
                });

            modelBuilder.Entity("Models.Inheritance.AnotherCompany", b =>
                {
                    b.HasBaseType("Models.Company");

                    b.Property<int>("NumberOfWorkers")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OwnerName");

                    b.HasDiscriminator().HasValue(13202999);
                });

            modelBuilder.Entity("Models.Inheritance.LargeCompany", b =>
                {
                    b.HasBaseType("Models.Company");

                    b.Property<string>("CoOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWorkers")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OwnerName");

                    b.HasDiscriminator().HasValue(52983808);
                });

            modelBuilder.Entity("Models.Inheritance.Educator", b =>
                {
                    b.HasBaseType("Models.Person");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Educators", (string)null);
                });

            modelBuilder.Entity("Models.Inheritance.Student", b =>
                {
                    b.HasBaseType("Models.Person");

                    b.Property<int>("IndexNumber")
                        .HasColumnType("int");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Models.Inheritance.SuperStudent", b =>
                {
                    b.HasBaseType("Models.Inheritance.Student");

                    b.Property<string>("SuperAbility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SuperStudent");
                });

            modelBuilder.Entity("DriverVehicle", b =>
                {
                    b.HasOne("Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.HasOne("Models.Order", "Orders")
                        .WithMany("Products")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.Registration", b =>
                {
                    b.HasOne("Models.Vehicle", "Vehicle")
                        .WithOne("Registration")
                        .HasForeignKey("Models.Registration", "VehicleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Models.StandaloneAddress", b =>
                {
                    b.HasOne("Models.Location", "Location")
                        .WithOne()
                        .HasForeignKey("Models.StandaloneAddress", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Models.Vehicle", b =>
                {
                    b.HasOne("Models.Engine", "Engine")
                        .WithMany("Vehicles")
                        .HasForeignKey("EngineId");

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("Models.Inheritance.Educator", b =>
                {
                    b.HasOne("Models.Person", null)
                        .WithOne()
                        .HasForeignKey("Models.Inheritance.Educator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Inheritance.Student", b =>
                {
                    b.HasOne("Models.Person", null)
                        .WithOne()
                        .HasForeignKey("Models.Inheritance.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Inheritance.SuperStudent", b =>
                {
                    b.HasOne("Models.Inheritance.Student", null)
                        .WithOne()
                        .HasForeignKey("Models.Inheritance.SuperStudent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Engine", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.Vehicle", b =>
                {
                    b.Navigation("Registration");
                });
#pragma warning restore 612, 618
        }
    }
}
