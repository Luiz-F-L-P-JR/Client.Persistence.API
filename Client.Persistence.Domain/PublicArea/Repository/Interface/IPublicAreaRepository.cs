
namespace Client.Persistence.Domain.PublicArea.Reposiroty.Interface
{
    public interface IPublicAreaRepository
    {
        Task DeleteAsync(int id);
        Task CreateAsync(Model.PublicArea entity);
        Task UpdateAsync(Model.PublicArea entity);
        Task<IEnumerable<Model.PublicArea>> GetAllAsync();
        Task<Model.PublicArea> GetAsync(int id);
    }
}
