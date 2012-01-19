using System;
using System.Data;

namespace pyExcel.Framework
{
    /// <summary>
    /// Отображение
    /// </summary>
    public interface IMainView
    {
        /// <summary>
        /// Можно ли использовать клавишу "Run"
        /// </summary>
        /// <param name="isCan"></param>
        void SetCanRun(bool isCan);
        /// <summary>
        /// Можно ли использовать клавишу "Stop"
        /// </summary>
        /// <param name="isCan"></param>
        void SetCanStop(bool isCan);
        /// <summary>
        /// Можно ли задавать файлы Python и Excel
        /// </summary>
        /// <param name="isCan"></param>
        void SetSetSources(bool isCan);
        /// <summary>
        /// Можно ли использовать клавишу "Export"
        /// </summary>
        /// <param name="isCan"></param>
        void CanExport(bool isCan);

        /// <summary>
        /// Показать ошибку
        /// </summary>
        /// <param name="ex"></param>
        void ViewException(Exception ex);
        /// <summary>
        /// Показать сообщение
        /// </summary>
        /// <param name="ex"></param>
        void ViewMessage(Exception ex);


        /// <summary>
        /// Показать содержимое скрипта Python
        /// </summary>
        /// <param name="html"></param>
        void SetPythonScript(string html);
        /// <summary>
        /// Показать содержимое Excel файла
        /// </summary>
        /// <param name="dataTable"></param>
        void SetBeforeDataTable(DataTable dataTable);
        /// <summary>
        /// Показать результат выполенения скрипта
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="selectTab"></param>
        void SetAfterDataTable(DataTable dataTable, bool selectTab);

        /// <summary>
        /// Задать количество строк
        /// </summary>
        /// <param name="maximum"></param>
        void SetConvertMaximum(int maximum);
        /// <summary>
        /// Задать номер текущей обрабатываемой строки
        /// </summary>
        /// <param name="value"></param>
        void SetConvertValue(int value);
    }
}
