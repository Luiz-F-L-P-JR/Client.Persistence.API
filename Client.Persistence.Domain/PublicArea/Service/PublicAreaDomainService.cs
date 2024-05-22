
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;
using Client.Persistence.Domain.PublicArea.Service.Interface;

namespace Client.Persistence.Domain.PublicArea.Service;

public sealed class PublicAreaDomainService : IPublicAreaDomainService
{
    private readonly IPublicAreaRepository? _repository;

    public PublicAreaDomainService(IPublicAreaRepository? repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Model.PublicArea>> GetAllAsync()
    => await _repository.GetAllAsync();

    public async Task<Model.PublicArea> GetAsync(int id)
        => await _repository.GetAsync(id);

    public async Task CreateAsync(Model.PublicArea entity)
        => await _repository.CreateAsync(entity);

    public async Task UpdateAsync(Model.PublicArea entity)
        => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
