
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

    public Task CreateAsync(Model.PublicArea entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Model.PublicArea>> GetAllAsync()
        => await _repository.GetAllAsync();

    public Task<Model.PublicArea> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Model.PublicArea entity)
    {
        throw new NotImplementedException();
    }
}
