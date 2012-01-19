using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using pyExcel.Framework;

namespace pyExcel.WinApp
{
    internal partial class Main : Form, IMainView
    {
        private readonly MainPresenter _presenter;
        private readonly WaitHelper _waitHelper;

        public Main()
        {
            InitializeComponent();

            this.openFilePythonDialog.Filter = Properties.Resources.OpenFilePythonDialofFilter;
            this.openFileExcelDialog.Filter = Properties.Resources.OpenFileExcelDialofFilter;
            this.saveFileExcelDialog.Filter = Properties.Resources.SaveFileExcelDialofFilter;

            this.tbPython.Text = Properties.Resources.PythonTabName;
            this.tbBefore.Text = Properties.Resources.SourceTabName;
            this.tpAfter.Text = Properties.Resources.ResultTabName;

            this.bRun.Text = Properties.Resources.RunButton;
            this.bStop.Text = Properties.Resources.StopButton;
            this.bExport.Text = Properties.Resources.ExportButton;

            this.cbSetRowSelection.Text = Properties.Resources.SetRowSelection;
            this.cbSetCheckExcelColumnsType.Text = Properties.Resources.SetCheckExcelColumnsType;

            this.bReloadPython.Enabled = false;
            this.bReloadExcel.Enabled = false;

            _presenter = new MainPresenter(this);
            _waitHelper = new WaitHelper(this);
        }


