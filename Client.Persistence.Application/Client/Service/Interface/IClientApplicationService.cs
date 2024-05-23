using Client.Persistence.Application.Client.DTO;

namespace Client.Persistence.Application.Client.Service.Interface;

public interface IClientApplicationService
{
    Task DeleteAsync(int id);
    Task CreateAsync(ClientDTO entity);
    Task UpdateAsync(ClientDTO entity);
    Task<IEnumerable<ClientDTO>> GetAllAsync();
    Task<ClientDTO> GetAsync(int id);
    Task<ClientDTO> GetWithPublicAreaAsync(int id);
    Task<IEnumerable<ClientDTO>> GetAllWithPublicAreaAsync();
}
