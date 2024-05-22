
using Client.Persistence.Data.DbConnection.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Client.Persistence.Data.DbConnection;

public sealed class DbClientPersistenceConnection : IDbClientPersistenceConnection
{
    private readonly IConfiguration _configuration;

    public DbClientPersistenceConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IDbConnection> GetSqlConnectionAsync()
    {
        string connectionString = _configuration.GetConnectionString("Default");

        SqlConnection connection = new(connectionString);
        await connection.OpenAsync();

        return connection;
    }
}
