
using System.Data;

namespace Client.Persistence.Data.DbConnection.Interface;

public interface IDbClientPersistenceConnection
{
    Task<IDbConnection> GetSqlConnectionAsync();
}
