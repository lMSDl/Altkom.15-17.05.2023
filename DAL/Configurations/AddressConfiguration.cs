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
    internal class AddressConfiguration : EntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.ToTable("Addresses");

            //klucz złożony
            //builder.HasKey(x => new { x.Street, x.City });

            //Informujemy EFCore, że encja nie ma klucza
            builder.HasNoKey();

            //indeks złożony
            builder.HasIndex(x => new { x.Street, x.City })
                .IncludeProperties(x => x.ZipCode);


        }
    }
}
