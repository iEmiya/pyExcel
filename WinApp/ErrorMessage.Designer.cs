namespace pyExcel.WinApp
{
    partial class ErrorMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessage));
            this.Caption = new System.Windows.Forms.Label();
            this.DetailsContainer = new System.Windows.Forms.GroupBox();
            this.Details = new System.Windows.Forms.TextBox();
            this.Type = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.Label();
            this.lCode = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.DetailsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Caption
            // 
            this.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Caption.Location = new System.Drawing.Point(114, 12);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(268, 21);
            this.Caption.TabIndex = 1;
            this.Caption.Text = "Problem with Pyton in Excel";
            // 
            // DetailsContainer
            // 
            this.DetailsContainer.Controls.Add(this.Details);
            this.DetailsContainer.Controls.Add(this.Type);
            this.DetailsContainer.Controls.Add(this.lType);
            this.DetailsContainer.Controls.Add(this.Code);
            this.DetailsContainer.Controls.Add(this.lCode);
            this.DetailsContainer.Location = new System.Drawing.Point(12, 114);
            this.DetailsContainer.Name = "DetailsContainer";
            this.DetailsContainer.Size = new System.Drawing.Size(289, 146);
            this.DetailsContainer.TabIndex = 2;
            this.DetailsContainer.TabStop = false;
            // 
            // Details
            // 
            this.Details.Location = new System.Drawing.Point(6, 54);
            this.Details.Multiline = true;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            this.Details.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Details.Size = new System.Drawing.Size(277, 86);
            this.Details.TabIndex = 2;
            // 
            // Type
            // 
            this.Type.Location = new System.Drawing.Point(47, 34);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(236, 13);
            this.Type.TabIndex = 1;
            this.Type.Text = "Exception";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lType.Location = new System.Drawing.Point(6, 34);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(34, 13);
            this.lType.TabIndex = 0;
            this.lType.Text = "Type:";
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(47, 16);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(236, 13);
            this.Code.TabIndex = 1;
            this.Code.Text = "pkS2i7vIuUSUDOkOx7DQxw";
            // 
            // lCode
            // 
            this.lCode.AutoSize = true;
            this.lCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCode.Location = new System.Drawing.Point(6, 16);
            this.lCode.Name = "lCode";
            this.lCode.Size = new System.Drawing.Size(35, 13);
            this.lCode.TabIndex = 0;
            this.lCode.Text = "Code:";
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(307, 237);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 3;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(114, 37);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(268, 71);
            this.Description.TabIndex = 4;
            this.Description.Text = "This is a general problem we didn\'t anticipate. If the problem keeps";
            // 
            // pbImage
            // 
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(96, 96);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 5;
            this.pbImage.TabStop = false;
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 272);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.DetailsContainer);
            this.Controls.Add(this.Caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Python in Excel";
            this.DetailsContainer.ResumeLayout(false);
            this.DetailsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        public System.Windows.Forms.GroupBox DetailsContainer;
        public System.Windows.Forms.Label Code;
        private System.Windows.Forms.Label lCode;
        public System.Windows.Forms.Label Type;
        private System.Windows.Forms.Label lType;
        public System.Windows.Forms.TextBox Details;
        public System.Windows.Forms.Label Description;
        public System.Windows.Forms.PictureBox pbImage;
        public System.Windows.Forms.Label Caption;
    }
}