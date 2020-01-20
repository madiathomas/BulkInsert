using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Recurso.BulkInsert
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// This method converts a generic list into a DataTable. Properties will be used as columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Generic list of data that you want to copy to a DataTable.</param>
        /// <returns></returns>
        public static DataTable CopyToDataTable<T>(this List<T> data)
        {
            var dataTable = new DataTable(typeof(T).Name);

            // Get properties and sort them by metadatatoken to preserve their order. If it is in an incorrect order, bulk insert will fail.
            var properties = typeof(T).GetProperties().OrderBy(_ => _.MetadataToken);

            // Add colums to the dataTable
            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add values to the dataTable
            foreach (T item in data)
            {
                DataRow row = dataTable.NewRow();

                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static void AddColumnMappings(this DataTable dataTable, SqlBulkCopy sqlBulkCopy)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
        }
    }
}
