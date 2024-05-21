
using Client.Persistence.Application.PublicArea.DTO;

namespace Client.Persistence.Application.PublicArea.Service.Interface;

public interface IPublicAreaService
{
    Task DeleteAsync(int id);
    Task CreateAsync(PublicAreaDTO entity);
    Task UpdateAsync(PublicAreaDTO entity);
    Task<IEnumerable<PublicAreaDTO>> GetAllAsync();
    Task<PublicAreaDTO> GetAsync(int id);
}
