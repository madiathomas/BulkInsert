using System.Data;
using System.Data.SqlClient;

namespace Recurso.BulkInsert
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        public SqlServerConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
