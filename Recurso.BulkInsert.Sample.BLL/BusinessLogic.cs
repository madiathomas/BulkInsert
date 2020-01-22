using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
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

        public int InsertUsingStoredProcedure(List<Person> people)
        {
            return _database.InsertUsingStoredProcedure(people);
        }

        public async Task InsertUsingBulkInsert(List<Person> people)
        {
            await _quickInsert.InsertUsingBulkInsert(people);
        }

        public List<Person> GetPeople(string fileName)
        {
            return _csvFile.GetPeople(fileName);
        }
    }
}
