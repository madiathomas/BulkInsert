using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class QuickInsertTest
    {
        readonly Mock<IBulkInsert> bulkInsertMock = new Mock<IBulkInsert>();
        readonly Mock<IReadCSV> readCSVMock = new Mock<IReadCSV>();

        [TestMethod]
        public async Task QuickInsert_InsertListUsingBulkInsert()
        {
            //Arrange
            CSVFile csvFile = new CSVFile(readCSVMock.Object);
            var people = await csvFile.GetPeople("MockedFIleName.csv", 10);

            QuickInsert quickInsert = new QuickInsert(bulkInsertMock.Object);

            // Act
            long result = await quickInsert.InsertUsingBulkInsert(people);

            //Assert
            Assert.AreEqual(people.Count, result);
        }

        [TestMethod]
        public async Task QuickInsert_InsertDataTableUsingBulkInsert()
        {
            //Arrange
            CSVFile csvFile = new CSVFile(readCSVMock.Object);
            var people = await csvFile.GetPeople("MockedFIleName.csv", 10);

            QuickInsert quickInsert = new QuickInsert(bulkInsertMock.Object);

            var dataTable = people.CopyToDataTable();

            // Act
            long result = await quickInsert.InsertUsingBulkInsert(dataTable);

            //Assert
            Assert.AreEqual(dataTable.Rows.Count, result);
        }
    }
}
