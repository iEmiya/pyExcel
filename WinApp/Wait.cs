using System.Windows.Forms;

namespace pyExcel.WinApp
{
    internal partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
            this.pictureBox.Image = Properties.Resources.Waiting;
        }
    }
}
