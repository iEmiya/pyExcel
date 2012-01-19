using System;
using System.Windows.Forms;

namespace pyExcel.WinApp
{
    internal partial class ErrorMessage : Form
    {
        public ErrorMessage()
        {
            InitializeComponent();

            this.pbImage.Image = Properties.Resources.Error;
            this.Caption.Text = Properties.Resources.ErrorMessageCaption;
            this.Description.Text = Properties.Resources.ErrorMessageDescriptionDefault;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
