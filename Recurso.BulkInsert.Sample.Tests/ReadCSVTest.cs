using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using Recurso.BulkInsert.Sample.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class ReadCSVTest
    {
        private Mock<IReadCSV> readCSVMock = new Mock<IReadCSV>();

        [TestMethod]
        public void ReadCSV_GetCSVLines()
        {
            // Arrange
            readCSVMock.Setup(_=>_.GetCSVLines(It.IsAny<string>())).ReturnsAsync(TestHelpers.GetCSVLines());

            // Act
            var lines = readCSVMock.Object.GetCSVLines("TestPath.csv");

            // Assert
            Assert.IsNotNull(lines);
        }
    }
}
