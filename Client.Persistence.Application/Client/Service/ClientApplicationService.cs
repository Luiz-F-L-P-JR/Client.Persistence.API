using Client.Persistence.Application.Client.DTO;
using Client.Persistence.Application.Client.Service.Interface;
using Client.Persistence.Domain.Client.Service.Interface;

namespace Client.Persistence.Application.Client.Service;

public sealed class ClientApplicationService : IClientApplicationService
{
    private readonly IClientDomainService _domainService;

    public ClientApplicationService(IClientDomainService domainService)
    {
        _domainService = domainService;
    }

    public Task CreateAsync(ClientDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ClientDTO> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ClientDTO entity)
    {
        throw new NotImplementedException();
    }
}
