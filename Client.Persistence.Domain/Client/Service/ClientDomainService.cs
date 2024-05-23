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

    public async Task<IEnumerable<Model.Client>> GetAllAsync()
    => await _repository.GetAllAsync();

    public async Task<Model.Client> GetAsync(int id)
        => await _repository.GetAsync(id);

    public async Task<Model.Client> GetWithPublicAreaAsync(int id)
        => await _repository.GetWithPublicAreaAsync(id);

    public async Task<IEnumerable<Model.Client>> GetAllWithPublicAreaAsync()
        => await _repository.GetAllWithPublicAreaAsync();

    public async Task CreateAsync(Model.Client entity)
        => await _repository.CreateAsync(entity);

    public async Task UpdateAsync(Model.Client entity)
        => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
