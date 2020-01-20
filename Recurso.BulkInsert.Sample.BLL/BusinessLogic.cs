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
        readonly ICSVFile _csvFile;
        readonly IBulkInsert _bulkInsert;

        public string ConnectionString { get; set; } 

        public BusinessLogic(IDatabase database, ICSVFile csvFile, IBulkInsert bulkInsert)
        {
            _database = database;
            _csvFile = csvFile;
            _bulkInsert = bulkInsert;
        }

        public async Task InsertUsingStoredProcedure(List<Person> people)
        {
            await _database.InsertUsingStoredProcedure(people);
        }

        public async Task InsertUsingBulkInsert(List<Person> people)
        {
            await _bulkInsert.Save(people);
        }

        public List<Person> GetPeople(string fileName)
        {
            return _csvFile.GetPeople(fileName);
        }
    }
}
