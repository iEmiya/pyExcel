using System;
using System.Windows.Forms;
using pyExcel.Framework;

namespace pyExcel.WinApp
{
    internal sealed class ExceptionHelper
    {
        public static DialogResult Show(Exception ex)
        {
            return Show(null, ex);
        }

        public static DialogResult Show(IWin32Window owner, Exception e)
        {
            ErrorMessage em = new ErrorMessage();
            if (e == null)
            {
                em.DetailsContainer.Visible = false;
            }
            else
            {
                em.Description.Text = e.Message;
                IUIExceptionDetail detail = e as IUIExceptionDetail;
                if (detail == null)
                {
                    em.Code.Text = "WHUGRJgn4k-Uup30Lf58Qg";
                    em.Details.Visible = false;
                }
                else
                {
                    em.Code.Text = detail.Code;
                    em.Details.Text = detail.DetailMessage;

                    switch (detail.Type)
                    {
                        case TypeThrow.Error:
                            em.pbImage.Image = Properties.Resources.Error;
                            break;

                        case TypeThrow.Stop:
                            em.pbImage.Image = Properties.Resources.Stop;
                            break;

                        case TypeThrow.Exclamation:
                            em.pbImage.Image = Properties.Resources.Exclamation;
                            break;

                        case TypeThrow.Warning:
                            em.Caption.Text = Properties.Resources.WarningMessageCaption;
                            em.pbImage.Image = Properties.Resources.Warning;
                            break;

                        case TypeThrow.Asterisk:
                            em.Caption.Text = Properties.Resources.WarningMessageCaption;
                            em.pbImage.Image = Properties.Resources.Asterisk;
                            break;

                        case TypeThrow.Information:
                            em.Caption.Text = Properties.Resources.InformationMessageCaption;
                            em.pbImage.Image = Properties.Resources.Information;
                            break;
                    }
                }
                em.Type.Text = e.GetType().ToString();
            }
            return em.ShowDialog();
        }
    }
}
