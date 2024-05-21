using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Client.Persistence.Domain.Client.Service.Interface;

namespace Client.Persistence.Domain.Client.Service;

public sealed class ClientDomainService : IClientDomainService
{
    private readonly IClientRepository? _repository;

    public ClientDomainService(IClientRepository? repository)
    {
        _repository = repository;
    }

    public Task CreateAsync(Model.Client entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Model.Client>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Model.Client> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Model.Client entity)
    {
        throw new NotImplementedException();
    }
}
