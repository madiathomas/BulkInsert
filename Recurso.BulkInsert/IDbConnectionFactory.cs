using System.Data;

namespace Recurso.BulkInsert
{
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Creates a connection based on the given database name or connection string.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        IDbConnection CreateConnection(string connectionString);
    }
}
