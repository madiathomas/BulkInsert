using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.BLL;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class BusinessLogicTest
    {
        readonly Mock<IDatabase> databaseMock = new Mock<IDatabase>();
        readonly Mock<IQuickInsert> quickInsertMock = new Mock<IQuickInsert>();
        readonly Mock<ICSVFile> csvFileMock = new Mock<ICSVFile>();
        readonly Mock<IReadCSV> readCSVMock = new Mock<IReadCSV>();

        private CSVFile csvFile;
        private List<Person> people;
        readonly int numberOfRecords = 5;

        [TestInitialize]
        public void Setup()
        {
            databaseMock.Setup(_ => _.InsertUsingStoredProcedure(It.IsAny<List<Person>>())).Returns(numberOfRecords);
            quickInsertMock.Setup(_ => _.InsertUsingBulkInsert(It.IsAny<List<Person>>())).ReturnsAsync(numberOfRecords);
            readCSVMock.Setup(_ => _.GetCSVLines(It.IsAny<string>())).ReturnsAsync(TestHelpers.GetCSVLines());

        }

        [TestMethod]
        public async Task BusinessLogic_InsertUsingStoredProcedure()
        {
            // Arrange
            csvFile = new CSVFile(readCSVMock.Object);
            people = await csvFile.GetPeople("MockedFileName.csv", numberOfRecords);
            csvFileMock.Setup(_ => _.GetPeople(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(people);

            var businessLogic = new BusinessLogic(databaseMock.Object, csvFileMock.Object, quickInsertMock.Object);

            // Act
            int actual = await businessLogic.InsertUsingStoredProcedure("TestFile.csv", numberOfRecords);

            // Assert
            Assert.AreEqual(numberOfRecords, actual);
        }

        [TestMethod]
        public async Task BusinessLogic_InsertUsingBulkInsert()
        {
            // Arrange
            csvFile = new CSVFile(readCSVMock.Object);
            people = await csvFile.GetPeople("MockedFileName.csv", numberOfRecords);
            csvFileMock.Setup(_ => _.GetPeople(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(people);

            var businessLogic = new BusinessLogic(databaseMock.Object, csvFileMock.Object, quickInsertMock.Object);

            // Act
            int actual = await businessLogic.InsertUsingBulkInsert("TestFile.csv", numberOfRecords);

            // Assert
            Assert.AreEqual(numberOfRecords, actual);
        }
    }
}
