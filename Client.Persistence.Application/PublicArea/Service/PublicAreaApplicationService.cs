
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

    public async Task<IEnumerable<PublicAreaDTO>> GetAllAsync()
    {
        var publicArea = await _domainService.GetAllAsync();

        var publicAreaDto = _mapper.Map<IEnumerable<PublicAreaDTO>>(publicArea).ToList();

        return publicAreaDto;
    }

    public async Task<PublicAreaDTO> GetAsync(int id)
    {
        var publicArea = await _domainService.GetAsync(id);

        var publicAreaDto = _mapper.Map<PublicAreaDTO>(publicArea);

        return publicAreaDto;
    }

    public async Task CreateAsync(PublicAreaDTO entity)
    {
        var publicArea = _mapper.Map<Domain.PublicArea.Model.PublicArea>(entity);

        await _domainService.CreateAsync(publicArea);
    }

    public async Task UpdateAsync(PublicAreaDTO entity)
    {
        var publicArea = _mapper.Map<Domain.PublicArea.Model.PublicArea>(entity);

        await _domainService.UpdateAsync(publicArea);
    }

    public async Task DeleteAsync(int id)
        => await _domainService.DeleteAsync(id);
}
