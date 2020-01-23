using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Primitives;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IAppSettings _appSettings;

        public SqlConnectionFactory(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public IDbConnection CreateConnection()
        {
            string connectionString = _appSettings.GetSetting("SQLDBConnectionString");

            return new SqlConnection(connectionString);
        }
    }
}
