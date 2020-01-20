using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;

namespace Recurso.BulkInsert.Tests
{

    [TestClass]
    public class DataTableExtensionsTests
    {
        List<Person> people = new List<Person>();

        [TestInitialize]
        public void Setup()
        {
            people = Person.GetTestList();
        }

        [TestMethod]
        public void DataTableExtensions_CopyToDataTable_TableName()
        {
            DataTable dataTable = people.CopyToDataTable();

            Assert.AreEqual(dataTable.TableName, "Person");
        }

        [TestMethod]
        public void DataTableExtensions_CopyToDataTable_RowsCount()
        {

            DataTable dataTable = people.CopyToDataTable();

            Assert.AreEqual(dataTable.Rows.Count, 3);
        }

        [TestMethod]
        public void DataTableExtensions_CopyToDataTable_ColumnsCount()
        {
            DataTable dataTable = people.CopyToDataTable();

            Assert.AreEqual(dataTable.Columns.Count, 2);
        }
    }
}
