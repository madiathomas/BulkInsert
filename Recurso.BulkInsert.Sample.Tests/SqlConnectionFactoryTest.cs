using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
using System.Data;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class SqlConnectionFactoryTest
    {
        private readonly Mock<IAppSettings> appSettingsMock = new Mock<IAppSettings>();

        [TestMethod]
        public void SqlConnectionFactory_CreateConnection()
        {
            // Arrange
            var  sqlConnectionFactory = new SqlConnectionFactory(appSettingsMock.Object);

            // Act
            IDbConnection actual = sqlConnectionFactory.CreateConnection();

            // Assert
            Assert.IsNotNull(actual);
        }
    }
}
