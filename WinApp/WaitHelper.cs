using System;
using System.Drawing;
using System.Windows.Forms;

namespace pyExcel.WinApp
{
    internal class WaitHelper
    {
        private readonly Main _owner;
        private readonly Wait _waiting;

        public WaitHelper(Main owner)
        {
            _owner = owner;
            _waiting = new Wait();
        }

        public void Show()
        {
            if (_owner.InvokeRequired)
            {
                _owner.Invoke(new Action(Show));
                return;
            }

            Point parentPoint = _owner.Location;

            int parentHeight = _owner.Height;
            int parentWidth = _owner.Width;

            int childHeight = _waiting.Height;
            int childWidth = _waiting.Width;

            int resultX = parentPoint.X + parentWidth / 2 - childWidth / 2;
            int resultY = parentPoint.Y + parentHeight / 2 - childHeight / 2;

            // set our child form to the new position
            _waiting.Location = new Point(resultX, resultY);

            _waiting.Show();
        }

        public void Close()
        {
            if (_owner.InvokeRequired)
            {
                _owner.Invoke(new Action(Close));
                return;
            }

            _waiting.Hide();
            _owner.TopMost = true;
            _owner.TopMost = false;

        }
    }
}
