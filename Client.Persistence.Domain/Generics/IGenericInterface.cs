
namespace Client.Persistence.Domain.Generics
{
    public interface IGenericInterface<T> where T : class
    {
        Task DeleteAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
