
namespace Client.Persistence.Domain.Client.Reposiroty.Interface;

public interface IClientRepository
{
    Task DeleteAsync(int id);
    Task CreateAsync(Model.Client entity);
    Task UpdateAsync(Model.Client entity);
    Task<IEnumerable<Model.Client>> GetAllAsync();
    Task<Model.Client> GetAsync(int id);
}
