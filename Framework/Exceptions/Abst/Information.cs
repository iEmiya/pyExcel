using System;

namespace pyExcel.Framework.Exceptions
{
    /// <summary>
    /// Сообщение "Информация"
    /// </summary>
    public abstract class Information : Exception, IUIExceptionDetail
    {
        private const String CODE = "rbJq2sp500id6Hvq5eR12w";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected Information(String message, Exception innerException)
            : base(message, innerException)
        {
            Code = CODE;
            DetailMessage = GetType().ToString();
        }

        #region IUIExceptionDetail Members

        public TypeThrow Type { get { return TypeThrow.Information; } }
        public String Code { get; protected set; }
        public String DetailMessage { get; protected set; }

        #endregion
    }
}
