using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert
{
    public interface IBulkInsert
    {
        /// <summary>
        /// Number of rows in each batch. At the end of each batch, the rows in the batch are sent to the server. Defaulted to 4000.
        /// </summary>
        public int BatchSize { get; set; }

        /// <summary>
        /// Save a generic list into a database table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="destinationTableName">Name of the database table you want to bulk insert this data. If destinationTableName isn't supplied, it will use name of T as Table name.</param>
        /// <param name="sqlBulkCopyOptions">Bitwise flag that specifies one or more options to use with an instance of SqlBulkCopy.</param>
        /// <returns></returns>
        Task<long> Save<T>(DataTable dataTable, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default);

        /// <summary>
        /// Save datatable into a table on the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceDataTable"></param>
        /// <param name="destinationTableName">Name of the database table you want to bulk insert this data. If destinationTableName isn't supplied, it will use name of T as Table name.</param>
        /// <param name="sqlBulkCopyOptions">Bitwise flag that specifies one or more options to use with an instance of SqlBulkCopy</param>
        /// <returns></returns>
        Task<long> Save<T>(List<T> list, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default);
    }
}