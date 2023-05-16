using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Models.Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class CompanyConfiguration : EntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Companies");

            builder.Ignore(x => x.Address);

            //ręczna konfiguracja dyskryminatora

            /* builder.HasDiscriminator<int>("Type")
                 .HasValue<Company>(1)
                 .HasValue<LargeCompany>(3)
                 .IsComplete(false);*/

            builder.HasDiscriminator<int>(x => x.Hash)
                .HasValue<Company>(typeof(Company).GetHashCode())
                .HasValue<AnotherCompany>(typeof(AnotherCompany).GetHashCode())
                .HasValue<LargeCompany>(typeof(LargeCompany).GetHashCode())
                //poinformowanie EF, że występuje więcej wartości dyskryminatorów niż jemu znane - wymusza dodawanie do zapytań filtrowania po dyskryminatorze
                //dzięki temu zamiast błędu otrzymujemy null
               .IsComplete(false);



            builder.Property(x => x.Hash).HasColumnName("Type");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
