using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recurso.BulkInsert.Sample.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Recurso.BulkInsert.Sample.Tests
{
    [TestClass]
    public class AppSettingsTest
    {
        readonly string settingName = "DBCOnnectionString";

        [TestMethod]
        public void AppSettings_GetSetting()
        {
            // Arrange
            AppSettings appSettings = new AppSettings();

            // Act
            var actual = Assert.ThrowsException<FileNotFoundException>(() => appSettings.GetSetting(settingName));

            // Assert
            Assert.IsInstanceOfType(actual, typeof(FileNotFoundException));
        }
    }
}
