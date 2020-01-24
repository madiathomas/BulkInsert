using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.DAL
{

    public class CSVFile : ICSVFile
    {
        private readonly IReadCSV _readCSV;

        public CSVFile(IReadCSV readCSV)
        {
            _readCSV = readCSV;
        }

        public async Task<List<Person>> GetPeople(string fileName)
        {
            var lines = await _readCSV.GetCSVLines(fileName);

            return lines.Skip(1).Select(p => FromCSV(p)).ToList();
        }

        private static Person FromCSV(string csvLine)
        {
            string[] values = csvLine.Split(',');

            var person = new Person
            {
                FirstName = values[0],
                LastName = values[1],
                Gender = values[2],
                Age = values[3],
                Email = values[4],
                Phone = values[5],
                Education = values[6],
                Occupation = values[7],
                Experience = values[8],
                MaritalStatus = values[9],
            };

            return person;
        }
    }
}
