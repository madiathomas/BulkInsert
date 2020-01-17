using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsertLibrary
{
    public interface IBulkInsert
    {
        Task Save<T>(DataTable dataTable, string connectionString, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, string destinationTableName = null);
        Task Save<T>(List<T> list, string connectionString, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, string destinationTableName = null);
    }
}