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


        public BusinessLogic(IDatabase database, ICSVFile csvFile)
        {
            _database = database;
            _csvFile = csvFile;
        }

        public async Task InsertUsingStoredProcedure(List<Person> people)
        {
            await _database.InsertUsingStoredProcedure(people);
        }

        public async Task InsertUsingBulkInsert(List<Person> people)
        {
            await _database.InsertUsingBulkInsert(people);
        }

        public List<Person> GetPeople(string fileName)
        {
            return _csvFile.GetPeople(fileName);
        }
    }
}
