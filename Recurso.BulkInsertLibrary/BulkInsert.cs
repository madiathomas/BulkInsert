using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsertLibrary
{
    public class BulkInsert
    {
        /// <summary>
        /// Save a generic list into a database table. If destinationTableName isn't supplied, it will use name of T as Table name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public async Task Save<T>(List<T> list, string connectionString, string destinationTableName = null)
        {
            using var dataTable = list.CopyToDataTable();

            await Save(list, connectionString, destinationTableName);
        }

        /// <summary>
        /// Save datatable into a table on the database. If destinationTableName isn't supplied, it will use name of T as Table name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <param name="connectionString"></param>
        /// <param name="destinationTableName"></param>
        /// <returns></returns>
        public async Task Save<T>(DataTable dataTable, string connectionString, string destinationTableName = null)
        {
            using SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.Default)
            {
                DestinationTableName = destinationTableName ?? dataTable.TableName
            };

            await bulkCopy.WriteToServerAsync(dataTable);
        }

    }
}
