using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyContext : DbContext
    {
        private string _connectionString;

        public MyContext() { }

        public MyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MyContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
            {
                if (_connectionString != null)
                    optionsBuilder.UseSqlServer(_connectionString);
                else
                    optionsBuilder.UseSqlServer();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Company>().ToTable("Companies");

            //modelBuilder.Entity<Address>().ToTable("Addresses");

            /*modelBuilder.Entity<Person>()
                .Property(x => x.Name)
                    .HasColumnName("FirstName")
                    .HasMaxLength(10);
            modelBuilder.Entity<Person>()
                .Property(x => x.LastName)
                    .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(x => x.PESEL)
                    //.HasColumnType("decimal(11,0)");
                    .HasPrecision(11, 0);
            modelBuilder.Entity<Person>()
                .Ignore(x => x.Address);*/

            //ręczne dodawanie konfiguracji
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new AddressConfiguration());
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());

            //automatyczne dodawanie konfiguracji ze wskazanego assembly (wyszukuje klasy implementujące IEntityTypeConfiguration)
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            //pominięcie mapowania wskazanego typu
            //modelBuilder.Ignore<Address>();


            modelBuilder.HasSequence<int>("NumbersSequence")
                .StartsAt(150)
                .HasMin(100)
                .HasMax(200)
                .IncrementsBy(33)
                .IsCyclic();

            modelBuilder.Entity<OrderSummary>().ToTable(name: null);
        }

        public DbSet<Person> People { get; }




        public override int SaveChanges()
        {
            ChangeTracker.Entries<Entity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList()
                .ForEach(x => x.ModifiedDate = DateTime.Now);

            return base.SaveChanges();
        }
    }
}
