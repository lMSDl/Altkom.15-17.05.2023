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

namespace DAL.Configurations.Relations
{
    internal class VehicleConfiguration : EntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Registration).WithOne(x => x.Vehicle)
                .HasForeignKey<Registration>("VehicleId").IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
