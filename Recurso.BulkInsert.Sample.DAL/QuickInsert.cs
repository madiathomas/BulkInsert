using Microsoft.Extensions.Configuration;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class QuickInsert : IQuickInsert
    {
        readonly IBulkInsert _bulkInsert;

        public QuickInsert(IBulkInsert bulkInsert)
        {
            _bulkInsert = bulkInsert;
        }

        public async Task<int> InsertUsingBulkInsert(DataTable dataTable)
        {
            await _bulkInsert.Save<Person>(dataTable);

            return dataTable.Rows.Count;
        }

        public async Task<int> InsertUsingBulkInsert(List<Person> people)
        {
            await _bulkInsert.Save<Person>(people);

            return people.Count;
        }
    }
}
