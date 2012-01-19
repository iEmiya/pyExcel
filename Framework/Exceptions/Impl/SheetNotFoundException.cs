using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    /// <summary>
    /// Не удалось найти лист в файле Excel
    /// </summary>
    public sealed class SheetNotFoundException : Exceptions.Error
    {
        private const string CODE = "sazLHVPwu0qMMPuafHbgVA";

        public SheetNotFoundException(string fileName, string sheetName)
            : base(Resource.SheetNotFoundException, new System.ApplicationException())
        {
            Code = CODE;
            DetailMessage = string.Format(Resource.SheetNotFoundExceptionDetailMessagePattern, fileName, sheetName);
        }
    }
}
