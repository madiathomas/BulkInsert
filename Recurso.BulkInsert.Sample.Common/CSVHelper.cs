using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Recurso.BulkInsert.Sample.Common
{
    public class CSVHelper
    {
        public static List<Person> GetPeople(string fileName)
        {
            var people = File.ReadAllLines(fileName)
                            .Skip(1)
                            .Select(p => FromCSV(p))
                            .ToList();
            return people;
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
