using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.BLL
{
    public class Application : IApplication
    {
        private readonly IBusinessLogic _businessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public async Task Run()
        {
            try
            {
                int numberOfRecords = 1000;

                // Load list of people from a file
                List<Person> people = _businessLogic.GetPeople(fileName: "People.csv").Take(numberOfRecords).ToList();

                await InsertUsingBulkInsert(people);

                InsertUsingStoredProcedure(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async Task InsertUsingBulkInsert(List<Person> people)
        {
            Console.WriteLine($"Inserting {people.Count} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            await _businessLogic.InsertUsingBulkInsert(people);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records individually: {stopWatch.Elapsed.TotalSeconds}\n");
        }

        private void InsertUsingStoredProcedure(List<Person> people)
        {
            Console.WriteLine($"Inserting {people.Count} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            _businessLogic.InsertUsingStoredProcedure(people);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records individually: {stopWatch.Elapsed.TotalSeconds}\n");
        }
    }
}
