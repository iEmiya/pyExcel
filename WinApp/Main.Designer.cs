namespace pyExcel.WinApp
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.bOpenPython = new System.Windows.Forms.Button();
            this.bOpenExcel = new System.Windows.Forms.Button();
            this.tbPythonFileName = new System.Windows.Forms.TextBox();
            this.tbExcelFileName = new System.Windows.Forms.TextBox();
            this.openFilePythonDialog = new System.Windows.Forms.OpenFileDialog();
            this.bRun = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.tcSource = new System.Windows.Forms.TabControl();
            this.tbPython = new System.Windows.Forms.TabPage();
            this.bReloadPython = new System.Windows.Forms.Button();
            this.wbPython = new System.Windows.Forms.WebBrowser();
            this.tbBefore = new System.Windows.Forms.TabPage();
            this.cbSetRowSelection = new System.Windows.Forms.CheckBox();
            this.cbSetCheckExcelColumnsType = new System.Windows.Forms.CheckBox();
            this.bReloadExcel = new System.Windows.Forms.Button();
            this.dgvBefore = new System.Windows.Forms.DataGridView();
            this.tpAfter = new System.Windows.Forms.TabPage();
            this.dgvAfter = new System.Windows.Forms.DataGridView();
            this.pbConvert = new System.Windows.Forms.ProgressBar();
            this.bExport = new System.Windows.Forms.Button();
            this.saveFileExcelDialog = new System.Windows.Forms.SaveFileDialog();
            this.bwSetPythonFileName = new System.ComponentModel.BackgroundWorker();
            this.bwSetExcelFileName = new System.ComponentModel.BackgroundWorker();
            this.bwExport = new System.ComponentModel.BackgroundWorker();
            this.tcSource.SuspendLayout();
            this.tbPython.SuspendLayout();
            this.tbBefore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBefore)).BeginInit();
            this.tpAfter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // bOpenPython
            // 
            this.bOpenPython.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenPython.Image = global::pyExcel.WinApp.Properties.Resources.Python;
            this.bOpenPython.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOpenPython.Location = new System.Drawing.Point(682, 12);
            this.bOpenPython.Name = "bOpenPython";
            this.bOpenPython.Size = new System.Drawing.Size(90, 23);
            this.bOpenPython.TabIndex = 1000;
            this.bOpenPython.Text = "Python";
            this.bOpenPython.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bOpenPython.UseVisualStyleBackColor = true;
            this.bOpenPython.Click += new System.EventHandler(this.bOpenPython_Click);
            // 
            // bOpenExcel
            // 
            this.bOpenExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenExcel.Image = global::pyExcel.WinApp.Properties.Resources.Excel;
            this.bOpenExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOpenExcel.Location = new System.Drawing.Point(682, 43);
            this.bOpenExcel.Name = "bOpenExcel";
            this.bOpenExcel.Size = new System.Drawing.Size(90, 23);
            this.bOpenExcel.TabIndex = 1010;
            this.bOpenExcel.Text = "Excel";
            this.bOpenExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bOpenExcel.UseVisualStyleBackColor = true;
            this.bOpenExcel.Click += new System.EventHandler(this.bOpenExcel_Click);
            // 
            // tbPythonFileName
            // 
            this.tbPythonFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPythonFileName.Enabled = false;
            this.tbPythonFileName.Location = new System.Drawing.Point(12, 14);
            this.tbPythonFileName.Name = "tbPythonFileName";
            this.tbPythonFileName.ReadOnly = true;
            this.tbPythonFileName.Size = new System.Drawing.Size(664, 20);
            this.tbPythonFileName.TabIndex = 2000;
            this.tbPythonFileName.TextChanged += new System.EventHandler(this.tbPythonFileName_TextChanged);
            // 
            // tbExcelFileName
            // 
            this.tbExcelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExcelFileName.Enabled = false;
            this.tbExcelFileName.Location = new System.Drawing.Point(12, 45);
            this.tbExcelFileName.Name = "tbExcelFileName";
            this.tbExcelFileName.ReadOnly = true;
            this.tbExcelFileName.Size = new System.Drawing.Size(664, 20);
            this.tbExcelFileName.TabIndex = 2010;
            this.tbExcelFileName.TextChanged += new System.EventHandler(this.tbExcelFileName_TextChanged);
            // 
            // bRun
            // 
            this.bRun.Image = global::pyExcel.WinApp.Properties.Resources.Run;
            this.bRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bRun.Location = new System.Drawing.Point(12, 72);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(90, 23);
            this.bRun.TabIndex = 3000;
            this.bRun.Text = "Run";
            this.bRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.Image = global::pyExcel.WinApp.Properties.Resources.Cancel;
            this.bStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bStop.Location = new System.Drawing.Point(586, 71);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(90, 23);
            this.bStop.TabIndex = 3010;
            this.bStop.Text = "Stop";
            this.bStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // tcSource
            // 
            this.tcSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSource.Controls.Add(this.tbPython);
            this.tcSource.Controls.Add(this.tbBefore);
            this.tcSource.Controls.Add(this.tpAfter);
            this.tcSource.Location = new System.Drawing.Point(-1, 101);
            this.tcSource.Name = "tcSource";
            this.tcSource.SelectedIndex = 0;
            this.tcSource.Size = new System.Drawing.Size(788, 462);
            this.tcSource.TabIndex = 4000;
            // 
            // tbPython
            // 
            this.tbPython.Controls.Add(this.bReloadPython);
            this.tbPython.Controls.Add(this.wbPython);
            this.tbPython.Location = new System.Drawing.Point(4, 22);
            this.tbPython.Name = "tbPython";
            this.tbPython.Padding = new System.Windows.Forms.Padding(3);
            this.tbPython.Size = new System.Drawing.Size(780, 436);
            this.tbPython.TabIndex = 2;
            this.tbPython.Text = "Python";
            this.tbPython.UseVisualStyleBackColor = true;
            // 
            // bReloadPython
            // 
            this.bReloadPython.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bReloadPython.Image = global::pyExcel.WinApp.Properties.Resources.Reload;
            this.bReloadPython.Location = new System.Drawing.Point(9, 358);
            this.bReloadPython.Name = "bReloadPython";
            this.bReloadPython.Size = new System.Drawing.Size(69, 69);
            this.bReloadPython.TabIndex = 900;
            this.bReloadPython.UseVisualStyleBackColor = true;
            this.bReloadPython.Click += new System.EventHandler(this.bReloadPython_Click);
            // 
            // wbPython
            // 
            this.wbPython.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPython.Location = new System.Drawing.Point(3, 3);
            this.wbPython.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPython.Name = "wbPython";
            this.wbPython.Size = new System.Drawing.Size(774, 430);
            this.wbPython.TabIndex = 0;
            // 
            // tbBefore
            // 
            this.tbBefore.Controls.Add(this.cbSetRowSelection);
            this.tbBefore.Controls.Add(this.cbSetCheckExcelColumnsType);
            this.tbBefore.Controls.Add(this.bReloadExcel);
            this.tbBefore.Controls.Add(this.dgvBefore);
            this.tbBefore.Location = new System.Drawing.Point(4, 22);
            this.tbBefore.Name = "tbBefore";
            this.tbBefore.Padding = new System.Windows.Forms.Padding(3);
            this.tbBefore.Size = new System.Drawing.Size(780, 436);
            this.tbBefore.TabIndex = 0;
            this.tbBefore.Text = "Before";
            this.tbBefore.UseVisualStyleBackColor = true;
            // 
            // cbSetRowSelection
            // 
            this.cbSetRowSelection.AutoSize = true;
            this.cbSetRowSelection.Location = new System.Drawing.Point(3, 6);
            this.cbSetRowSelection.Name = "cbSetRowSelection";
            this.cbSetRowSelection.Size = new System.Drawing.Size(107, 17);
            this.cbSetRowSelection.TabIndex = 6100;
            this.cbSetRowSelection.Text = "Set row selection";
            this.cbSetRowSelection.UseVisualStyleBackColor = true;
            this.cbSetRowSelection.CheckedChanged += new System.EventHandler(this.cbSetRowSelection_CheckedChanged);
            // 
            // cbSetCheckExcelColumnsType
            // 
            this.cbSetCheckExcelColumnsType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSetCheckExcelColumnsType.AutoSize = true;
            this.cbSetCheckExcelColumnsType.Location = new System.Drawing.Point(637, 6);
            this.cbSetCheckExcelColumnsType.Name = "cbSetCheckExcelColumnsType";
            this.cbSetCheckExcelColumnsType.Size = new System.Drawing.Size(140, 17);
            this.cbSetCheckExcelColumnsType.TabIndex = 6100;
            this.cbSetCheckExcelColumnsType.Text = "Set check columns type";
            this.cbSetCheckExcelColumnsType.UseVisualStyleBackColor = true;
            this.cbSetCheckExcelColumnsType.CheckedChanged += new System.EventHandler(this.cbSetCheckExcelColumnsType_CheckedChanged);
            // 
            // bReloadExcel
            // 
            this.bReloadExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bReloadExcel.Image = global::pyExcel.WinApp.Properties.Resources.Reload;
            this.bReloadExcel.Location = new System.Drawing.Point(9, 358);
            this.bReloadExcel.Name = "bReloadExcel";
            this.bReloadExcel.Size = new System.Drawing.Size(69, 69);
            this.bReloadExcel.TabIndex = 910;
            this.bReloadExcel.UseVisualStyleBackColor = true;
            this.bReloadExcel.Click += new System.EventHandler(this.bReloadExcel_Click);
            // 
            // dgvBefore
            // 
            this.dgvBefore.AllowUserToAddRows = false;
            this.dgvBefore.AllowUserToDeleteRows = false;
            this.dgvBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBefore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBefore.Location = new System.Drawing.Point(3, 29);
            this.dgvBefore.Name = "dgvBefore";
            this.dgvBefore.ReadOnly = true;
            this.dgvBefore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBefore.Size = new System.Drawing.Size(774, 407);
            this.dgvBefore.TabIndex = 0;
            // 
            // tpAfter
            // 
            this.tpAfter.Controls.Add(this.dgvAfter);
            this.tpAfter.Location = new System.Drawing.Point(4, 22);
            this.tpAfter.Name = "tpAfter";
            this.tpAfter.Padding = new System.Windows.Forms.Padding(3);
            this.tpAfter.Size = new System.Drawing.Size(780, 436);
            this.tpAfter.TabIndex = 1;
            this.tpAfter.Text = "After";
            this.tpAfter.UseVisualStyleBackColor = true;
            // 
            // dgvAfter
            // 
            this.dgvAfter.AllowUserToAddRows = false;
            this.dgvAfter.AllowUserToDeleteRows = false;
            this.dgvAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAfter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfter.Location = new System.Drawing.Point(3, 29);
            this.dgvAfter.Name = "dgvAfter";
            this.dgvAfter.ReadOnly = true;
            this.dgvAfter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAfter.Size = new System.Drawing.Size(774, 407);
            this.dgvAfter.TabIndex = 0;
            // 
            // pbConvert
            // 
            this.pbConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbConvert.Location = new System.Drawing.Point(108, 72);
            this.pbConvert.Name = "pbConvert";
            this.pbConvert.Size = new System.Drawing.Size(472, 10);
            this.pbConvert.TabIndex = 4010;
            this.pbConvert.Visible = false;
            // 
            // bExport
            // 
            this.bExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bExport.Image = global::pyExcel.WinApp.Properties.Resources.Export;
            this.bExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bExport.Location = new System.Drawing.Point(682, 72);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(90, 23);
            this.bExport.TabIndex = 3010;
            this.bExport.Text = "Export";
            this.bExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // bwSetPythonFileName
            // 
            this.bwSetPythonFileName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSetPythonFileName_DoWork);
            this.bwSetPythonFileName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSetPythonFileName_RunWorkerCompleted);
            // 
            // bwSetExcelFileName
            // 
            this.bwSetExcelFileName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSetExcelFileName_DoWork);
            this.bwSetExcelFileName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSetExcelFileName_RunWorkerCompleted);
            // 
            // bwExport
            // 
            this.bwExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwExport_DoWork);
            this.bwExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwExport_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pbConvert);
            this.Controls.Add(this.tbPythonFileName);
            this.Controls.Add(this.bOpenPython);
            this.Controls.Add(this.tbExcelFileName);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bOpenExcel);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.tcSource);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Pyton in Excel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tcSource.ResumeLayout(false);
            this.tbPython.ResumeLayout(false);
            this.tbBefore.ResumeLayout(false);
            this.tbBefore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBefore)).EndInit();
            this.tpAfter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileExcelDialog;
        private System.Windows.Forms.Button bOpenPython;
        private System.Windows.Forms.Button bOpenExcel;
        private System.Windows.Forms.TextBox tbPythonFileName;
        private System.Windows.Forms.TextBox tbExcelFileName;
        private System.Windows.Forms.OpenFileDialog openFilePythonDialog;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.TabControl tcSource;
        private System.Windows.Forms.TabPage tbBefore;
        private System.Windows.Forms.TabPage tpAfter;
        private System.Windows.Forms.DataGridView dgvBefore;
        private System.Windows.Forms.DataGridView dgvAfter;
        private System.Windows.Forms.TabPage tbPython;
        private System.Windows.Forms.WebBrowser wbPython;
        private System.Windows.Forms.ProgressBar pbConvert;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.SaveFileDialog saveFileExcelDialog;
        private System.ComponentModel.BackgroundWorker bwSetPythonFileName;
        private System.ComponentModel.BackgroundWorker bwSetExcelFileName;
        private System.Windows.Forms.Button bReloadExcel;
        private System.Windows.Forms.Button bReloadPython;
        private System.ComponentModel.BackgroundWorker bwExport;
        private System.Windows.Forms.CheckBox cbSetCheckExcelColumnsType;
        private System.Windows.Forms.CheckBox cbSetRowSelection;
    }
}

