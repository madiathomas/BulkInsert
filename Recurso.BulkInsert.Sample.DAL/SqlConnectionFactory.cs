using System.Data;
using System.Data.SqlClient;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        readonly string connectionString = "Server=.;Database=People;Integrated Security=true;";

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
