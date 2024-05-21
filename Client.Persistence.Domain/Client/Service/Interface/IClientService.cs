﻿
namespace Client.Persistence.Domain.Client.Service.Interface;

public interface IClientService
{
    Task DeleteAsync(int id);
    Task CreateAsync(Model.Client entity);
    Task UpdateAsync(Model.Client entity);
    Task<IEnumerable<Model.Client>> GetAllAsync();
    Task<Model.Client> GetAsync(int id);
}
