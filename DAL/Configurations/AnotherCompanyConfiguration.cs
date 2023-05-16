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
    internal class AnotherCompanyConfiguration : IEntityTypeConfiguration<AnotherCompany>
    {
        public void Configure(EntityTypeBuilder<AnotherCompany> builder)
        {
            //udostępnienie kolumny - ta sama właściwość (nazwa i typ zgodny) w różnych klsach ma być mapowana na wskazaną kolumnę
            builder.Property(x => x.OwnerName).HasColumnName(nameof(AnotherCompany.OwnerName));
        }
    }
}
