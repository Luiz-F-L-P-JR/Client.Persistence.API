

using Client.Persistence.Data.DbConnection.Interface;
using Client.Persistence.Domain.PublicArea.Reposiroty.Interface;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

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
        try
        {
            var connection = await _connection.GetSqlConnectionAsync();

            var data = (
                          await connection?
                                .QueryAsync<IEnumerable<Domain.PublicArea.Model.PublicArea>>
                                (
                                    SP_GETALL_PUBLICAREA, 
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

    public Task<Domain.PublicArea.Model.PublicArea> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Domain.PublicArea.Model.PublicArea entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Domain.PublicArea.Model.PublicArea entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
