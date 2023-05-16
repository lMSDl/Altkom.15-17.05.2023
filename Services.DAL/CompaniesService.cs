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
        private readonly MyContext context;

        public CompaniesService(MyContext context) : base(context)
        {
            this.context = context;
        }

        public async override Task DeleteAsync(int id)
        {
            var entity = await context.Set<Company>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return;

            entity.IsDeleted = true;
            await UpdateAsync(id, entity);
        }
    }
}
