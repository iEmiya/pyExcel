using System;

namespace pyExcel.Framework.Exceptions
{
    /// <summary>
    /// Сообщение "Восклицание"
    /// </summary>
    public abstract class Exclamation : Exception, IUIExceptionDetail
    {
        private const String CODE = "elnPSGXSAEy67D_v8ZfFVw";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected Exclamation(String message, Exception innerException)
            : base(message, innerException)
        {
            Code = CODE;
            DetailMessage = GetType().ToString();
        }

        #region IUIExceptionDetail Members

        public TypeThrow Type { get { return TypeThrow.Exclamation; } }
        public String Code { get; protected set; }
        public String DetailMessage { get; protected set; }

        #endregion
    }
}
