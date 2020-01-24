using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class DatabaseTest
    {
        readonly Mock<IReadCSV> readCSVMock = new Mock<IReadCSV>();
        readonly Mock<IDbDataParameter> parameterMock = new Mock<IDbDataParameter>();
        readonly Mock<IDbCommand> commandMock = new Mock<IDbCommand>();
        readonly Mock<IDbConnection> connectionMock = new Mock<IDbConnection>();
        readonly Mock<IDbConnectionFactory> iDbConnectionFactoryMock = new Mock<IDbConnectionFactory>();

        private List<Person> people;

        [TestInitialize]
        public void Setup()
        {
            readCSVMock.Setup(_ => _.GetCSVLines(It.IsAny<string>())).ReturnsAsync(TestHelpers.GetCSVLines());
            commandMock.Setup(_ => _.CreateParameter()).Returns(parameterMock.Object);
            commandMock.Setup(_ => _.Parameters.Add(parameterMock.Object));
            connectionMock.Setup(_ => _.CreateCommand()).Returns(commandMock.Object);
            iDbConnectionFactoryMock.Setup(_ => _.CreateConnection()).Returns(connectionMock.Object);
        }

        [TestMethod]
        public async Task Database_InsertUsingStoredProcedure_Test()
        {
            //Arrange
            CSVFile csvFile = new CSVFile(readCSVMock.Object);
            people = await csvFile.GetPeople("MockedFIleName.csv");

            var database = new Database(iDbConnectionFactoryMock.Object);

            // Act
            int rowsAffected = database.InsertUsingStoredProcedure(people);

            // Assert
            Assert.AreEqual(rowsAffected, people.Count);
        }
    }
}
