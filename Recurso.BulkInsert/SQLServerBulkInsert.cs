using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert
{
    public class SQLServerBulkInsert : IBulkInsert
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        /// <summary>
        /// Database connection string to be used to bulk insert data
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Number of rows in each batch. At the end of each batch, the rows in the batch are sent to the server. Defaulted to 4000.
        /// </summary>
        public int BatchSize { get; set; } = 4000;

        public SQLServerBulkInsert(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        /// <summary>
        /// Save a generic list into a database table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="destinationTableName">Name of the database table you want to bulk insert this data. If destinationTableName isn't supplied, it will use name of T as Table name.</param>
        /// <param name="sqlBulkCopyOptions">Bitwise flag that specifies one or more options to use with an instance of SqlBulkCopy.</param>
        /// <returns></returns>
        public async Task<long> Save<T>(List<T> sourceList, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentException("Please set ConnectionString property");
            }

            using var dataTable = sourceList.CopyToDataTable();

            return await Save<T>(dataTable, destinationTableName, sqlBulkCopyOptions);
        }

        /// <summary>
        /// Save datatable into a table on the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceDataTable"></param>
        /// <param name="destinationTableName">Name of the database table you want to bulk insert this data. If destinationTableName isn't supplied, it will use name of T as Table name.</param>
        /// <param name="sqlBulkCopyOptions">Bitwise flag that specifies one or more options to use with an instance of SqlBulkCopy</param>
        /// <returns></returns>
        public async Task<long> Save<T>(DataTable sourceDataTable, string destinationTableName = null, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentException("Please set ConnectionString property");
            }

            using SqlConnection connection = dbConnectionFactory.CreateConnection(ConnectionString) as SqlConnection;
            using SqlTransaction sqlTransaction = await connection.BeginTransactionAsync() as SqlTransaction; 

            using SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, sqlBulkCopyOptions,sqlTransaction)
            {
                BatchSize = this.BatchSize,
                DestinationTableName = destinationTableName ?? sourceDataTable.TableName ?? typeof(T).Name,
            };

            sourceDataTable.AddColumnMappings(sqlBulkCopy);

            long rowsInserted = 0;

            sqlBulkCopy.NotifyAfter = sourceDataTable.Rows.Count;
            sqlBulkCopy.SqlRowsCopied += (s, e) => rowsInserted = e.RowsCopied;

            await sqlBulkCopy.WriteToServerAsync(sourceDataTable);

            return rowsInserted;
        }
    }
}
