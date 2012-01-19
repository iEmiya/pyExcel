using System;

namespace pyExcel.Framework
{
    /// <summary>
    /// Тип возникающих сообщений при ошибке
    /// </summary>
    [Serializable] 
    public enum TypeThrow
    {
        /// <summary>
        /// Ошибка
        /// </summary>
        Error = 1,
        /// <summary>
        /// Прекращение
        /// </summary>
        Stop = 2,
        /// <summary>
        /// Восклицание
        /// </summary>
        Exclamation = 3,
        /// <summary>
        /// Предупреждение
        /// </summary>
        Warning = 4,
        /// <summary>
        /// Сноска
        /// </summary>
        Asterisk = 5,
        /// <summary>
        /// Информация
        /// </summary>
        Information = 6,
    }
}