        public void SetCanRun(bool isCan)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetCanRun), new object[] { isCan });
                return;
            }
            this.bRun.Enabled = isCan;
        }

        public void SetCanStop(bool isCan)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetCanStop), new object[] { isCan });
                return;
            }
            this.bStop.Enabled = isCan;
        }

        public void SetSetSources(bool isCan)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetSetSources), new object[] { isCan });
                return;
            }
            this.bOpenPython.Enabled = isCan;
            this.bOpenExcel.Enabled = isCan;
            this.pbConvert.Visible = !isCan;
        }

        public void CanExport(bool isCan)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(CanExport), new object[] { isCan });
                return;
            }

            this.bExport.Enabled = isCan;
        }

        public void ViewException(Exception ex)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Exception>(ViewException), new object[] { ex });
                return;
            }

            ExceptionHelper.Show(this, ex);
        }

        public void ViewMessage(Exception ex)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Exception>(ViewMessage), new object[] { ex });
                return;
            }

            ExceptionHelper.Show(this, ex);
        }

        public void SetPythonScript(string html)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetPythonScript), new object[] { html });
                return;
            }

            wbPython.DocumentText = html;
            tcSource.SelectTab(tbPython);
        }

        public void SetBeforeDataTable(System.Data.DataTable dataTable)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<System.Data.DataTable>(SetBeforeDataTable), new object[] { dataTable });
                return;
            }

            dgvBefore.DataSource = dataTable;

            this.dgvBefore.SelectionChanged -= new System.EventHandler(this.dgvBefore_SelectionChanged);
            tcSource.SelectTab(tbBefore);
            SelectedRows();
            this.dgvBefore.SelectionChanged += new System.EventHandler(this.dgvBefore_SelectionChanged);
        }

        public void SetAfterDataTable(System.Data.DataTable dataTable, bool selectTab)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<System.Data.DataTable, bool>(SetAfterDataTable), new object[] { dataTable, selectTab });
                return;
            }

            dgvAfter.DataSource = dataTable;
            if (selectTab)
                tcSource.SelectTab(tpAfter);
        }

        public void SetConvertMaximum(int maximum)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetConvertMaximum), new object[] { maximum });
                return;
            }

            pbConvert.Minimum = 0;
            pbConvert.Maximum = maximum;
            pbConvert.Value = 0;
        }

        public void SetConvertValue(int value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetConvertValue), new object[] { value });
                return;
            }

            pbConvert.Value = value;
        }

        #region Main_Load

        private void Main_Load(object sender, System.EventArgs e)
        {
            _presenter.Load();

            SetCaption();
            SetRowSelection();
            SetColumnType();
            SetPythonFileName();
            SetExcelFileName();

            this.dgvBefore.SelectionChanged += new System.EventHandler(this.dgvBefore_SelectionChanged);
        }

        private void SetCaption()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text += string.Format(" # {0}", fvi.FileVersion);
        }

        private void SetPythonFileName()
        {
            tbPythonFileName.Text = Properties.Settings.Default.PythonFileName;
        }

        private void SetExcelFileName()
        {
            tbExcelFileName.Text = Properties.Settings.Default.ExcelFileName;
        }

        private void SetRowSelection()
        {
            string obj = Properties.Settings.Default.ExcelRowNumCollection;
            if (!string.IsNullOrEmpty(obj))
            {
                List<int> collection = obj.Deserialize<List<int>>();
                _presenter.SetExcelRowNumCollection(collection);
            }
            cbSetRowSelection.Checked = Properties.Settings.Default.SetRowSelection;
        }

        private void SetColumnType()
        {
            cbSetCheckExcelColumnsType.Checked = Properties.Settings.Default.SetColumnType;
        }

        #endregion
        #region Main_FormClosing
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_presenter.Closing();
        }
        #endregion

        private void SelectedRows()
        {
            if (dgvBefore.DataSource == null) return;
            dgvBefore.ClearSelection();

            DataGridViewColumn column = dgvBefore.Columns[MainPresenterHelper.ColumnSystemNumName];
            if (column == null) return;

            column.Visible = false;

            if (!_presenter.IsRowSelection) return;

            List<int> excelRowNumCollection = _presenter.ExcelRowNumCollection;
            if (excelRowNumCollection == null) return;
            List<int> collection = new List<int>(excelRowNumCollection);

            foreach (DataGridViewRow row in dgvBefore.Rows)
            {
                DataGridViewCell cell = row.Cells[MainPresenterHelper.ColumnSystemNumName];
                int no = (int)cell.Value;
                if (collection.Contains(no))
                    row.Selected = true;
            }
        }

        private void bOpenPython_Click(object sender, System.EventArgs e)
        {
            if (openFilePythonDialog.ShowDialog() != DialogResult.OK) return;

            var fileName = openFilePythonDialog.FileName;
            tbPythonFileName.Text = fileName;
        }

        private void bReloadPython_Click(object sender, EventArgs e)
        {
            tbPythonFileName_TextChanged(sender, e);
        }

        private void tbPythonFileName_TextChanged(object sender, EventArgs e)
        {
            var fileName = tbPythonFileName.Text;
            Properties.Settings.Default.PythonFileName = fileName;
            this.bReloadPython.Enabled = !string.IsNullOrEmpty(fileName);

            this.Enabled = false;
            bwSetPythonFileName.RunWorkerAsync(fileName);
        }

        private void bwSetPythonFileName_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _waitHelper.Show();
            string fileName = e.Argument as string;
            _presenter.SetPythonFileName(fileName);
        }

        private void bwSetPythonFileName_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _waitHelper.Close();
            this.Enabled = true;
        }

        private void bOpenExcel_Click(object sender, System.EventArgs e)
        {
            if (openFileExcelDialog.ShowDialog() != DialogResult.OK) return;

            var fileName = openFileExcelDialog.FileName;
            tbExcelFileName.Text = fileName;
        }

        private void bReloadExcel_Click(object sender, EventArgs e)
        {
            tbExcelFileName_TextChanged(sender, e);
        }

        private void tbExcelFileName_TextChanged(object sender, EventArgs e)
        {
            var fileName = tbExcelFileName.Text;
            Properties.Settings.Default.ExcelFileName = fileName;
            this.bReloadExcel.Enabled = !string.IsNullOrEmpty(tbExcelFileName.Text);

            this.Enabled = false;
            bwSetExcelFileName.RunWorkerAsync(fileName);
        }

        private void bwSetExcelFileName_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _waitHelper.Show();
            string fileName = e.Argument as string;
            _presenter.SetExcelFileName(fileName);
        }

        private void bwSetExcelFileName_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _waitHelper.Close();
            this.Enabled = true;
        }

        private void dgvBefore_SelectionChanged(object sender, EventArgs e)
        {
            if (_presenter.IsRunnung) return;
            if (dgvBefore.DataSource == null) return;
            if (dgvBefore.SelectedRows.Count < 0) return;

            if(!_presenter.IsRowSelection)
            {
                foreach (DataGridViewRow row in dgvBefore.SelectedRows)
                {
                    row.Selected = false;
                }
                return;
            }

            List<int> collection = new List<int>();
            foreach (DataGridViewRow row in dgvBefore.SelectedRows)
            {
                DataGridViewCell cell = row.Cells[MainPresenterHelper.ColumnSystemNumName];
                int no = (int)cell.Value;
                collection.Add(no);
            }
            Properties.Settings.Default.ExcelRowNumCollection = collection.Serialize();
            _presenter.SetExcelRowNumCollection(collection);
        }

        private void cbSetRowSelection_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = cbSetRowSelection.Checked;
            Properties.Settings.Default.SetRowSelection = @checked;
            _presenter.SetRowExcelSelection(@checked);

            this.dgvBefore.SelectionChanged += new System.EventHandler(this.dgvBefore_SelectionChanged);
            SelectedRows();
            this.dgvBefore.SelectionChanged -= new System.EventHandler(this.dgvBefore_SelectionChanged);
        }

        private void cbSetCheckExcelColumnsType_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = cbSetCheckExcelColumnsType.Checked;
            Properties.Settings.Default.SetColumnType = @checked;
            _presenter.SetCheckExcelColumnsType(@checked);
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            _presenter.ConvertRun();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            _presenter.ConvertStop();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            saveFileExcelDialog.FileName = Properties.Settings.Default.SaveExcelFileName;

            if (saveFileExcelDialog.ShowDialog() != DialogResult.OK) return;

            var fileName = saveFileExcelDialog.FileName;
            Properties.Settings.Default.SaveExcelFileName = fileName;
            this.Enabled = false;
            bwExport.RunWorkerAsync(fileName);
        }

        private void bwExport_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _waitHelper.Show();
            string fileName = e.Argument as string;
            _presenter.Export(fileName);
        }

        private void bwExport_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _waitHelper.Close();
            this.Enabled = true;
        }
    }
}
