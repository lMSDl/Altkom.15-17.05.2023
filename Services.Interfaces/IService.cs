using Models;

namespace Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task<T?> ReadAsync(int id);
        Task<IEnumerable<T>> ReadAsync();
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);

    }
}