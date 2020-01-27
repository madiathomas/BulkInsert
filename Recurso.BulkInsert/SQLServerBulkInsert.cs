using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert
{
    public class SQLServerBulkInsert : IBulkInsert
    {
        /// <summary>
        /// Number of rows in each batch. At the end of each batch, the rows in the batch are sent to the server. Defaulted to 4000.
        /// </summary>
        public int BatchSize { get; set; } = 4000;

        /// <summary>
        /// Number of seconds for the bulk cooy operation to complete before it times out. A value of 0 indicates no limit; the bulk copy will wait indefinitely.
        /// </summary>
        public int BulkCopyTimeout { get; set; } = 0;

        private readonly IDbConnectionFactory _dbConnectionFactory;

        public SQLServerBulkInsert(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }

        /// <summary>
        /// Save a generic list into a database table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="destinationTableName">Name of the database table you want to bulk insert this data. If destinationTableName isn't supplied, it will use name of T as Table name.</param>
        /// <param name="sqlBulkCopyOptions">Bitwise flag that specifies one or more options to use with an instance of SqlBulkCopy.</param>
        /// <returns></returns>
        public async Task Save<T>(List<T> sourceList, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            using var dataTable = sourceList.CopyToDataTable();

            await Save<T>(dataTable, destinationTableName, sqlBulkCopyOptions);
        }

        /// <summary>
        /// Save datatable into a table on the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceDataTable"></param>
        /// <param name="destinationTableName">Name of the database table you want to bulk insert this data. If destinationTableName isn't supplied, it will use name of T as Table name.</param>
        /// <param name="sqlBulkCopyOptions">Bitwise flag that specifies one or more options to use with an instance of SqlBulkCopy</param>
        /// <returns></returns>
        public async Task Save<T>(DataTable sourceDataTable, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            using SqlConnection connection = _dbConnectionFactory.CreateConnection() as SqlConnection;
            await connection.OpenAsync();

            using SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, sqlBulkCopyOptions, null)
            {
                BatchSize = this.BatchSize,
                BulkCopyTimeout = this.BulkCopyTimeout,
                DestinationTableName = destinationTableName ?? sourceDataTable.TableName ?? typeof(T).Name,
            };

            sourceDataTable.AddColumnMappings(sqlBulkCopy);

            await sqlBulkCopy.WriteToServerAsync(sourceDataTable);
        }
    }
}
