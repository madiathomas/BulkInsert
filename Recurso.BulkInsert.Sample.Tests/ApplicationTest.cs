using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.BLL;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recurso.BulkSMS.Sample.Tests
{
    [TestClass]
    public class ApplicationTest
    {
        readonly Mock<IBusinessLogic> businessLogicMock = new Mock<IBusinessLogic>(MockBehavior.Strict);

        [TestInitialize]
        public void Setup()
        {
            businessLogicMock.Setup(_ => _.InsertUsingBulkInsert(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(1);
            businessLogicMock.Setup(_ => _.InsertUsingStoredProcedure(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(1);
        }

        [TestMethod]
        public async Task Application_Run_InsertUsingStoredProcedure_Success()
        {
            // Arrange
            var application = new Application(businessLogicMock.Object);

            // Act
            await application.Run();
        }

        [TestMethod]
        public async Task Application_Run_InsertUsingStoredProcedure_Exception()
        {
            // Arrange
            businessLogicMock.Setup(_ => _.InsertUsingStoredProcedure(It.IsAny<string>(), It.IsAny<int>())).Throws(new StoredProcedureInsertFailedException());

            var application = new Application(businessLogicMock.Object);

            // Act
            await application.Run();
        }

        [TestMethod]
        public async Task Application_Run_InsertUsingBulkInsert_Exception()
        {
            // Arrange
            businessLogicMock.Setup(_ => _.InsertUsingBulkInsert(It.IsAny<string>(), It.IsAny<int>())).Throws(new BulkInsertFailedException());
            var application = new Application(businessLogicMock.Object);

            // Act
            await application.Run();
        }
    }
}
