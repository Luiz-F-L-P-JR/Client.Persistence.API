using Client.Persistence.Application.Client.DTO;

namespace Client.Persistence.Application.Client.Service.Interface;

public interface IClientService
{
    Task DeleteAsync(int id);
    Task CreateAsync(ClientDTO entity);
    Task UpdateAsync(ClientDTO entity);
    Task<IEnumerable<ClientDTO>> GetAllAsync();
    Task<ClientDTO> GetAsync(int id);
}
