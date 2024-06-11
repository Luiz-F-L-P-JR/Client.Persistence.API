

using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Domain.Client.Reposiroty.Interface;
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;
using Dapper;
using Dapper.Contrib.Extensions;
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
    const string? SP_CLIENT_EMAIL_REPEATED = "dbo.SP_CLIENT_EMAIL_REPEATED";

    private readonly ILogger<ClientRepository>? _logger;
    private readonly IDbClientPersistenceConnection _connection;
    private readonly IPublicAreaRepository? _publicAreaRepository;

    public ClientRepository(ILogger<ClientRepository>? logger, IDbClientPersistenceConnection connection, IPublicAreaRepository? publicAreaRepository)
    {
        _logger = logger;
        _connection = connection;
        _publicAreaRepository = publicAreaRepository;
    }

    public async Task<IEnumerable<Domain.Client.Model.Client>> GetAllAsync()
    {
        var connection = await _connection.GetSqlConnectionAsync();

        var data = (await connection?.QueryAsync<Domain.Client.Model.Client>
                        (
                            SP_GETALL_CLIENT,
                            commandType: CommandType.StoredProcedure
                        )
                   )?.ToList();

        connection.Close();

        if (data is List<Domain.Client.Model.Client>) return data;

        _logger?.LogError(null, "No data found. Try again.");
        throw new ArgumentException("No data found. Try again.");
    }

    public async Task<Domain.Client.Model.Client> GetAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        var data = (await connection.QueryAsync<Domain.Client.Model.Client>
                     (
                        SP_GET_CLIENT, 
                        new{ id = id }, 
                        commandType: CommandType.StoredProcedure
                     )
                   )?.FirstOrDefault();

        connection.Close();

        if (data is Domain.Client.Model.Client) return data;

        throw new ArgumentException("No data found. Try again.");
    }

    public async Task<Domain.Client.Model.Client> GetWithPublicAreaAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        var client = await connection.GetAsync<Domain.Client.Model.Client>(id);
        var publicAreas = ( await connection
                            .GetAllAsync<Domain.PublicArea.Model.PublicArea>())
                            .Where(p => p.ClientId == id)
                            .ToList();

        connection.Close();

        client.PublicAreas = publicAreas;

        if (client is Domain.Client.Model.Client) return client;

        _logger?.LogError(null, "No data found. Try again.");
        throw new ArgumentException("No data found. Try again.");
    }

    public async Task CreateAsync(Domain.Client.Model.Client entity)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        bool isEmailRepeated = await isEmailRepeatedAsync(entity.Name, entity.Email);

        if (isEmailRepeated)
            throw new HttpRequestException("Null object reference or withou enough information", null, HttpStatusCode.BadRequest);

        if ( entity is Domain.Client.Model.Client)
        {
            await connection.ExecuteAsync
            (
                SP_CREATE_CLIENT, 
                new{
                        name = entity.Name, 
                        email = entity.Email, 
                        logo = entity.Logo
                    }, 
                commandType: CommandType.StoredProcedure
            );

            int clientId = (await connection.GetAllAsync<Domain.Client.Model.Client>()).LastOrDefault().Id;

            entity.PublicAreas[0].ClientId = clientId;

            await _publicAreaRepository.CreateAsync(entity.PublicAreas[0]);

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

        bool isValidEntity = (await connection.GetAllAsync<Domain.Client.Model.Client>()).ToList().Exists(e => e.Id == entity.Id);

        var client = await this.GetCurrentPropertyUpdated(entity);

        if (isValidEntity)
        {
            await connection.ExecuteAsync
            (
                SP_UPDATE_CLIENT, 
                new {
                    id = client.Id,
                    name = client.Name,
                    email = client.Email,
                    logo = client.Logo
                }, 
                commandType: CommandType.StoredProcedure
            );

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "The client searched doesn't exist.");
            throw new ArgumentException("The client searched doesn't exist.");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        bool isValidEntity = (await connection.GetAllAsync<Domain.Client.Model.Client>()).ToList().Exists(e => e.Id == id);

        if (isValidEntity)
        {
            await connection.ExecuteAsync(SP_DELETE_CLIENT, new {id = id}, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "The client searched doesn't exist.");
            throw new ArgumentException("The client searched doesn't exist.");
        }

    }

    private async Task<bool> isEmailRepeatedAsync(string name, string email)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        var data = ( await connection.QueryAsync<int>
                     (
                        SP_CLIENT_EMAIL_REPEATED,
                        new {
                            name = name,
                            email = email
                        },
                        commandType: CommandType.StoredProcedure
                     )
                   )?.FirstOrDefault();

        connection.Close();

        if (data > 0) return true;

        return false;
    }

    private async Task<Domain.Client.Model.Client> GetCurrentPropertyUpdated(Domain.Client.Model.Client entity){

        var oldEntity = await this.GetAsync(entity.Id);

        return new Domain.Client.Model.Client {
            Id = entity.Id,
            Name = entity.Name is null ? oldEntity.Name : entity.Name,
            Email = entity.Email is null ? oldEntity.Email : entity.Email,
            Logo = entity.Logo is null ? oldEntity.Logo : entity.Logo
        };
    }
}
