using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Recurso.BulkInsertLibrary
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// This method converts a generic list into a DataTable. Properties will be used as columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable CopyToDataTable<T>(this List<T> data)
        {
            var dataTable = new DataTable(nameof(T));
            var properties = typeof(T).GetProperties().OrderBy(_ => _.MetadataToken);

            //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

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
    }
}
