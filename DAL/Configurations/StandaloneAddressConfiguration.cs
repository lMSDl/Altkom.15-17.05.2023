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
    internal class StandaloneAddressConfiguration : EntityConfiguration<StandaloneAddress>
    {
        public override void Configure(EntityTypeBuilder<StandaloneAddress> builder)
        {
            base.Configure(builder);
            //Table-Splitting
            builder.ToTable("StandaloneAddresses");
            //konfigurujemy relację 1-1 wksazująć, że kluczem Location jest klucz klasy StandaloneAddress
            builder.HasOne(x => x.Location).WithOne().HasForeignKey<StandaloneAddress>(x => x.Id);
        }
    }
}
