using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Username);

            builder.Property(x => x.Username).HasDefaultValueSql("'user' + CAST(NEXT VALUE FOR NumbersSequence AS varchar)");


            /*builder.Property(x => x.Type).HasConversion(
                @enum => @enum.ToString(),
                @string => Enum.Parse<UserTypes>(@string));*/

            //builder.Property(x => x.Type).HasConversion(new EnumToStringConverter<UserTypes>());
            builder.Property(x => x.Type).HasConversion<string>();

            builder.Property(x => x.Password).HasConversion(x => Convert.ToBase64String(Encoding.Default.GetBytes(x)),
                                                            x => Encoding.Default.GetString(Convert.FromBase64String(x)));
        }
    }
}
