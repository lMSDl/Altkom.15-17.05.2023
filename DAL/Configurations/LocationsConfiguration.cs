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
    internal class LocationsConfiguration : EntityConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);
            //Table-splitting
            builder.ToTable("StandaloneAddresses");
        }
    }
}
