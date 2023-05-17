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

            builder.HasOne(x => x.Engine).WithMany(x => x.Vehicles);
            /*builder.HasOne(x => x.Engine).WithMany();
            builder.HasOne<Engine>().WithMany(x => x.Vehicles);*/

            builder.HasMany(x => x.Drivers).WithMany(x => x.Vehicles);
            /*builder.HasMany<Driver>().WithMany(x => x.Vehicles)
                .UsingEntity("DriverVehicle",
                    x => x.HasOne(typeof(Driver)).WithMany().HasForeignKey("DriversId").HasPrincipalKey(nameof(Driver.Id)),
                    x => x.HasOne(typeof(Vehicle)).WithMany().HasForeignKey("VehiclesId").HasPrincipalKey(nameof(Vehicle.Id)),
                    x => x.HasKey("DriversId", "VehiclesId"));*/
            /*builder.HasMany<Driver>().WithMany()
                .UsingEntity("DriverVehicle",
                    x => x.HasOne(typeof(Driver)).WithMany().HasForeignKey("DriversId").HasPrincipalKey(nameof(Driver.Id)),
                    x => x.HasOne(typeof(Vehicle)).WithMany().HasForeignKey("VehiclesId").HasPrincipalKey(nameof(Vehicle.Id)),
                    x => x.HasKey("DriversId", "VehiclesId"));*/
        }
    }
}
