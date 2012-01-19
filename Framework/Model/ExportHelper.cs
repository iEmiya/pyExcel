using System;
using System.Data;
using System.IO;
using System.Reflection;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    internal sealed class ExportHelper
    {
        private readonly AssemblyCompanyAttribute _companyAttribute;
        private readonly AssemblyProductAttribute _productAttribute;

        public ExportHelper()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            _companyAttribute = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute));
            _productAttribute = (AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute));
        }

        /// <summary>
        /// Экспорт данных в Excel
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="fileName"></param>
        /// <exception cref="Exception"></exception>
        public void Export(DataTable sourceTable, string fileName)
        {
            using (var workbook = new HSSFWorkbook())
            {
                //Create a entry of DocumentSummaryInformation
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = _companyAttribute.Company;
                workbook.DocumentSummaryInformation = dsi;

                //Create a entry of SummaryInformation
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Subject = _productAttribute.Product;
                workbook.SummaryInformation = si;


                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                using (var sheet = workbook.CreateSheet(Resource.SheetNameDefault))
                {
                    Row headerRow = sheet.CreateRow(0);

                    // handling header.
                    foreach (DataColumn column in sourceTable.Columns)
                    {
                        Cell dataCell = headerRow.CreateCell(column.Ordinal);
                        dataCell.SetCellValue(column.ColumnName);
                    }

                    // handling value.
                    int rowIndex = 1;

                    foreach (DataRow row in sourceTable.Rows)
                    {
                        Row dataRow = sheet.CreateRow(rowIndex);

                        foreach (DataColumn column in sourceTable.Columns)
                        {
                            Cell dataCell = dataRow.CreateCell(column.Ordinal);
                            dataCell.SetCellValue(row[column].ToString());
                        }

                        rowIndex++;
                    }

                    workbook.Write(fs);
                    fs.Flush();
                    fs.Close();
                }
            }


        }
    }
}
