using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.Common;
using Recurso.BulkInsert.Sample.DAL;
using System.Collections.Generic;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class QuickInsertTest
    {
        readonly List<Person> people = new List<Person>();

        [TestInitialize]
        public void Setup()
        {
            people.Add(new Person { FirstName = "James", LastName = "La Chapman", Gender = "Male", Age = "22", Email = "j.chapman@randatmail.com", Phone = "646-3513-39", Education = "Bachelors", Occupation = "Electrician", Experience = "15", MaritalStatus = "Married" });
            people.Add(new Person { FirstName = "Peter", LastName = "La Chapman", Gender = "Male", Age = "24", Email = "p.chapman@randatmail.com", Phone = "646-3513-39", Education = "Master", Occupation = "Programmer", Experience = "5", MaritalStatus = "Single" });
            people.Add(new Person { FirstName = "Lance", LastName = "La Chapman", Gender = "Male", Age = "26", Email = "l.chapman@randatmail.com", Phone = "646-3513-39", Education = "PhD", Occupation = "Professor", Experience = "20", MaritalStatus = "Divorced" });
        }

        [TestMethod]
        public async void QuickInsert_InsertListUsingBulkInsert()
        {
            //Arrange
            var mock = new MockRepository(MockBehavior.Default);

            var  bulkInsert = mock.OneOf<IBulkInsert>();

            var quickInsert = new QuickInsert(bulkInsert);

            // Act
            long result = await quickInsert.InsertUsingBulkInsert(people);

            //Assert
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public async void QuickInsert_InsertDataTableUsingBulkInsert()
        {
            //Arrange
            var mock = new MockRepository(MockBehavior.Default);

            var bulkInsert = mock.OneOf<IBulkInsert>();

            var quickInsert = new QuickInsert(bulkInsert);

            var dataTable = people.CopyToDataTable();

            // Act
            long result = await quickInsert.InsertUsingBulkInsert(dataTable);

            //Assert
            Assert.AreNotEqual(0, result);
        }
    }
}
