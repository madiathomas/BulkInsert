using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recurso.BulkInsertLibrary.Sample
{
    class Program
    {
        // Use your own connection string here
        static readonly string connectionString = "Server=.;Database=People;Integrated Security=true;";

        static async Task Main(string[] args)
        {
            try
            {
                var bulkInsert = new BulkInsert()
                {
                    ConnectionString = connectionString
                };

                var people = GetPeople();

                await bulkInsert.Save<Person>(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<Person> GetPeople()
        {
            var people = File.ReadAllLines("People.csv")
                            .Skip(1)
                            .Select(p => FromCSV(p))
                            .ToList();
            return people;
        }

        public static Person FromCSV(string csvLine)
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
