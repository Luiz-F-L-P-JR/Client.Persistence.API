
using Client.Persistence.Domain.Generics;

namespace Client.Persistence.Domain.Client.Service.Interface;

public interface IClientDomainService : IGenericInterface<Model.Client>
{
    Task<Model.Client> GetWithPublicAreaAsync(int id);
}
