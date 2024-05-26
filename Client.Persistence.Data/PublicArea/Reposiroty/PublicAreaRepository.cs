

using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;
using static Dapper.SqlMapper;

namespace Client.Persistence.Data.PublicArea.Reposiroty;

public sealed class PublicAreaRepository : IPublicAreaRepository
{
    const string? SP_GET_PUBLICAREA = "SP_GET_PUBLICAREA";
    const string? SP_GETALL_PUBLICAREA = "SP_GETALL_PUBLICAREA";
    const string? SP_CREATE_PUBLICAREA = "SP_CREATE_PUBLICAREA";
    const string? SP_UPDATE_PUBLICAREA = "SP_UPDATE_PUBLICAREA";
    const string? SP_DELETE_PUBLICAREA = "SP_DELETE_PUBLICAREA";

    private readonly ILogger<PublicAreaRepository>? _logger;
    private readonly IDbClientPersistenceConnection? _connection;

    public PublicAreaRepository(ILogger<PublicAreaRepository>? logger, IDbClientPersistenceConnection? connection)
    {
        _logger = logger;
        _connection = connection;
    }

    public async Task<IEnumerable<Domain.PublicArea.Model.PublicArea>> GetAllAsync()
    {
        var connection = await _connection.GetSqlConnectionAsync();

        var data = 
        (
            await connection?
                .QueryAsync<Domain.PublicArea.Model.PublicArea>
                (
                    SP_GETALL_PUBLICAREA, 
                    commandType: CommandType.StoredProcedure
                )
        )
        ?.ToList();

        connection.Close();

        if (data is List<Domain.PublicArea.Model.PublicArea>) return data;

        _logger?.LogError(null, "No data found. Try again.");
        throw new ArgumentException("No data found. Try again.");

    }

    public async Task<Domain.PublicArea.Model.PublicArea> GetAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        var data = (
                     await connection.QueryAsync<Domain.PublicArea.Model.PublicArea>
                     (
                        SP_GET_PUBLICAREA,
                        new {id = id},
                        commandType: CommandType.StoredProcedure
                     )
                   ).FirstOrDefault();

        connection.Close();

        if (data is Domain.PublicArea.Model.PublicArea) return data;

        _logger?.LogError(null, "This public area may not exist. Try again with another public area identification.");
        throw new HttpRequestException("This public area may not exist. Try again with another public area identification.", null, HttpStatusCode.BadRequest);
    }

    public async Task CreateAsync(Domain.PublicArea.Model.PublicArea entity)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        if (entity is Domain.PublicArea.Model.PublicArea)
        {
            await connection.ExecuteAsync
            (
                SP_CREATE_PUBLICAREA, 
                new {
                    city = entity.City,
                    state = entity.State,
                    address = entity.Address,
                    clientid = entity.ClientId,
                    neighborhood = entity.Neighborhood
                }, 
                commandType: CommandType.StoredProcedure
            );

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "Null object reference or withou enough information");
            throw new ArgumentException("Null object reference or withou enough information");
        }
    }

    public async Task UpdateAsync(Domain.PublicArea.Model.PublicArea entity)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        bool isValidEntity = (await connection.GetAllAsync<Domain.PublicArea.Model.PublicArea>()).ToList().Exists(e => e.Id == entity.Id);

        var oldEntity = await this.GetAsync(entity.Id);

        if (isValidEntity)
        {
            await connection.ExecuteAsync
            (
                SP_UPDATE_PUBLICAREA, 
                new{
                    id = entity.Id,
                    city = entity.City is null ? oldEntity.City : entity.City,
                    state = entity.State is null ? oldEntity.State : entity.State,
                    address = entity.Address is null ? oldEntity.Address : entity.Address,
                    clientid = entity.ClientId <= 0 ? oldEntity.ClientId : entity.ClientId,
                    neighborhood = entity.Neighborhood is null ? oldEntity.Neighborhood : entity.Neighborhood,
                }, 
                commandType: CommandType.StoredProcedure
            );

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "The public area searched doesn't exist.");
            throw new ArgumentException("The public area searched doesn't exist.");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var connection = await _connection.GetSqlConnectionAsync();

        bool isValidEntity = (await connection.GetAllAsync<Domain.PublicArea.Model.PublicArea>()).ToList().Exists(e => e.Id == id);

        if (isValidEntity)
        {
            await connection.ExecuteAsync(SP_DELETE_PUBLICAREA, new{id = id}, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
        else
        {
            _logger?.LogError(null, "The public area searched doesn't exist.");
            throw new ArgumentException("The public area searched doesn't exist.");
        }
    }
}
