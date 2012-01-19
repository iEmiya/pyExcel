namespace pyExcel.Framework
{
    internal static class ExcelExtension
    {
        /// <summary>
        /// Преобразовать номер столбца в название
        /// </summary>
        /// <param name="columnNum"></param>
        /// <returns></returns>
        /// <remarks>http://stackoverflow.com/questions/181596/how-to-convert-a-column-number-eg-127-into-an-excel-column-eg-aa</remarks>
        public static string GetColumnName(int columnNum)
        {
            string range = "";
            if (columnNum < 0) return range;
            for (int i = 1; columnNum + i > 0; i = 0)
            {
                range = ((char)(65 + columnNum % 26)).ToString() + range;
                columnNum /= 26;
            }
            if (range.Length > 1) range = ((char)((int)range[0] - 1)).ToString() + range.Substring(1);
            return range;
        }
    }
}
