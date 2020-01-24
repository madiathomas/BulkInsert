using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Tests
{
    [TestClass]
    public class SQLServerBulkInsertTest
    {
        readonly Mock<IDbConnectionFactory> dbConnectionFactoryMock = new Mock<IDbConnectionFactory>();

        private List<TestPerson> testPeople;
        private readonly string connectionString = "Server=MockServer;Database=MockDatabase;Integrated Security=true; Connection Timeout=1";

        [TestInitialize]
        public void Setup()
        {
            testPeople = TestPerson.GetTestList();

            IDbConnection connection = new SqlConnection(connectionString);
            dbConnectionFactoryMock.Setup(_ => _.CreateConnection()).Returns(connection);
        }

        [TestMethod]
        public async Task SQLServerBulkInsert_Save_List()
        {
            // Arrange
            var sqlServerBulkInsert = new SQLServerBulkInsert(dbConnectionFactoryMock.Object)
            {
                BatchSize = 1000
            };

            // Act
            var actual = await Assert.ThrowsExceptionAsync<SqlException>(async () => await sqlServerBulkInsert.Save<TestPerson>(testPeople));

            // Assert
            Assert.IsInstanceOfType(actual, typeof(SqlException));
        }
    }
}