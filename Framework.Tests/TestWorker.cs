using System.Data;
using NUnit.Framework;

namespace pyExcel.Framework.Tests
{
    [TestFixture]
    public class TestWorker
    {
        private const string PythonFileName = "./Internal Resources/sample.py";
        private const string ExcelFileName = "./Internal Resources/sample.xls";

        [Test]
        public void TestInstance()
        {
            var filter = new ProviderFilter();
            filter.FileName = ExcelFileName;

            IProvider viewProvider = new NPOIProvider(filter);
            IProvider workProvider = new NPOIProvider(filter);
            Worker worker = new Worker(viewProvider, workProvider, PythonFileName);
        }

        [Test]
        public void TestDo()
        {
            var filter = new ProviderFilter();
            filter.FileName = ExcelFileName;
            filter.SetColumnType = true;

            IProvider viewProvider = new NPOIProvider(filter);
            IProvider workProvider = new NPOIProvider(filter);
            Worker worker = new Worker(viewProvider, workProvider, PythonFileName);
            worker.DataTableBefore += new SetDataTableBefore(worker_DataTableBefore);
            worker.DataTableAfter += new SetDataTableAfter(worker_DataTableAfter);
            worker.Do();
        }

        void worker_DataTableAfter(System.Data.DataTable dataTable)
        {
            Assert.That(dataTable.Columns.Count, Is.EqualTo(3));
            Assert.That(dataTable.Rows.Count, Is.EqualTo(6));
            foreach (DataRow row in dataTable.Rows)
            {
                Assert.That(row.IsNull(2), Is.False);
                Assert.That(row[2], Is.EqualTo("15"));
            }
        }

        void worker_DataTableBefore(System.Data.DataTable dataTable)
        {
            Assert.That(dataTable.Columns.Count, Is.EqualTo(2+1));
            Assert.That(dataTable.Columns[MainPresenterHelper.ColumnSystemNumName], Is.Not.Null);
            Assert.That(dataTable.Rows.Count, Is.EqualTo(6));
        }
    }
}
