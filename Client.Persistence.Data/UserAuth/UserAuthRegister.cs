
using Client.Persistence.Domain.UserAuth.Model;
using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Domain.UserAuth.Repostory.Interface;
using Dapper;
using System.Data;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Client.Persistence.Data.UserAuth
{
    public sealed class UserAuthRegister : IUserAuthRegister
    {
        private const string? SP_GET_USER = "[dbo].[SP_GET_USER]";
        private const string? SP_REGISTER_USER = "[dbo].[SP_REGISTER_USER]";

        private readonly ILogger<UserAuthRegister>? _logger;
        private readonly IDbClientPersistenceConnection? _connection;

        public UserAuthRegister(ILogger<UserAuthRegister>? logger, IDbClientPersistenceConnection? connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public async Task CreateAsync(User user)
        {
            var connectio = await _connection.GetSqlConnectionAsync();

            await connectio.ExecuteAsync
                (
                    SP_REGISTER_USER,
                    new
                    {
                        role = user.Role,
                        name = user.Name,
                        email = user?.Email?.ToLower(),
                        password = user?.Password?.ToLower()
                    },
                    commandType: CommandType.StoredProcedure
                );

            _logger?.LogError(null, "Null object reference or withou enough information");
            throw new HttpRequestException("Null object reference or withou enough information", null, HttpStatusCode.BadRequest);
        }

        public async Task<User> GetAsync(string email)
        {
            var connection = await _connection.GetSqlConnectionAsync();

            var user =  (
                            await connection.QueryAsync<User>
                            (
                                SP_GET_USER, 
                                new {email = email.ToLower()}, 
                                commandType: CommandType.StoredProcedure
                            )
                        ).FirstOrDefault();

            if(user is User) return user;

            _logger?.LogError(null, "No data found. Try again.");
            throw new HttpRequestException("No data found. Try again.", null, HttpStatusCode.BadRequest);
        }
    }
}
