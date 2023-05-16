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
    //jeśli jakaś klasa ze środka hierarchii dziedziczenia nie będzie skonfigurowana w EF, nie będziemy mogli z niej korzystać - mimo że jej kolumny będą w tabeli
    internal class SmallCompanyConfiguration //: IEntityTypeConfiguration<SmallCompany>
    {
        public void Configure(EntityTypeBuilder<SmallCompany> builder)
        {
        }
    }
}
