using System;
using System.Collections.Generic;
using System.Data;
using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    /// <summary>
    /// Фильтр
    /// </summary>
    public sealed class ProviderFilter
    {
        /// <summary>
        /// Название Excel файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Название листа в Excel файле
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// Использовать первую строчку, как заголовок
        /// </summary>
        public bool FirstRowIsTheHeader { get; set; }
        /// <summary>
        /// Задать тип колонок
        /// </summary>
        public bool SetColumnType { get; set; }

        /// <summary>
        /// Список строк, используемых для создания источника данных
        /// </summary>
        public List<int> DataRowNumCollection { get; set; }

        /// <summary>
        /// Создать фильтр
        /// </summary>
        public ProviderFilter()
        {
            FileName = string.Empty;
            SheetName = Resource.SheetNameDefault;
            FirstRowIsTheHeader = false;
            SetColumnType = false;
        }
    }

    /// <summary>
    /// Получить данные из Excel файла
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Фильтр для получения данных
        /// </summary>
        ProviderFilter Filter { get; }

        /// <summary>
        /// Получить данные из Excel файла
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        DataTable GetSource();
    }
}
