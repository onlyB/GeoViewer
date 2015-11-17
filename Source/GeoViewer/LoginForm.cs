/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Properties;

namespace GeoViewer
{
    public partial class LoginForm : Form
    {
        public bool LoggInSuccess { private set; get; }

        public LoginForm()
        {
            InitializeComponent();
            LoggInSuccess = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                AccountBLL.Current.Login(txtAccount.Text.Trim(),txtPassword.Text.Trim());
                LoggInSuccess = true;
                this.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.LoginForm_MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkRecoverPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
