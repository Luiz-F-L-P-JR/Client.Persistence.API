
using Client.Persistence.Domain.Generics;

namespace Client.Persistence.Domain.Client.Reposiroty.Interface;

public interface IClientRepository : IGenericInterface<Model.Client>
{
    Task<Model.Client> GetWithPublicAreaAsync(int id);
}
