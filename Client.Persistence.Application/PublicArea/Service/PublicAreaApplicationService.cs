
using Client.Persistence.Application.PublicArea.DTO;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Client.Persistence.Domain.PublicArea.Service.Interface;

namespace Client.Persistence.Application.PublicArea.Service;

public sealed class PublicAreaApplicationService : IPublicAreaApplicationService
{
    private readonly IPublicAreaDomainService _domainService;

    public PublicAreaApplicationService(IPublicAreaDomainService domainService)
    {
        _domainService = domainService;
    }

    public Task CreateAsync(PublicAreaDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PublicAreaDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PublicAreaDTO> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PublicAreaDTO entity)
    {
        throw new NotImplementedException();
    }
}
