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

            modelBuilder.Entity<Company>();

        }

        public DbSet<Person> People { get; }

    }
}
