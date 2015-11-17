using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Utils;
using Geoviewer.Security.Properties;

namespace Geoviewer.Security
{
    public partial class AccountUpdateForm : BaseWindowForm
    {
        public AccountUpdateForm()
        {
            InitializeComponent();
            BindingData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                AppContext.Current.LogedInUser.Email = txtEmail.Text;
                AppContext.Current.LogedInUser.FullName = txtFullName.Text;
                if (AccountBLL.Current.Update(AppContext.Current.LogedInUser))
                {
                    ShowSuccessMessage(Resources.Message_EditAccountSuccess);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                //entityConntext.Refresh(RefreshMode.StoreWins, AppContext.Current.LogedInUser);
            }
        }

        private void changePassButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text) throw new Exception(Resources.Error_ConfimPassNotMatch);
                if (AccountBLL.Current.ChangePassword(txtOldPassword.Text, txtNewPassword.Text))
                {
                    ShowSuccessMessage(Resources.Message_ResetPassSuccess);
                    txtOldPassword.Text = txtNewPassword.Text = txtConfirmPassword.Text = "";
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void BindingData()
        {
            txtUsername.Text = AppContext.Current.LogedInUser.Username;
            txtEmail.Text = AppContext.Current.LogedInUser.Email;
            txtFullName.Text = AppContext.Current.LogedInUser.FullName;

            lblCreatedDate.Text = AppContext.Current.LogedInUser.CreatedDate.ToDatetimeString();
            lblLastLoginDate.Text = AppContext.Current.LogedInUser.LastLoginDate.ToDatetimeString();

            // Roles
            ckAccountManage.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ACCOUNT_MANAGE);
            ckAccountEdit.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ACCOUNT_EDIT);
            ckAccountView.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ACCOUNT_VIEW);

            ckDataManage.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_DATA_MANAGE);
            ckDataEdit.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_DATA_EDIT);
            ckDataView.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_DATA_VIEW);

            ckViewsManage.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_VIEWS_MANAGE);
            ckViewsEdit.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_VIEWS_EDIT);
            ckViewsView.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_VIEWS_VIEW);

            ckAlarmManage.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ALARM_MANAGE);
            ckAlarmEdit.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ALARM_EDIT);
            ckAlarmView.Checked = SecurityBLL.Current.IsUserInRole(SecurityBLL.ROLE_ALARM_VIEW);

        }

        private void AccountUpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
