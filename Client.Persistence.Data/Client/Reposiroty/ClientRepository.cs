

using Client.Persistence.Domain.Client.Reposiroty.Interface;

namespace Client.Persistence.Data.Client.Reposiroty;

public sealed class ClientRepository : IClientRepository
{
    public Task CreateAsync(Domain.Client.Model.Client entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Client.Model.Client>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Client.Model.Client> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Domain.Client.Model.Client entity)
    {
        throw new NotImplementedException();
    }
}
