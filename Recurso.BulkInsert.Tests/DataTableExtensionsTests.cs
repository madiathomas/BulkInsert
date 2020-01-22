using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;

namespace Recurso.BulkInsert.Tests
{

    [TestClass]
    public class DataTableExtensionsTests
    {
        List<TestPerson> testPeople = new List<TestPerson>();

        [TestInitialize]
        public void Setup()
        {
            testPeople = TestPerson.GetTestList();
        }

        [TestMethod]
        public void DataTableExtensions_CopyToDataTable_TableName()
        {
            DataTable dataTable = testPeople.CopyToDataTable();

            Assert.AreEqual(dataTable.TableName, "TestPerson");
        }

        [TestMethod]
        public void DataTableExtensions_CopyToDataTable_RowsCount()
        {

            DataTable dataTable = testPeople.CopyToDataTable();

            Assert.AreEqual(dataTable.Rows.Count, 3);
        }

        [TestMethod]
        public void DataTableExtensions_CopyToDataTable_ColumnsCount()
        {
            DataTable dataTable = testPeople.CopyToDataTable();

            Assert.AreEqual(dataTable.Columns.Count, 2);
        }
    }
}
