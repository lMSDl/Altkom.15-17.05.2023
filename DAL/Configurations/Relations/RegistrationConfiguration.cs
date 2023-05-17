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
    internal class RegistrationConfiguration : EntityConfiguration<Registration>
    {
        public override void Configure(EntityTypeBuilder<Registration> builder)
        {
            base.Configure(builder);

            /*builder.HasOne(x => x.Vehicle).WithOne(x => x.Registration)
                .HasForeignKey<Registration>("VehicleId");*/
        }
    }
}
