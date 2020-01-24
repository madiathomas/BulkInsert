using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.BLL
{
    public class BusinessLogic : IBusinessLogic
    {
        readonly IDatabase _database;
        readonly IQuickInsert _quickInsert;
        readonly ICSVFile _csvFile;

        public BusinessLogic(IDatabase database, ICSVFile csvFile, IQuickInsert quickInsert)
        {
            _database = database;
            _csvFile = csvFile;
            _quickInsert = quickInsert;
        }

        public async Task<int> InsertUsingStoredProcedure(string fileName, int numberOfRecords)
        {
            var people = await _csvFile.GetPeople(fileName, numberOfRecords);
            return _database.InsertUsingStoredProcedure(people);
        }

        public async Task InsertUsingBulkInsert(string fileName, int numberOfRecords)
        {
            var people = await _csvFile.GetPeople(fileName, numberOfRecords);
            await _quickInsert.InsertUsingBulkInsert(people.Take(numberOfRecords).ToList());
        }
    }
}
