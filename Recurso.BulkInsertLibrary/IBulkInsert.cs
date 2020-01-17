using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsertLibrary
{
    public interface IBulkInsert
    {
        public string ConnectionString { get; set; }

        Task Save<T>(DataTable dataTable, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, string destinationTableName = null);
        Task Save<T>(List<T> list, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default, string destinationTableName = null);
    }
}