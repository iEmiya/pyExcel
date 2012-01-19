using System;

namespace pyExcel.Framework.Exceptions
{
    /// <summary>
    /// Сообщение "Предупреждение"
    /// </summary>
    public abstract class Warning : Exception, IUIExceptionDetail
    {
        private const String CODE = "LNOgXtjwI0GnqbcjlT4g0w";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected Warning(String message, Exception innerException)
            : base(message, innerException)
        {
            Code = CODE;
            DetailMessage = typeof(Error).ToString();
        }

        #region IUIExceptionDetail Members

        public TypeThrow Type { get { return TypeThrow.Warning; } }
        public String Code { get; protected set; }
        public String DetailMessage { get; protected set; }

        #endregion
    }
}
