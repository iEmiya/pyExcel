using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    /// <summary>
    /// Не удалось найти файл
    /// </summary>
    public sealed class FileNotFoundException : Exceptions.Error
    {
        private const string CODE = "a7x5ky5KDEqS9KNDJy02iw";

        public FileNotFoundException(string fileName)
            : base(Resource.FileNotFoundException, new System.IO.FileNotFoundException())
        {
            Code = CODE;
            DetailMessage = string.Format(Resource.FileNotFoundExceptionDetailMessagePattern, fileName);
        }
    }
}
