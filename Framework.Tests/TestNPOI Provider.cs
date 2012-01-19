using NUnit.Framework;

namespace pyExcel.Framework.Tests
{
    [TestFixture]
    public class TestNPOIProvider
    {
        [Test]
        public void TestInstance()
        {
            var filter = new ProviderFilter();
            IProvider provider = new NPOIProvider(filter);
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetSource_FileNotFoundException()
        {
            const string fileName = "./Internal Resources/sample1.xls";

            var filter = new ProviderFilter();
            filter.FileName = fileName;

            IProvider provider = new NPOIProvider(filter);
            var dataTable = provider.GetSource();
        }

        [Test]
        [ExpectedException(typeof(SheetNotFoundException))]
        public void TestGetSource_SheetNotFoundException()
        {
            const string fileName = "./Internal Resources/sample.xls";
            var filter = new ProviderFilter();
            filter.FileName = fileName;
            filter.SheetName = "Sheet1";

            IProvider provider = new NPOIProvider(filter);
            var dataTable = provider.GetSource();
        }

        [Test]
        public void TestGetSource()
        {
            const string fileName = "./Internal Resources/sample.xls";

            var filter = new ProviderFilter();
            filter.FileName = fileName;
            filter.SheetName = "Лист1";

            IProvider provider = new NPOIProvider(filter);
            var dataTable = provider.GetSource();

            Assert.That(dataTable.Columns.Count, Is.EqualTo(2));
            Assert.That(dataTable.Columns[0].ColumnName, Is.EqualTo("A"));
            Assert.That(dataTable.Columns[1].ColumnName, Is.EqualTo("B"));

            Assert.That(dataTable.Rows.Count, Is.EqualTo(6));
        }
    }
}
