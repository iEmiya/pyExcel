using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    public static class MainPresenterHelper
    {
        public const string ColumnSystemNumName = "5DYe7mGYSkW5bsgu6ygPeA";

        /// <summary>
        /// Добавляем номера строк для загруженного файла
        /// </summary>
        /// <param name="table"></param>
        public static void AddNumColumn(DataTable table)
        {
            table.Columns.Add(new DataColumn(ColumnSystemNumName, typeof(int)));
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                row[ColumnSystemNumName] = i++;
            }
        }
    }

    /// <summary>
    /// Представление
    /// </summary>
    public sealed class MainPresenter
    {
        private readonly IMainView _view;
        private string _pythonFileName;
        private string _excelFileName;
        private bool _isRowSelection;
        private bool _checkExcelColumnsType;
        private List<int> _dataRowNumCollection;
        private bool _isRunning;

        private readonly ProviderFilter _viewFilter;
        private readonly ProviderFilter _workFilter;

        private readonly IProvider _viewProvider;
        private readonly IProvider _workProvider;

        private readonly PythonHelper _parser;
        private readonly ExportHelper _export;

        private DataTable _dataTable;
        private Thread _thread;
        private DataTable _result;

        /// <summary>
        /// Создать представление
        /// </summary>
        /// <param name="view"></param>
        public MainPresenter(IMainView view)
        {
            _view = view;

            _pythonFileName = string.Empty;
            _excelFileName = string.Empty;
            _isRowSelection = false;
            _checkExcelColumnsType = false;
            _dataRowNumCollection = null;

            _isRunning = false;

            _viewFilter = new ProviderFilter();
            _workFilter = new ProviderFilter();

            _viewProvider = new NPOIProvider(_viewFilter);
            _workProvider = new NPOIProvider(_workFilter);


            _parser = new PythonHelper();
            _export = new ExportHelper();

            _thread = null;
            _result = null;
        }

        /// <summary>
        /// Запущен ли процес конвертации данных
        /// </summary>
        public bool IsRunnung { get { return _isRunning; } }
        /// <summary>
        /// Необходимо ли выделять ячейки
        /// </summary>
        public bool IsRowSelection { get { return _isRowSelection; } }
        /// <summary>
        /// Список выделенных строк
        /// </summary>
        public List<int> ExcelRowNumCollection { get { return _dataRowNumCollection; } }


        /// <summary>
        /// Загрузить представление
        /// </summary>
        public void Load()
        {
            SetViewState();
        }

        /// <summary>
        /// Закрыть представление
        /// </summary>
        /// <returns>false = если необходимо остановить закрытие отображения</returns>
        public bool Closing()
        {
            ConvertStop();
            return true;
        }

        /// <summary>
        /// Задать название Python файла
        /// </summary>
        /// <param name="fileName"></param>
        public void SetPythonFileName(string fileName)
        {
            if (!IsNotConvertRunning()) return;

            string html;
            try
            {
                html = _parser.ToHtml(fileName);
            }
            catch (Exception ex)
            {
                _view.ViewException(ex);
                return;
            }

            _view.SetPythonScript(html);

            _result = null;
            _view.SetAfterDataTable(_result, false);

            _pythonFileName = fileName;

            SetCanRun();
            CanExport();
        }

        /// <summary>
        /// Задать название Excel файла
        /// </summary>
        /// <param name="fileName"></param>
        public void SetExcelFileName(string fileName)
        {
            if (!IsNotConvertRunning()) return;

            _dataTable = null;
            try
            {
                _viewFilter.FileName = fileName;
                _dataTable = _viewProvider.GetSource();
            }
            catch (Exception ex)
            {
                _view.ViewException(ex);
                return;
            }
            MainPresenterHelper.AddNumColumn(_dataTable);

            _view.SetBeforeDataTable(_dataTable);

            _result = null;
            _view.SetAfterDataTable(_result, false);

            _excelFileName = fileName;

            SetCanRun();
            CanExport();
        }

        /// <summary>
        /// Задать возможность указания строк для обработки
        /// </summary>
        /// <param name="isCheck"></param>
        public void SetRowExcelSelection(bool isCheck)
        {
            if (!IsNotConvertRunning()) return;

            _result = null;
            _view.SetAfterDataTable(_result, false);

            _isRowSelection = isCheck;

            SetCanRun();
            CanExport();
        }

        /// <summary>
        /// Задать проверку типов для колонок Excel файла
        /// </summary>
        /// <param name="isCheck"></param>
        public void SetCheckExcelColumnsType(bool isCheck)
        {
            if (!IsNotConvertRunning()) return;

            _result = null;
            _view.SetAfterDataTable(_result, false);

            _checkExcelColumnsType = isCheck;

            SetCanRun();
            CanExport();
        }

        /// <summary>
        /// Задать номера строк из Excel для обработки
        /// </summary>
        /// <param name="collection"></param>
        public void SetExcelRowNumCollection(List<int> collection)
        {
            if (!IsNotConvertRunning()) return;

            _result = null;
            _view.SetAfterDataTable(_result, false);

            _dataRowNumCollection = collection;

            SetCanRun();
            CanExport();
        }

        /// <summary>
        /// Начать выполнение скрипта
        /// </summary>
        public void ConvertRun()
        {
            if (!IsNotConvertRunning()) return;

            try
            {
                _workFilter.FileName = _excelFileName;
                _workFilter.SetColumnType = _checkExcelColumnsType;

                if (_isRowSelection)
                {
                    _workFilter.DataRowNumCollection = _dataRowNumCollection;
                }
                else
                {
                    _workFilter.DataRowNumCollection = null;
                }

                _thread = new Thread(Convert);
                _thread.IsBackground = true;
                _thread.Start();

                _isRunning = true;
            }
            catch (Exception e)
            {
                var ex = new ThreadConvertRunException(e);
                _view.ViewException(ex);
            }

            SetViewState();
        }

        /// <summary>
        /// Остановить выполнение скрипта 
        /// </summary>
        public void ConvertStop()
        {
            if (!_isRunning) return;

            if ((_thread != null) && (_thread.ThreadState != ThreadState.Stopped))
            {
                try
                {
                    _thread.Abort();
                    _thread.Join();
                }
                catch (Exception e)
                {
                    var ex = new ThreadConvertStopException(e);
                    _view.ViewException(ex);
                }
                
                _thread = null;
            }
            ConvertStopInternal();
        }

        /// <summary>
        /// Экспорт в Excel
        /// </summary>
        /// <param name="fileName"></param>
        public void Export(string fileName)
        {
            try
            {
                _export.Export(_result, fileName);
            }
            catch (Exception e)
            {
                var ex = new ExcelExportException(e);
                _view.ViewException(ex);
            }
        }

        private void ConvertStopInternal()
        {
            _isRunning = false;
            SetViewState();
        }

        private void SetViewState()
        {
            SetCanRun();
            SetSetSources();
            SetCanStop();
            CanExport();
        }

        private bool IsNotConvertRunning()
        {
            if (_isRunning)
            {
                var ex = new ConvertIsRunningException();
                _view.ViewException(ex);
                return false;
            }
            return true;
        }

        private void SetCanRun()
        {
            bool isCan = false;

            if (!_isRunning)
            {


                bool pythonFileNameIsExists = false;
                if (!string.IsNullOrEmpty(_pythonFileName))
                {
                    var fi = new FileInfo(_pythonFileName);
                    if (fi.Exists) pythonFileNameIsExists = true;
                }

                bool excelFileNameIsExists = false;
                if (!string.IsNullOrEmpty(_excelFileName))
                {
                    var fi = new FileInfo(_excelFileName);
                    if (fi.Exists) excelFileNameIsExists = true;
                }

                if (pythonFileNameIsExists && excelFileNameIsExists) isCan = true;
            }

            _view.SetCanRun(isCan);
        }

        private void SetCanStop()
        {
            _view.SetCanStop(_isRunning);
        }

        private void SetSetSources()
        {
            _view.SetSetSources(!_isRunning);
        }

        private void CanExport()
        {
            _view.CanExport(_result != null);
        }

        private void Convert()
        {
            WorkerThead();
            ConvertStopInternal();
        }

        private void WorkerThead()
        {
            Worker worker = new Worker(_viewProvider, _workProvider, _pythonFileName);
            worker.DataTableBefore += new SetDataTableBefore(worker_DataTableBefore);
            worker.DataTableAfter += new SetDataTableAfter(worker_DataTableAfter);
            worker.ConvertMaximum += new SetConvertMaximum(worker_ConvertMaximum);
            worker.ConvertValue += new SetConvertValue(worker_ConvertValue);

            try
            {
                worker.Do();
            }
            catch (Exception ex)
            {
                _view.ViewException(ex);
            }
        }

        private void worker_DataTableBefore(DataTable dataTable)
        {
            _view.SetBeforeDataTable(dataTable);
        }

        private void worker_DataTableAfter(DataTable dataTable)
        {
            _result = dataTable;
            _view.SetAfterDataTable(_result, true);
        }

        private void worker_ConvertMaximum(int maximum)
        {
            _view.SetConvertMaximum(maximum);
        }

        private void worker_ConvertValue(int value)
        {
            _view.SetConvertValue(value);
        }
    }

    internal sealed class ThreadConvertRunException : Exceptions.Error
    {
        private const string CODE = "9MAQmUcIB0ysTrBzsDKPsQ";

        public ThreadConvertRunException(Exception e)
            : base(Resource.ThreadConvertRunException, e)
        {
            Code = CODE;

            var msg = new StringBuilder();
            Exception ex = e;
            while (ex != null)
            {
                msg.AppendLine(ex.ToString());
                ex = ex.InnerException;
            }

            DetailMessage = string.Format(Resource.ThreadConvertRunExceptionDetailMessagePattern, msg);
        }
    }

    internal sealed class ThreadConvertStopException : Exceptions.Error
    {
        private const string CODE = "LE1128loLkKNRa8MP_eG0w";

        public ThreadConvertStopException(Exception e)
            : base(Resource.ThreadConvertStopException, e)
        {
            Code = CODE;

            var msg = new StringBuilder();
            Exception ex = e;
            while (ex != null)
            {
                msg.AppendLine(ex.ToString());
                ex = ex.InnerException;
            }

            DetailMessage = string.Format(Resource.ThreadConvertStopExceptionDetailMessagePattern, msg);
        }
    }

    internal sealed class ExcelExportException : Exceptions.Error
    {
        private const string CODE = "_MXdfPwHjkqUzP0BRh5jAg";

        public ExcelExportException(Exception e)
            : base(Resource.ExcelExportException, e)
        {
            Code = CODE;

            var msg = new StringBuilder();
            Exception ex = e;
            while (ex != null)
            {
                msg.AppendLine(ex.ToString());
                ex = ex.InnerException;
            }

            DetailMessage = string.Format(Resource.ExcelExportExceptionDetailMessagePattern, msg);
        }
    }

    internal sealed class ConvertIsRunningException : Exceptions.Stop
    {
        private const string CODE = "6pHl4xf8S0KgFW56hmXFfA";

        public ConvertIsRunningException()
            : base(Resource.ConvertIsRunningExceptionException, null)
        {
            Code = CODE;
            DetailMessage = string.Empty;
        }
    }
}
