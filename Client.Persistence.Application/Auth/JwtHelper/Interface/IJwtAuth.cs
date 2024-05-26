
using Client.Persistence.Domain.UserAuth.Model;

namespace Client.Persistence.Application.Auth.JwtHelper.Interface
{
    public interface IJwtAuth
    {
        Task<string> GenerateToken(User user);
    }
}
