using Client.Persistence.Domain.UserAuth.Model;

namespace Client.Persistence.Domain.UserAuth.Repostory.Interface
{
    public interface IUserAuthRegister
    {
        Task CreateAsync(User entity);
        Task<User> GetAsync(string email);
    }
}
