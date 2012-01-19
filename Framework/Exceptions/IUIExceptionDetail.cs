namespace pyExcel.Framework
{
    /// <summary>
    /// Интерфейс для передачи информации о возникшей ошибке
    /// </summary>
    public interface IUIExceptionDetail
    {
        /// <summary>
        /// Тип
        /// </summary>
        TypeThrow Type { get; }

        /// <summary>
        /// Код сообщения
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Подробная информация о возникшей ошибке
        /// </summary>
        string DetailMessage { get; }
    }
}