using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
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
            people.Add(new Person { FirstName = "James", LastName = "La Chapman", Gender = "Male", Age = "22", Email = "j.chapman @randatmail.com", Phone = "646-3513-39", Education = "Bachelors", Occupation = "Electrician", Experience = "15", MaritalStatus = "Married" });
            people.Add(new Person { FirstName = "Peter", LastName = "La Chapman", Gender = "Male", Age = "24", Email = "p.chapman @randatmail.com", Phone = "646-3513-39", Education = "Master", Occupation = "Programmer", Experience = "5", MaritalStatus = "Single" });
            people.Add(new Person { FirstName = "Lance", LastName = "La Chapman", Gender = "Male", Age = "26", Email = "l.chapman @randatmail.com", Phone = "646-3513-39", Education = "PhD", Occupation = "Professor", Experience = "20", MaritalStatus = "Divorced" });
        }

        [TestMethod]
        public async Task Database_InsertUsingStoredProcedure_Test()
        {
            //Arrange
            var mock = new MockRepository(MockBehavior.Default);

            var parameter = mock.OneOf<IDbDataParameter>();            
            var command = mock.OneOf<IDbCommand>(_=>_.CreateParameter() == parameter);
            var connection = mock.OneOf<IDbConnection>(_ => _.CreateCommand() == command);
            var factory = mock.OneOf<IDbConnectionFactory>(_ => _.CreateConnection() == connection);

            var database = new Database(factory);

            // Act
            int rowsAffected = await database.InsertUsingStoredProcedure(people);

            // Assert
            Assert.AreEqual(rowsAffected, people.Count);
        }
    }
}
