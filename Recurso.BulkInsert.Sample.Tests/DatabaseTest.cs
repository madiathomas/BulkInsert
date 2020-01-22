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
        readonly List<Person> people = new List<Person>();

        [TestInitialize]
        public void Setup()
        {
            people.Add(new Person { FirstName = "James", LastName = "La Chapman", Gender = "Male", Age = "22", Email = "j.chapman@example.com", Phone = "646-3513-37", Education = "Bachelors", Occupation = "Electrician", Experience = "15", MaritalStatus = "Married" });
            people.Add(new Person { FirstName = "Peter", LastName = "La Chapman", Gender = "Male", Age = "24", Email = "p.chapman@example.com", Phone = "646-3513-38", Education = "Master", Occupation = "Programmer", Experience = "5", MaritalStatus = "Single" });
            people.Add(new Person { FirstName = "Lance", LastName = "La Chapman", Gender = "Male", Age = "26", Email = "l.chapman@example.com", Phone = "646-3513-39", Education = "PhD", Occupation = "Professor", Experience = "20", MaritalStatus = "Divorced" });
        }

        [TestMethod]
        public async Task Database_InsertUsingStoredProcedure_Test()
        {
            //Arrange
            var list = new ArrayList(); // ArrayList more closely matches IDataParameterCollection.

            var parameterMock = new Mock<IDbDataParameter>();
            var parametersMock = new Mock<IDataParameterCollection>();
            var commandMock = new Mock<IDbCommand>();
            var connectionMock = new Mock<IDbConnection>();
            var iDbConnectionFactoryMock = new Mock<IDbConnectionFactory>();

            commandMock.Setup(_ => _.CreateParameter()).Returns(parameterMock.Object);
            commandMock.Setup(_ => _.Parameters.Add(parameterMock.Object));
            connectionMock.Setup(_ => _.CreateCommand()).Returns(commandMock.Object);
            iDbConnectionFactoryMock.Setup(_ => _.CreateConnection()).Returns(connectionMock.Object);

            var database = new Database(iDbConnectionFactoryMock.Object);

            // Act
            int rowsAffected = await database.InsertUsingStoredProcedure(people);

            // Assert
            Assert.AreEqual(rowsAffected, people.Count);
        }
    }
}
