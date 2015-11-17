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
using GeoViewer.Models;
using Geoviewer.Security.Properties;

namespace Geoviewer.Security
{
    public partial class AccountManagerForm : BaseWindowForm
    {
        private int _addEditState = 0;
        private Account _editingAccount = null;

        public AccountManagerForm()
        {
            InitializeComponent();
            BindingData();
        }

        private void AccountManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_ACCOUNT_VIEW);
        }

        #region private function
        private void BindingData()
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                accountGridView.DataSource = entityConntext.Accounts.Select(ent => new
                                                                                       {
                                                                                           ent.Username,
                                                                                           ent.Email,
                                                                                           ent.FullName,
                                                                                           ent.IsApproved,
                                                                                           ent.IsLocked,
                                                                                           ent.CreatedDate,
                                                                                           ent.LastLoginDate
                                                                                       });
            }
        }

        private void prepareToAdd()
        {
            _addEditState = 0;
            _editingAccount = null;
            txtEmail.Text = txtFullName.Text = txtPassword.Text = txtUsername.Text = "";
            txtUsername.Enabled = true;
            resetPassButton.Visible = false;
            addeditBox.Enabled = true;
            approveCheckBox.Checked = true;
            lockCheckBox.Checked = false;
        }

        private void prepareToEdit()
        {
            if (accountGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            _editingAccount = AccountBLL.Current.GetByUsername(accountGridView.SelectedRows[0].Cells["Username"].Value.ToString());
            if (_editingAccount != null)
            {
                _addEditState = 1;
                txtUsername.Text = _editingAccount.Username;
                txtUsername.Enabled = false;
                txtEmail.Text = _editingAccount.Email;
                txtFullName.Text = _editingAccount.FullName;
                resetPassButton.Visible = true;
                addeditBox.Enabled = true;

                approveCheckBox.Checked = _editingAccount.IsApproved;
                lockCheckBox.Checked = _editingAccount.IsLocked;

                // Roles
                ckAccountManage.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_ACCOUNT_MANAGE);
                ckAccountEdit.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_ACCOUNT_EDIT);
                ckAccountView.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_ACCOUNT_VIEW);

                ckDataManage.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_DATA_MANAGE);
                ckDataEdit.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_DATA_EDIT);
                ckDataView.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_DATA_VIEW);

                ckViewsManage.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_VIEWS_MANAGE);
                ckViewsEdit.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_VIEWS_EDIT);
                ckViewsView.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_VIEWS_VIEW);

                ckAlarmManage.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_ALARM_MANAGE);
                ckAlarmEdit.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_ALARM_EDIT);
                ckAlarmView.Checked = SecurityBLL.Current.IsUserInRole(_editingAccount, SecurityBLL.ROLE_ALARM_VIEW);
            }
        }

        private void addEdit()
        {
            try
            {
                // Roles
                List<string> roles = new List<string>();
                if (ckAccountManage.Checked) roles.Add(SecurityBLL.ROLE_ACCOUNT_MANAGE);
                if (ckAccountEdit.Checked) roles.Add(SecurityBLL.ROLE_ACCOUNT_EDIT);
                if (ckAccountView.Checked) roles.Add(SecurityBLL.ROLE_ACCOUNT_VIEW);

                if (ckDataManage.Checked) roles.Add(SecurityBLL.ROLE_DATA_MANAGE);
                if (ckDataEdit.Checked) roles.Add(SecurityBLL.ROLE_DATA_EDIT);
                if (ckDataView.Checked) roles.Add(SecurityBLL.ROLE_DATA_VIEW);

                if (ckViewsManage.Checked) roles.Add(SecurityBLL.ROLE_VIEWS_MANAGE);
                if (ckViewsEdit.Checked) roles.Add(SecurityBLL.ROLE_VIEWS_EDIT);
                if (ckViewsView.Checked) roles.Add(SecurityBLL.ROLE_VIEWS_VIEW);

                if (ckAlarmManage.Checked) roles.Add(SecurityBLL.ROLE_ALARM_MANAGE);
                if (ckAlarmEdit.Checked) roles.Add(SecurityBLL.ROLE_ALARM_EDIT);
                if (ckAlarmView.Checked) roles.Add(SecurityBLL.ROLE_ALARM_VIEW);

                if (_addEditState == 0 || _editingAccount == null)
                {
                    _editingAccount = new Account();
                    _editingAccount.Username = txtUsername.Text;
                    _editingAccount.Password = txtPassword.Text;
                }
                _editingAccount.Email = txtEmail.Text;
                _editingAccount.FullName = txtFullName.Text;
                _editingAccount.IsApproved = approveCheckBox.Checked;
                _editingAccount.IsLocked = lockCheckBox.Checked;

                if (_addEditState == 0)
                {
                    if (AccountBLL.Current.Insert(_editingAccount))
                    {
                        SecurityBLL.Current.SetRolesForUser(_editingAccount.Username, roles.ToArray());
                        ShowSuccessMessage(Resources.Message_AddAccountSuccess);
                    }
                    prepareToAdd();
                    BindingData();
                    return;
                }
                if (_addEditState == 1)
                {
                    if (AccountBLL.Current.Update(_editingAccount))
                    {
                        SecurityBLL.Current.SetRolesForUser(_editingAccount.Username, roles.ToArray());
                        ShowSuccessMessage(Resources.Message_EditAccountSuccess);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                //if (_addEditState == 1)
                //    entityConntext.Refresh(RefreshMode.StoreWins, _editingAccount);
            }
        }
        #endregion

        #region private event


        private void ckAccountManage_CheckedChanged(object sender, EventArgs e)
        {
            ckAccountEdit.Enabled = ckAccountView.Enabled = !ckAccountManage.Checked;
            if (ckAccountManage.Checked) ckAccountEdit.Checked = ckAccountView.Checked = true;
        }

        private void ckDataManage_CheckedChanged(object sender, EventArgs e)
        {
            ckDataEdit.Enabled = ckDataView.Enabled = !ckDataManage.Checked;
            if (ckDataManage.Checked) ckDataEdit.Checked = ckDataView.Checked = true;
        }

        private void ckViewsManage_CheckedChanged(object sender, EventArgs e)
        {
            ckViewsEdit.Enabled = ckViewsView.Enabled = !ckViewsManage.Checked;
            if (ckViewsManage.Checked) ckViewsEdit.Checked = ckViewsView.Checked = true;
        }

        private void ckAlarmManage_CheckedChanged(object sender, EventArgs e)
        {
            ckAlarmEdit.Enabled = ckAlarmView.Enabled = !ckAlarmManage.Checked;
            if (ckAlarmManage.Checked) ckAlarmEdit.Checked = ckAlarmView.Checked = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            prepareToAdd();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            prepareToEdit();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            //  AppContext.Current.RefreshEntityContext();
            BindingData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            addEdit();
        }

        private void accountGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            prepareToEdit();
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (accountGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show(Resources.Warning_NoRecordSelected);
                    return;
                }
                string username = accountGridView.SelectedRows[0].Cells["Username"].Value.ToString();
                if (ShowConfirmMessage(string.Format(Resources.Message_ConfirmDeleteAccount, username)) == DialogResult.OK)
                {
                    if (AccountBLL.Current.Delete(username))
                    {
                        ShowSuccessMessage(Resources.Message_DeleteAccountSuccess);
                        BindingData();
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void resetPassButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountBLL.Current.ChangePassword(_editingAccount, txtPassword.Text))
                {
                    ShowSuccessMessage(Resources.Message_ResetPassSuccess);
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        #endregion


    }
}
