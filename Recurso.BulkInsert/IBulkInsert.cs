using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert
{
    public interface IBulkInsert
    {
        public int BatchSize { get; set; }

        public int BulkCopyTimeout { get; set; }

        Task Save<T>(DataTable dataTable, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default);

        Task Save<T>(List<T> list, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default);
    }
}