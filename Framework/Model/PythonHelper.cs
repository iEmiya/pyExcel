using System;
using System.IO;
using pyExcel.Framework.Properties;

namespace pyExcel.Framework
{
    /// <summary>
    /// Отображение Python в HTML через SyntaxHighlighter
    /// </summary>
    internal sealed class PythonHelper
    {
        /// <summary>
        /// Преобразовать Python файл в HTML
        /// </summary>
        /// <param name="pythonFileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public string ToHtml(string pythonFileName)
        {
            bool pythonFileNameIsExists = false;
            if (!string.IsNullOrEmpty(pythonFileName))
            {
                var fi = new FileInfo(pythonFileName);
                if (fi.Exists) pythonFileNameIsExists = true;
            }

            if (!pythonFileNameIsExists)
                throw new FileNotFoundException(pythonFileName);

            string pythonSource = string.Empty;
            using(StreamReader streamReader = new StreamReader(pythonFileName))
            {
                pythonSource = streamReader.ReadToEnd();
                streamReader.Close();
            }

            string template = Resource.html_template;

            template = template.Replace("##PythonFileName##", pythonFileName);

            template = template.Replace("##XRegExp.js##", Resource.js_XRegExp);
            template = template.Replace("##shCore.js##", Resource.js_shCore);
            template = template.Replace("##shBrushJScript.js##", Resource.js_shBrushJScript);
            template = template.Replace("##shBrushPython.js##", Resource.js_shBrushPython);

            template = template.Replace("##shCore.css##", Resource.css_shCore);
            template = template.Replace("##shThemeDefault.css##", Resource.css_shThemeDefault);

            template = template.Replace("##PythonSource##", pythonSource);

            return template;
        }
    }
}
