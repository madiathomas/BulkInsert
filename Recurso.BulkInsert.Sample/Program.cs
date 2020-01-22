using Autofac;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Recurso.BulkInsert.Sample.BLL;
using Microsoft.Extensions.Configuration;

namespace Recurso.BulkInsert.Sample
{
    class Program
    {
        // Run CreatePeopleDatabase.sql, which is under Recurso.BulkInsert.Sample.DAL project, to create the database and table required for this sample
        static IBusinessLogic businessLogic;

        static async Task Main()
        {
            var container = ContainerConfiguration.Configure();
           
            businessLogic = container.Resolve<IBusinessLogic>();

            try
            {
                int numberOfRecords = 1000;

                // Load list of people from a file
                List<Person> people = businessLogic.GetPeople(fileName: "People.csv").Take(numberOfRecords).ToList();

                await InsertUsingBulkInsert(people);

                InsertUsingStoredProcedure(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task InsertUsingBulkInsert(List<Person> people)
        {
            Console.WriteLine($"Inserting {people.Count} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            await businessLogic.InsertUsingBulkInsert(people);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records individually: {stopWatch.Elapsed.TotalSeconds}\n");
        }

        private static void InsertUsingStoredProcedure(List<Person> people)
        {
            Console.WriteLine($"Inserting {people.Count} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            businessLogic.InsertUsingStoredProcedure(people);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records individually: {stopWatch.Elapsed.TotalSeconds}\n");
        }
    }
}
