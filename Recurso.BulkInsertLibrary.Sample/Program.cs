using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recurso.BulkInsertLibrary.Sample
{
    class Program
    {
        // Run CreatePeopleDatabase.sql to create this database and table on your local machine
        static readonly string connectionString = "Server=.;Database=People;Integrated Security=true;";

        static async Task Main(string[] args)
        {
            try
            {
                // Innitialise BulkInsert object
                var bulkInsert = new SQLServerBulkInsert(connectionString);

                // Load list of people from a file
                List<Person> people = CSVHelper.GetPeople(fileName: "People.csv");

                // Bulk Insert data to the database
                await bulkInsert.Save<Person>(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
