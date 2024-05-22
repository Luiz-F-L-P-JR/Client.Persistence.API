
using AutoMapper;
using Client.Persistence.Application.PublicArea.DTO;
using Client.Persistence.Application.PublicArea.Service.Interface;
using Client.Persistence.Domain.PublicArea.Service.Interface;

namespace Client.Persistence.Application.PublicArea.Service;

public sealed class PublicAreaApplicationService : IPublicAreaApplicationService
{
    private readonly IMapper _mapper;
    private readonly IPublicAreaDomainService _domainService;

    public PublicAreaApplicationService(IMapper mapper, IPublicAreaDomainService domainService)
    {
        _mapper = mapper;
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

    public async Task<IEnumerable<PublicAreaDTO>> GetAllAsync()
    {
        var publicArea = await _domainService.GetAllAsync();

        var publicAreaDto = _mapper.Map<IEnumerable<PublicAreaDTO>>(publicArea).ToList();

        return publicAreaDto;
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
