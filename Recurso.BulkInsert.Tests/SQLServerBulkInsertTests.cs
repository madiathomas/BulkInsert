using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkInsert.Tests
{
    [TestClass]
    public class SQLServerBulkInsertTests
    {
        List<Person> people = new List<Person>();
        readonly Mock mock = new Mock<Person>();

        [TestInitialize]
        public void Setup()
        {
            people = Person.GetTestList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task SQLServerBulkInsertTests_Save_DataTable()
        {
            //Arrange
            var connectionFactory = new Mock<IDbConnectionFactory>();

            // Setup
            var sqlServerBulkInsert = new SQLServerBulkInsert(connectionFactory.Object);
            var dataTable = people.CopyToDataTable();

            // Act
            long actual = await sqlServerBulkInsert.Save<Person>(dataTable);

            // Assert
            Assert.AreNotSame(0, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task SQLServerBulkInsertTests_Save_List()
        {
            //Arrange
            var connectionFactory = new Mock<IDbConnectionFactory>();

            // Setup
            var sqlServerBulkInsert = new SQLServerBulkInsert(connectionFactory.Object);

            // Act
            long actual = await sqlServerBulkInsert.Save<Person>(people);

            // Assert
            Assert.AreNotSame(0, actual);
        }
    }
}
