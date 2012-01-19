using System;
using System.Data;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    /// <summary>
    /// Задать таблицу, полученную из Excel
    /// </summary>
    /// <param name="dataTable"></param>
    public delegate void SetDataTableBefore(DataTable dataTable);

    /// <summary>
    /// Задать таблицу, полученную после выполнения Python
    /// </summary>
    /// <param name="dataTable"></param>
    public delegate void SetDataTableAfter(DataTable dataTable);

    /// <summary>
    /// Задать количество строк, полученных их Excel файла
    /// </summary>
    /// <param name="maximum"></param>
    public delegate void SetConvertMaximum(int maximum);
    /// <summary>
    /// Задать номер текущей строки, обрабатываемый Python
    /// </summary>
    /// <param name="value"></param>
    public delegate void SetConvertValue(int value);

    /// <summary>
    /// Выполнить работу Python скрипта
    /// </summary>
    public sealed class Worker
    {
        private readonly string _pythonFileName;
        private readonly IProvider _viewProvider;
        private readonly IProvider _workProvider;

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="viewProvider"></param>
        /// <param name="workProvider"></param>
        /// <param name="pythonFileName"></param>
        public Worker(IProvider viewProvider, IProvider workProvider, string pythonFileName)
        {
            _pythonFileName = pythonFileName;
            _viewProvider = viewProvider;
            _workProvider = workProvider;
        }

        /// <summary>
        /// Событие: задать таблицу, полученную из Excel
        /// </summary>
        public event SetDataTableBefore DataTableBefore;
        /// <summary>
        /// Событие: задать таблицу, полученную после выполнения Python
        /// </summary>
        public event SetDataTableAfter DataTableAfter;


        /// <summary>
        /// Событие: задать количество строк, полученных их Excel файла
        /// </summary>
        public event SetConvertMaximum ConvertMaximum;
        /// <summary>
        /// Событие: задать номер текущей строки, обрабатываемый Python
        /// </summary>
        public event SetConvertValue ConvertValue;

        /// <summary>
        /// Выполнить
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="PythonCreateRuntimeException"></exception>
        /// <exception cref="ScriptRuntimeUseFileException"></exception>
        /// <exception cref="ScriptRunMethodException"></exception>
        public void Do()
        {
            DataTable dataTablBefore = GetTableBefore();
            OnSetDataTableBefore(dataTablBefore);

            DataTable dataTableAfter = GetTableAfter();

            ScriptRuntime p;
            try
            {
                p = Python.CreateRuntime();
            }
            catch (Exception e)
            {
                throw new PythonCreateRuntimeException(e);
            }

            dynamic script;
            try
            {
                script = p.UseFile(_pythonFileName);
            }
            catch (Exception e)
            {
                throw new ScriptRuntimeUseFileException(e);
            }

            try
            {
                script.Change(dataTableAfter);
            }
            catch (Exception e)
            {
                throw new ScriptRunMethodException("Change", e);
            }

            int no = 0;
            OnConvertMaximum(dataTableAfter.Rows.Count);
            foreach (DataRow row in dataTableAfter.Rows)
            {
                try
                {
                    script.ToCalculate(no, row);
                }
                catch (Exception e)
                {
                    throw new ScriptRunMethodException("ToCalculate", e);
                }

                ++no;
                OnSetConvertValue(no);
            }

            OnSetDataTableAfter(dataTableAfter);
        }

        private DataTable GetTableBefore()
        {
            DataTable table = _viewProvider.GetSource();
            MainPresenterHelper.AddNumColumn(table);
            return table;
        }

        private DataTable GetTableAfter()
        {
            return _workProvider.GetSource();
        }

        private void OnSetDataTableBefore(DataTable dataTable)
        {
            if (DataTableBefore != null)
                DataTableBefore(dataTable);
        }

        private void OnSetDataTableAfter(DataTable dataTable)
        {
            if (DataTableAfter != null)
                DataTableAfter(dataTable);
        }

        private void OnConvertMaximum(int maximum)
        {
            if (ConvertMaximum != null)
                ConvertMaximum(maximum);
        }

        private void OnSetConvertValue(int value)
        {
            if (ConvertValue != null)
                ConvertValue(value);
        }
    }

    internal sealed class PythonCreateRuntimeException : Exceptions.Stop
    {
        private const string CODE = "brQ01-3mz0KLn9m5eqAVPw";

        public PythonCreateRuntimeException(Exception e)
            : base(Resource.PythonCreateRuntimeException, e)
        {
            Code = CODE;
            DetailMessage = Resource.PythonCreateRuntimeExceptionDetailMessage;
        }
    }

    internal sealed class ScriptRuntimeUseFileException : Exceptions.Exclamation
    {
        private const string CODE = "AFYj8x9I9UmBWZuhb6bUAw";

        public ScriptRuntimeUseFileException(Exception e)
            : base(Resource.ScriptRuntimeUseFileException, e)
        {
            Code = CODE;
            DetailMessage = Resource.ScriptRuntimeUseFileExceptionDetailMessage;
        }
    }

    internal sealed class ScriptRunMethodException : Exceptions.Exclamation
    {
        private const string CODE = "AsjqrTvfJEmUQpXWcaoQ-A";

        public ScriptRunMethodException(string methodName, Exception e)
            : base(Resource.ScriptRunMethodException, e)
        {
            Code = CODE;

            var msg = new StringBuilder();
            Exception ex = e;
            while (ex != null)
            {
                msg.AppendLine(ex.ToString());
                ex = ex.InnerException;
            }
            DetailMessage = string.Format(Resource.ScriptRunMethodExceptionPattern, methodName, msg);
        }
    }
}
