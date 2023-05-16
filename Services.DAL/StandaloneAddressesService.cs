using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL
{
    public class StandaloneAddressesService : Service<StandaloneAddress>
    {
        private DbContext _context;

        public StandaloneAddressesService(DbContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<IEnumerable<StandaloneAddress>> ReadAsync()
        {

            //Eager Loading
            /*return await _context.Set<StandaloneAddress>()
                .Include(x => x.Location)*//*.ThenInclude(x => x.)*//*
                .AsNoTracking().ToListAsync();*/

            //Explicit Loading
            /*var result = await _context.Set<StandaloneAddress>().ToListAsync();
            //zaciągnięcie całej tabeli do contextu
            await _context.Set<Location>().LoadAsync();*/

            //Lazy Loading (z użyciem proxy lub ILazyLoading)
            var result = await _context.Set<StandaloneAddress>().ToListAsync(); _context.Dispose();


            return result;

        }

        public async override Task<StandaloneAddress?> ReadAsync(int id)
        {
            //Explicit Loading
            var result = await _context.Set<StandaloneAddress>().SingleOrDefaultAsync(x => x.Id == id);
            if(result != null)
                //zaciągnięcie pojedynczej wskazanej referencji do contextu
                await _context.Entry(result).Reference(x => x.Location).LoadAsync();


            return result;
        }
    }
}
