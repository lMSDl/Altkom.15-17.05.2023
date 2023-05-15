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
    public class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //wartość domyślna pobrana z kodu sql (pomijamy SELECT)
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            //nie możemy generować wartości zmiennych w czasie
            //builder.Property(x => x.ModifiedDate).HasComputedColumnSql("getdate()", true);
        }
    }
}
