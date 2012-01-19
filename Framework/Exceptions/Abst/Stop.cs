using System;

namespace pyExcel.Framework.Exceptions
{
    /// <summary>
    /// Сообщение "Прекращение"
    /// </summary>
    public abstract class Stop : Exception, IUIExceptionDetail
    {
        private const String CODE = "INIHudiMXkmf074tJYx11A";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected Stop(String message, Exception innerException)
            : base(message, innerException)
        {
            Code = CODE;
            DetailMessage = GetType().ToString();
        }

        #region IUIExceptionDetail Members

        public TypeThrow Type { get { return TypeThrow.Stop; } }
        public String Code { get; protected set; }
        public String DetailMessage { get; protected set; }

        #endregion
    }
}
