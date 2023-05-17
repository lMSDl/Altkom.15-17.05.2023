using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class KeyConfiguration : IEntityTypeConfiguration<KeyTest>
    {
        public void Configure(EntityTypeBuilder<KeyTest> builder)
        {

            //builder.Property(x => x.Value).IsConcurrencyToken();

            builder.Property(x => x.Timestamp).IsRowVersion();
        }
    }
}
