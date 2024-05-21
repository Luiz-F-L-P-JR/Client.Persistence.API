

using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;

namespace Client.Persistence.Data.PublicArea.Reposiroty;

public sealed class PublicAreaRepository : IPublicAreaRepository
{
    public Task CreateAsync(Domain.PublicArea.Model.PublicArea entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.PublicArea.Model.PublicArea>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.PublicArea.Model.PublicArea> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Domain.PublicArea.Model.PublicArea entity)
    {
        throw new NotImplementedException();
    }
}
