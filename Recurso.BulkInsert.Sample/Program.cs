using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample
{
    class Program
    {
        // Run CreatePeopleDatabase.sql to create this database and table on your local machine
        static readonly string connectionString = "Server=.;Database=People;Integrated Security=true;";

        static async Task Main(string[] args)
        {
            try
            {
              /*
               * * Spreadsheet contains 10,000 records.I am using 1000 records for this demo.
               * The more records you use, the more BulkInsert is noticeable faster
               * Adding more data only adds few milliseconds to bulk insert but way more for individual inserts
               * Difference between stored procedure and bulk insert was 15 seconds for 1000 records
               * For 10, 000 records, difference was too big.For bulk insert, it was just 2 seconds
               * Individual inserts took more than 149 seconds for 10,000 records
             */

              int numberOfRecords = 10000;

                // Load list of people from a file
                List<Person> people = CSVHelper.GetPeople(fileName: "People.csv").Take(numberOfRecords).ToList();

                await InsertUsingBulkInsert(people);
                await InsertUsingStoredProcedure(people);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task InsertUsingStoredProcedure(List<Person> people)
        {
            var database = new Database(connectionString);

            Console.WriteLine($"Inserting {people.Count} records using BulkInsert...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            foreach (var person in people)
            {
                await database.InsertPerson(person);
            }

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed using BulkInsert: {stopWatch.Elapsed.TotalSeconds}\n");
        }

        private static async Task InsertUsingBulkInsert(List<Person> people)
        {
            // Innitialise BulkInsert object
            var bulkInsert = new SQLServerBulkInsert(connectionString);

            Console.WriteLine($"Inserting {people.Count} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Bulk Insert data to the database
            await bulkInsert.Save<Person>(people);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed using BulkInsert: {stopWatch.Elapsed.TotalSeconds}\n");
        }
    }
}
