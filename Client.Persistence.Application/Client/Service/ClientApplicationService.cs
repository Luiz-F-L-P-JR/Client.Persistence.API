using AutoMapper;
using Client.Persistence.Application.Client.DTO;
using Client.Persistence.Application.Client.Service.Interface;
using Client.Persistence.Domain.Client.Service.Interface;

namespace Client.Persistence.Application.Client.Service;

public sealed class ClientApplicationService : IClientApplicationService
{
    private readonly IMapper _mapper;
    private readonly IClientDomainService _domainService;

    public ClientApplicationService(IMapper mapper, IClientDomainService domainService)
    {
        _mapper = mapper;
        _domainService = domainService;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllAsync()
    {
        var clients = await _domainService.GetAllAsync();

        var clientsDto = _mapper.Map<IEnumerable<ClientDTO>>(clients).ToList();

        return clientsDto;
    }

    public async Task<ClientDTO> GetAsync(int id)
    {
        var client = await _domainService.GetAsync(id);

        var clientDto = _mapper.Map<ClientDTO>(client);

        return clientDto;
    }

    public async Task<ClientDTO> GetWithPublicAreaAsync(int id)
    {
        var client = await _domainService.GetWithPublicAreaAsync(id);

        var clientDto = _mapper.Map<ClientDTO>(client);

        return clientDto;
    }

    public async Task<IEnumerable<ClientDTO>> GetAllWithPublicAreaAsync()
    {
        var clients = await _domainService.GetAllWithPublicAreaAsync();

        var clientsDto = _mapper.Map<IEnumerable<ClientDTO>>(clients).ToList();

        return clientsDto;
    }

    public async Task CreateAsync(ClientDTO entity)
    {
        var client = _mapper.Map<Domain.Client.Model.Client>(entity);

        await _domainService.CreateAsync(client);
    }

    public async Task UpdateAsync(ClientDTO entity)
    {
        var client = _mapper.Map<Domain.Client.Model.Client>(entity);

        await _domainService.UpdateAsync(client);
    }

    public async Task DeleteAsync(int id)
        => await _domainService.DeleteAsync(id);
}
