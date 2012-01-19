using System;

namespace pyExcel.Framework.Exceptions
{
    /// <summary>
    /// Сообщение "Ошибка"
    /// </summary>
    public abstract class Error : Exception, IUIExceptionDetail
    {
        private const String CODE = "_HZj12jCrkKR_BkLtGcYFA";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected Error(String message, Exception innerException)
            : base(message, innerException)
        {
            Code = CODE;
            DetailMessage = GetType().ToString();
        }

        #region IUIExceptionDetail Members

        public TypeThrow Type { get { return TypeThrow.Error; } }
        public String Code { get; protected set; }
        public String DetailMessage { get; protected set; }

        #endregion
    }
}
