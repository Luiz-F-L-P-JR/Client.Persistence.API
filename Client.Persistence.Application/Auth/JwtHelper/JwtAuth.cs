using Client.Persistence.Domain.AuthUser.AuthRoleEnumerable;
using Client.Persistence.Application.Auth.JwtHelper.Interface;
using Client.Persistence.Domain.UserAuth.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Client.Persistence.API.Helper
{
    public class JwtAuth : IJwtAuth
    {
        private readonly IConfiguration? _configuration;

        public JwtAuth(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var secretKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, RoleFactory(user.Role))
                }),

                Expires = DateTime.UtcNow.AddHours(24),

                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(secretKey), 
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string RoleFactory(AuthRoles? roleNumber)
        {
            return roleNumber switch
            {
                AuthRoles.Admin => "Admin",
                AuthRoles.Menager => "Menager",
                AuthRoles.Regular => "Regular",
                _=> ""
            };
        }
    }
}
