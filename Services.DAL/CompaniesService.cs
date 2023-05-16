using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL
{
    public class CompaniesService : Service<Company>
    {
        public CompaniesService(MyContext context) : base(context)
        {
        }
    }
}
