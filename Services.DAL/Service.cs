using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Services.DAL
{
    public class Service<T> : IService<T> where T : Entity
    {
        private readonly DbContext _context;

        public Service(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var entry = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await ReadAsync(id);
            if (entity == null)
                return;
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual Task<T?> ReadAsync(int id)
        {
            //return _context.Set<T>().FindAsync(id).AsTask();
            // wyłączenie śledzenia encji (lokalne) - pozwala uniknąć błędów przy późniejszych opróbach załączania encji o takim samym id (np. update)
            return _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual  async Task<IEnumerable<T>> ReadAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual Task UpdateAsync(int id, T entity)
        {
            entity.Id = id;

            //sprawdzenie czy entity istnieje w context i czy jest śledzone - jesli tak, to musimy je odpiąć
            /*var localEntity = _context.Set<T>().Local.SingleOrDefault(x => x.Id == id);
            if (localEntity != null)
            {
                var entry = _context.Entry(localEntity);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Detached;
                    //_context.ChangeTracker.Clear();
                }
            }*/
            _context.Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}