using System;
using Microsoft.Scripting;
using NPOI.SS.UserModel;

namespace pyExcel.Framework
{
    internal static class NPOIExtension
    {
        /// <summary>
        /// <see cref="NPOI.HSSF.UserModel.HSSFCell.ToString"/>
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string ToString(Cell cell)
        {
            switch (cell.CellType)
            {
                case CellType.NUMERIC:
                    cell.CellStyle.GetDataFormatString();
                    return new DataFormatter().FormatCellValue((Cell)cell);
                case CellType.STRING:
                    return cell.StringCellValue;
                case CellType.FORMULA:
                    return cell.CellFormula;
                case CellType.BLANK:
                    return "";
                case CellType.BOOLEAN:
                    if (!cell.BooleanCellValue)
                        return "FALSE";
                    else
                        return "TRUE";
                //case CellType.ERROR:
                //    return ErrorEval.GetText((int)((BoolErrRecord)this.record).ErrorValue);
                default:
                    return "Unknown Cell Type: " + (object)cell.CellType;
            }
        }

        /// <summary>
        /// Получить системный тип данных, находящихся в ячейке
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static Type GetDataType(this Cell cell)
        {
            switch (cell.CellType)
            {
                case CellType.NUMERIC:
                    return typeof(double);
                case CellType.STRING:
                    return typeof(string);
                case CellType.FORMULA:
                    return typeof(string);
                case CellType.BLANK:
                    return typeof(string);
                case CellType.BOOLEAN:
                    return typeof(bool);
                case CellType.ERROR:
                    return typeof(string);
                default:
                    throw new ArgumentTypeException("Unknown Cell Type: " + (object)cell.CellType);
            }
        }

        public static CellType GetCellType(Type type)
        {
            if (type == typeof(double))
                return CellType.NUMERIC;
            if (type == typeof(string))
                return CellType.STRING;
            if (type == typeof(bool))
                return CellType.BOOLEAN;

            throw new ArgumentTypeException("Unknown Type: " + (object)type);
        }
    }
}
