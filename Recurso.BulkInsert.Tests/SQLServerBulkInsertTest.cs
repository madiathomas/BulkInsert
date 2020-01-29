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
        private readonly string connectionString = "Server=9df895c4284b43b68b18fe9b5eefb410;Database=0308888e6593458e97cc90cbdc92001b;Integrated Security=true; Connection Timeout=1";

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