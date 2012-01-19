using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Scripting;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    /// <summary>
    /// Получить данные из Excel файла, через NPOI
    /// </summary>
    /// <remarks>http://blog.darkthread.net/post-2011-05-14-npoi-convert-xls-to-datatable.aspx</remarks>
    public sealed class NPOIProvider : IProvider
    {
        private readonly ProviderFilter _filter;

        public NPOIProvider(ProviderFilter filter)
        {
            _filter = filter;
        }

        public ProviderFilter Filter { get { return _filter; } }

        public DataTable GetSource()
        {
            CheckExists();
            // Load the file into a NPOI workbook
            using(var sheet = GetSheet())
            {
                List<int> dataRowNumCollection = null;
                if(_filter.DataRowNumCollection != null)
                {
                    dataRowNumCollection = new List<int>(_filter.DataRowNumCollection);
                    dataRowNumCollection.Sort();
                }

                int sheetFirstRowNum = GetSheetFirstRowNum(sheet, dataRowNumCollection);
                int sheetLastRowNum = GetSheetLastRowNum(sheet, dataRowNumCollection);

                Row headerRow = sheet.GetRow(sheetFirstRowNum);

                int cellCount = headerRow.LastCellNum;
                int firstRowNum = _filter.FirstRowIsTheHeader ? (sheetFirstRowNum + 1) : sheetFirstRowNum;

                using(var table = CreateTable(headerRow, cellCount))
                {
                    for (int i = firstRowNum; i <= sheetLastRowNum; i++)
                    {
                        if((dataRowNumCollection != null) && (!dataRowNumCollection.Contains(i))) continue;

                        Row row = sheet.GetRow(i);
                        if (row == null) continue;

                        DataRow dataRow = table.NewRow();
                        
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                Cell cell = row.GetCell(j);
                                switch (cell.CellType)
                                {
                                    case CellType.NUMERIC:
                                        SetNumericCellValue(table, dataRow, cell, j, i);
                                        break;
                                    case CellType.STRING:
                                        SetStringCellValue(table, dataRow, cell, j, i);
                                        break;
                                    case CellType.FORMULA:
                                        SetCellFormula(table, dataRow, cell, j, i);
                                        break;
                                    case CellType.BLANK:
                                        SetCellBlank(table, dataRow, cell, j, i);
                                        break;
                                    case CellType.BOOLEAN:
                                        SetBooleanCellValue(table, dataRow, cell, j, i);
                                        break;
                                    case CellType.ERROR:
                                        SetCellError(table, dataRow, cell, j, i);
                                        break;
                                    default:
                                        throw new ArgumentTypeException("Unknown Cell Type: " + (object)cell.CellType);
                                }
                            }

                        }

                        table.Rows.Add(dataRow);
                    }

                    return table.Copy();
                }
            }
        }

        private void CheckExists()
        {
            var fi = new FileInfo(_filter.FileName);
            if (!fi.Exists)
                throw new FileNotFoundException(_filter.FileName);
        }

        private Sheet GetSheet()
        {
            Sheet sheet;
            using (var fs = new FileStream(_filter.FileName, FileMode.Open, FileAccess.Read))
            using (var workbook = new HSSFWorkbook(fs, true))
            {
                // Load the sheet you are going to use as a template into NPOI
                sheet = string.IsNullOrEmpty(_filter.SheetName) ? workbook.GetSheetAt(0) : workbook.GetSheet(_filter.SheetName);
                fs.Close();
            }

            if (sheet == null)
                throw new SheetNotFoundException(_filter.FileName, _filter.SheetName);
            return sheet;
        }

        private int GetSheetFirstRowNum(Sheet sheet, List<int> dataRowNumCollection)
        {
            if (dataRowNumCollection == null)
            {
                return sheet.FirstRowNum;
            }

            int firstDataRowNum = dataRowNumCollection.Min();
            int lastDataRowNum = dataRowNumCollection.Max();

            if ((firstDataRowNum < 0)
                || ((lastDataRowNum > 0) && (firstDataRowNum < sheet.FirstRowNum))
                || ((firstDataRowNum > 0) && (firstDataRowNum > sheet.LastRowNum))
                )
            {
                throw new FirstDataRowNumException(firstDataRowNum, sheet.FirstRowNum, sheet.LastRowNum);
            }

            return firstDataRowNum;
        }

        private int GetSheetLastRowNum(Sheet sheet, List<int> dataRowNumCollection)
        {
            if (dataRowNumCollection == null)
            {
                return sheet.LastRowNum;
            }

            int firstDataRowNum = dataRowNumCollection.Min();
            int lastDataRowNum = dataRowNumCollection.Max();

            if ((lastDataRowNum < 0)
                || ((lastDataRowNum > 0) && (lastDataRowNum < sheet.FirstRowNum))
                || ((lastDataRowNum > 0) && (lastDataRowNum > sheet.LastRowNum))
                )
            {
                throw new LastDataRowNumException(lastDataRowNum, sheet.FirstRowNum, sheet.LastRowNum);
            }
            return lastDataRowNum;
        }

        private DataTable CreateTable(Row headerRow, int cellCount)
        {
            DataTable table = new DataTable();
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                Cell cell = headerRow.GetCell(i);

                string columnName = GetColumnName(cell, i);
                AddColumn(cell, table, columnName);
            }
            return table;
        }

        private string GetColumnName(Cell cell, int columnNum)
        {
            if (_filter.FirstRowIsTheHeader)
                return NPOIExtension.ToString(cell);

            return ExcelExtension.GetColumnName(columnNum);
        }

        private void AddColumn(Cell cell, DataTable table, string columnName)
        {
            if (_filter.SetColumnType)
            {
                Type dataType = cell.GetDataType();
                table.Columns.Add(new DataColumn(columnName, dataType));
                return;
            }

            table.Columns.Add(new DataColumn(columnName));
        }

        #region SetCell

        private void SetNumericCellValue(DataTable table, DataRow dataRow, Cell cell, int columnNum, int rowNum)
        {
            if (!_filter.SetColumnType)
            {
                dataRow[columnNum] = cell.NumericCellValue.ToString();
                return;
            }

            Type columnType = table.Columns[columnNum].DataType;
            if (columnType == typeof(double))
            {
                dataRow[columnNum] = (double)cell.NumericCellValue;
                return;
            }

            string columnName = table.Columns[columnNum].ColumnName;
            throw new CellTypeException(_filter.SheetName, columnName, columnType, rowNum, typeof(double));
        }

        private void SetStringCellValue(DataTable table, DataRow dataRow, Cell cell, int columnNum, int rowNum)
        {
            if (!_filter.SetColumnType)
            {
                dataRow[columnNum] = cell.StringCellValue;
                return;
            }

            Type columnType = table.Columns[columnNum].DataType;
            if (columnType == typeof(string))
            {
                dataRow[columnNum] = (string)cell.StringCellValue;
                return;
            }

            string columnName = table.Columns[columnNum].ColumnName;
            throw new CellTypeException(_filter.SheetName, columnName, columnType, rowNum, typeof(string));
        }

        private void SetCellFormula(DataTable table, DataRow dataRow, Cell cell, int columnNum, int rowNum)
        {
            if (!_filter.SetColumnType)
            {
                dataRow[columnNum] = cell.CellFormula;
                return;
            }

            Type columnType = table.Columns[columnNum].DataType;
            if (columnType == typeof(string))
            {
                dataRow[columnNum] = (string)cell.CellFormula;
                return;
            }

            string columnName = table.Columns[columnNum].ColumnName;
            throw new CellTypeException(_filter.SheetName, columnName, columnType, rowNum, typeof(string));
        }

        private void SetCellBlank(DataTable table, DataRow dataRow, Cell cell, int columnNum, int rowNum)
        {
            if (!_filter.SetColumnType)
            {
                dataRow[columnNum] = string.Empty;
                return;
            }

            Type columnType = table.Columns[columnNum].DataType;
            if (columnType == typeof(string))
            {
                dataRow[columnNum] = (string)string.Empty;
                return;
            }

            string columnName = table.Columns[columnNum].ColumnName;
            throw new CellTypeException(_filter.SheetName, columnName, columnType, rowNum, typeof(string));
        }

        private void SetBooleanCellValue(DataTable table, DataRow dataRow, Cell cell, int columnNum, int rowNum)
        {
            if (!_filter.SetColumnType)
            {
                dataRow[columnNum] = cell.BooleanCellValue.ToString();
                return;
            }

            Type columnType = table.Columns[columnNum].DataType;
            if (columnType == typeof(bool))
            {
                dataRow[columnNum] = (bool)cell.BooleanCellValue;
                return;
            }

            string columnName = table.Columns[columnNum].ColumnName;
            throw new CellTypeException(_filter.SheetName, columnName, columnType, rowNum, typeof(bool));
        }

        private void SetCellError(DataTable table, DataRow dataRow, Cell cell, int columnNum, int rowNum)
        {
            const string ERROR_MESSAGE = "Not Supported";

            if (!_filter.SetColumnType)
            {
                dataRow[columnNum] = ERROR_MESSAGE;
                return;
            }

            Type columnType = table.Columns[columnNum].DataType;
            if (columnType == typeof(string))
            {
                dataRow[columnNum] = (string)ERROR_MESSAGE;
                return;
            }

            string columnName = table.Columns[columnNum].ColumnName;
            throw new CellTypeException(_filter.SheetName, columnName, columnType, rowNum, typeof(string));
        }

        #endregion
    }

    /// <summary>
    /// Изменение типа элементов в колонке Excel
    /// </summary>
    public sealed class CellTypeException : Exceptions.Stop
    {
        private const string CODE = "A7QUiQ9vzEaXeDkO5mspsQ";

        public CellTypeException(string sheetName, string columnName, Type columnType, int rowNo, Type rowType)
            : base(Resource.CellTypeException, new System.ApplicationException())
        {
            Code = CODE;
            DetailMessage = string.Format(Resource.CellTypeExceptionDetailMessagePattern,
                sheetName, columnName, columnType, rowNo+1, rowType);
        }
    }

    /// <summary>
    /// Ошибка при задании начальной строчки с данными
    /// </summary>
    public sealed class FirstDataRowNumException : Exceptions.Asterisk
    {
        private const string CODE = "P2_wcdB93UW7lrTt3TQYmA";

        public FirstDataRowNumException(int firstDataRowNum, int firstRowNum, int lastRowNum)
            : base(Resource.FirstDataRowNumException, new System.ApplicationException())
        {
            Code = CODE;
            DetailMessage = string.Format(Resource.FirstDataRowNumExceptionDetailMessagePattern,
                firstDataRowNum, firstRowNum, lastRowNum);
        }
    }

    /// <summary>
    /// Ошибка при задании начальной строчки с данными
    /// </summary>
    public sealed class LastDataRowNumException : Exceptions.Asterisk
    {
        private const string CODE = "NyRCSPLSdUuziCzQEChhFA";

        public LastDataRowNumException(int lastDataRowNum, int firstRowNum, int lastRowNum)
            : base(Resource.LastDataRowNumException, new System.ApplicationException())
        {
            Code = CODE;
            DetailMessage = string.Format(Resource.LastDataRowNumExceptionDetailMessagePattern,
                lastDataRowNum, firstRowNum, lastRowNum);
        }
    }
}
