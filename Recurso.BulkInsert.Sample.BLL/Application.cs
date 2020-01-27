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

        public async Task<bool> Run()
        {
            int numberOfRecords = 10000;
            string fileName = "People.csv";

            try
            {

                await InsertUsingBulkInsert(fileName, numberOfRecords);

                await InsertUsingStoredProcedure(fileName, numberOfRecords);

                return true;
            }
            catch (BulkInsertFailedException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (StoredProcedureInsertFailedException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private async Task InsertUsingBulkInsert(string fileName, int numberOfRecords)
        {
            Console.WriteLine($"Inserting {numberOfRecords} records in bulk...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            await _businessLogic.InsertUsingBulkInsert(fileName, numberOfRecords);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records in bulk: {stopWatch.Elapsed.TotalSeconds}\n");
        }

        private async Task InsertUsingStoredProcedure(string fileName, int numberOfRecords)
        {
            Console.WriteLine($"Inserting {numberOfRecords} records individually...");

            // Use stop watch to determine how fast the update was
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            // Insert data
            await _businessLogic.InsertUsingStoredProcedure(fileName, numberOfRecords);

            // Stop the timer
            stopWatch.Stop();

            // Display time elapsed
            Console.WriteLine($"Time Elapsed inserting records individually: {stopWatch.Elapsed.TotalSeconds}\n");
        }
    }
}
