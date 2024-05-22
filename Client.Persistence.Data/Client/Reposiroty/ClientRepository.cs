

using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Client.Persistence.Data.Client.Reposiroty;

public sealed class ClientRepository : IClientRepository
{
    const string? SP_GET_CLIENT = "dbo.SP_GET_CLIENT";
    const string? SP_GETALL_CLIENT = "dbo.SP_GETALL_CLIENT";
    const string? SP_CREATE_CLIENT = "dbo.SP_CREATE_CLIENT";
    const string? SP_UPDATE_CLIENT = "dbo.SP_UPDATE_CLIENT";
    const string? SP_DELETE_CLIENT = "dbo.SP_DELETE_CLIENT";
    const string? SP_GET_CLIENT_AND_PUBLCAREA = "dbo.SP_GET_CLIENT_AND_PUBLCAREA";
    const string? SP_GETALL_CLIENT_AND_PUBLCAREA = "dbo.SP_GETALL_CLIENT_AND_PUBLCAREA";

    private readonly ILogger<ClientRepository>? _logger;
    private readonly IDbClientPersistenceConnection _connection;

    public ClientRepository(ILogger<ClientRepository>? logger, IDbClientPersistenceConnection connection)
    {
        _logger = logger;
        _connection = connection;
    }

    public async Task<IEnumerable<Domain.Client.Model.Client>> GetAllAsync()
    {
        try
        {
            var connection = await _connection.GetSqlConnectionAsync();

            var data = (
                          await connection?
                                .QueryAsync<IEnumerable<Domain.Client.Model.Client>>
                                (
                                    SP_GETALL_CLIENT,
                                    commandType: CommandType.StoredProcedure
                                )
                        )
                        ?.FirstOrDefault()?.ToList();

            return data;
        }
        catch (Exception e)
        {

            _logger?.LogInformation($"Message: {e.Message}| Trace: {e.StackTrace} |{DateTime.UtcNow}");

            throw e;
        }
    }

    public Task<Domain.Client.Model.Client> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Domain.Client.Model.Client entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Domain.Client.Model.Client entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
