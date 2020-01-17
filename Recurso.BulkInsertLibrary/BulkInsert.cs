using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsertLibrary
{
    public class BulkInsert : IBulkInsert
    {
        public string ConnectionString { get; set; }

        /// <summary>
        /// Save a generic list into a database table. If destinationTableName isn't supplied, it will use name of T as Table name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public async Task Save<T>(List<T> list, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new Exception("Please set ConnectionString property");
            }

            using var dataTable = list.CopyToDataTable();

            await Save<T>(dataTable, destinationTableName, sqlBulkCopyOptions);
        }

        /// <summary>
        /// Save datatable into a table on the database. If destinationTableName isn't supplied, it will use name of T as Table name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <param name="connectionString"></param>
        /// <param name="destinationTableName"></param>
        /// <returns></returns>
        public async Task Save<T>(DataTable dataTable, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new Exception("Please set ConnectionString property");
            }

            using SqlBulkCopy bulkCopy = new SqlBulkCopy(this.ConnectionString, sqlBulkCopyOptions)
            {
                DestinationTableName = destinationTableName ?? typeof(T).Name
            };

            await bulkCopy.WriteToServerAsync(dataTable);
        }

    }
}
