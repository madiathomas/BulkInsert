﻿using Autofac;
using Recurso.BulkInsert.Sample.BLL;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
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
            var container = ContainerConfiguration.Configure();
            var businessLogic = container.Resolve<IBusinessLogic>();

            try
            {
                int numberOfRecords = 1000;

                // Load list of people from a file
                List<Person> people = businessLogic.GetPeople(fileName: "People.csv").Take(numberOfRecords).ToList();

                await InsertUsingBulkInsert(businessLogic, people);

                await InsertUsingStoredProcedure(businessLogic, people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task InsertUsingBulkInsert(IBusinessLogic businessLogic, List<Person> people)
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

        private static async Task InsertUsingStoredProcedure(IBusinessLogic businessLogic, List<Person> people)
        {
            Console.WriteLine($"Inserting {people.Count} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            await businessLogic.InsertUsingStoredProcedure(people);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records individually: {stopWatch.Elapsed.TotalSeconds}\n");
        }
    }
}
