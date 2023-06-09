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
    [Migration("20230516100856_TPC")]
    partial class TPC
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

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("'user' + CAST(NEXT VALUE FOR NumbersSequence AS varchar)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("User");
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
#pragma warning restore 612, 618
        }
    }
}
