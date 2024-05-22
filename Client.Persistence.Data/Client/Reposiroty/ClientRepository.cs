

using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;
using static Dapper.SqlMapper;

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
        var connection = await _connection.GetSqlConnectionAsync();

        var data = (
                        await connection?
                            .QueryAsync<List<Domain.Client.Model.Client>>
                            (
                                SP_GETALL_CLIENT,
                                commandType: CommandType.StoredProcedure
                            )
                    )
                    ?.FirstOrDefault();

        connection.Close();

        if (data is List<Domain.Client.Model.Client>) return data;

        return Enumerable.Empty<Domain.Client.Model.Client>();
    }

    public async Task<Domain.Client.Model.Client> GetAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        DynamicParameters dynamicParameters = new();
        dynamicParameters.Add( "@id", id );

        var data = (
                     await connection.QueryAsync<Domain.Client.Model.Client>
                     (
                        SP_GET_CLIENT, 
                        dynamicParameters, 
                        commandType: CommandType.StoredProcedure
                     )
                   ).FirstOrDefault();

        connection.Close();

        if (data is Domain.Client.Model.Client) return data;

        return Enumerable.Empty<Domain.Client.Model.Client>().FirstOrDefault();
    }

    public async Task CreateAsync(Domain.Client.Model.Client entity)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        if ( entity is Domain.Client.Model.Client)
        {
            DynamicParameters dynamicParameters = new();

            dynamicParameters.Add("@name", entity.Name);
            dynamicParameters.Add("@email", entity.Email);
            dynamicParameters.Add("@logo", entity.Logo);

            await connection.ExecuteAsync(SP_CREATE_CLIENT, dynamicParameters, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "Null object reference or withou enough information");
            throw new HttpRequestException("Null object reference or withou enough information", null, HttpStatusCode.BadRequest);
        }
    }

    public async Task UpdateAsync(Domain.Client.Model.Client entity)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        bool isValidEntity = this.GetAllAsync().Result.ToList().Exists(e => e.Id == entity.Id);

        if (isValidEntity)
        {
            DynamicParameters dynamicParameters = new();

            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@name", entity.Name);
            dynamicParameters.Add("@email", entity.Email);
            dynamicParameters.Add("@logo", entity.Logo);

            await connection.ExecuteAsync(SP_UPDATE_CLIENT, dynamicParameters, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "The client searched doesn't exist.");
            throw new HttpRequestException("The client searched doesn't exist.", null, HttpStatusCode.BadRequest);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        bool isValidEntity = this.GetAllAsync().Result.ToList().Exists(e => e.Id == id);

        if (isValidEntity)
        {
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);

            await connection.ExecuteAsync(SP_DELETE_CLIENT, dynamicParameters, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "The client searched doesn't exist.");
            throw new HttpRequestException("The client searched doesn't exist.", null, HttpStatusCode.BadRequest);
        }

    }
}
