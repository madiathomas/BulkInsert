using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class CSVFileTest
    {
        readonly Mock<IReadCSV> readCSVMock = new Mock<IReadCSV>();
        private string[] csvLines;

        [TestInitialize]
        public void Setup()
        {
            csvLines = TestHelpers.GetCSVLines();
        }

        [TestMethod]
        public async Task CSVFile_GetPeople()
        {
            // Arrange
            readCSVMock.Setup(_ => _.GetCSVLines(It.IsAny<string>())).ReturnsAsync(csvLines);

            var csvFile = new CSVFile(readCSVMock.Object);

            // Act
            List<Person> people = await csvFile.GetPeople("MockedFileName.csv", 10);

            // Assert
            Assert.IsNotNull(people);
        }
    }
}
