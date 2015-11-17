using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business.Properties;
using GeoViewer.Models;

namespace GeoViewer.Business
{
    public class BaseWindowForm : Form
    {
        public GeoViewerEntities entityConntext = new GeoViewerEntities() ;

        public BaseWindowForm()
        {
            MaximizeBox = false;
        }
       

        protected virtual void CheckRoleForView(string viewRole)
        {
            try
            {
                SecurityBLL.Current.CheckPermissionThrowException(viewRole);
            }
            catch (Exception exception)
            {
                ShowWarningMessage(exception.Message);
                this.Dispose();
            }
        }

        protected DialogResult ShowSuccessMessage(string message)
        {
            return MessageBox.Show(message, Resources.SuccessMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected DialogResult ShowWarningMessage(string message)
        {
            return MessageBox.Show(message, Resources.WarningMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected DialogResult ShowErrorMessage(string message)
        {
            return MessageBox.Show(message, Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected DialogResult ShowConfirmMessage(string message)
        {
            return MessageBox.Show(message, Resources.ConfirmMessageCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        protected const int STATE_ADDING = 0;
        protected const int STATE_EDITING = 1;
        protected const int STATE_BATCH_EDITING = 2;
    }
}
