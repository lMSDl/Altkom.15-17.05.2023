using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class PersonConfiguration : EntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Name)
                    .HasColumnName("FirstName")
                    .HasMaxLength(10);
            builder
                .Property(x => x.LastName)
                .HasDefaultValue("Unknown")
                    .IsRequired();
            builder
                .Property(x => x.PESEL)
            //.HasColumnType("decimal(11,0)");
                    .HasPrecision(11, 0);
            builder
                .Ignore(x => x.Address);

            //indeks unikalny
            builder.HasIndex(x => x.PESEL).IsUnique();

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Age).ValueGeneratedOnAdd();


            builder.Property(x => x.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored:true);
        }
    }
}
