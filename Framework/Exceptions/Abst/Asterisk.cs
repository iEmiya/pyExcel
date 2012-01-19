using System;

namespace pyExcel.Framework.Exceptions
{
    /// <summary>
    /// Сообщение "Сноска"
    /// </summary>
    public abstract class Asterisk : Exception, IUIExceptionDetail
    {
        private const String CODE = "799mVhNBYUaqMENyR40Blw";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected Asterisk(String message, Exception innerException)
            : base(message, innerException)
        {
            Code = CODE;
            DetailMessage = GetType().ToString();
        }

        #region IUIExceptionDetail Members

        public TypeThrow Type { get { return TypeThrow.Asterisk; } }
        public String Code { get; protected set; }
        public String DetailMessage { get; protected set; }

        #endregion
    }
}
