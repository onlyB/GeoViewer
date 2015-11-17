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
using GeoViewer.Models;
using GeoViewer.Properties;
using GeoViewer.Setup;
using GeoViewer.Views.ChartView;
using Geoviewer.Security;
using GeoViewer.Data;
using GeoViewer.Alarm;
using GeoViewer.Views.PictureView;
using GeoViewer.Views.TextView;

namespace GeoViewer
{
    public partial class MainForm : BaseWindowForm
    {
        private bool connectedToDatabase = false;
        public static MainForm MainApplicationForm { private set; get; }

        public MainForm()
        {
            // Check connection to database
            GeoViewerEntities context = null;
            try
            {
                context = new GeoViewerEntities();
                var list = context.Accounts.Count();
            }
            catch (Exception)
            {
                if (context != null) context.Dispose();
                if (new SetupDatabase().ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
            // Check licence
            if (!LicenceBLL.ValidateKey())
            {
                if (new AddLicenceForm().ShowDialog() != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }

            connectedToDatabase = true;
            MainApplicationForm = this;
            InitializeComponent();
            // Check connection to database

            // Run background process
            ReaderThreadManager.Current.InitThreads();
            ReaderThreadManager.Current.StartThreads();

        }

        private void ExitApplication()
        {
            // Exit System
            if (ShowConfirmMessage(Resources.Confirm_Exit) == DialogResult.OK)
                Environment.Exit(0);
        }

        #region form event
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            //appNotifyIcon.Visible = true;
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            Console.WriteLine("MainForm: " + this.Visible);
            if (this.Visible)
            {
                // Check user has been logged in?
                if (AppContext.Current.LogedInUser == null)
                {
                    this.Visible = false;
                    var login = new LoginForm();
                    login.ShowDialog();
                    if (login.LoggInSuccess)
                    {
                        this.Visible = true;
                        userToolStripMenuItem.Text = AppContext.Current.LogedInUser.Username;
                    }
                    else
                    {
                        this.Visible = false;
                    }
                }

                configView();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region navigation
        private void accountManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AccountManagerForm().ShowDialog();
        }

        private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AccountUpdateForm().ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Log out to system
            AccountBLL.Current.Logout();
            this.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit System
            ExitApplication();
        }

        private void loggersSensorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoggersManagerForm().ShowDialog();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BackupRestoreForm().ShowDialog();
        }

        private void pictureViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PictureViewsManagerForm().ShowDialog();
        }

        private void chartViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Chart View Manager
            var datetime = DataReaderBLL.Current.GetLastTime();
            new ChartMainForm(startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                  endDate: datetime).ShowDialog();

        }

        private void textViewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var datetime = DataReaderBLL.Current.GetLastTime();
            new TextViewForm(startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                  endDate: datetime).ShowDialog();
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AlarmManagerForm().ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Chart View Manager
        }

        private void pictureViewButton_Click(object sender, EventArgs e)
        {
            new PictureViewsManagerForm().ShowDialog();
        }

        private void chartViewButton_Click(object sender, EventArgs e)
        {
            var datetime = DataReaderBLL.Current.GetLastTime();
            new ChartMainForm(startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                  endDate: datetime).ShowDialog();
        }

        private void textViewButton_Click(object sender, EventArgs e)
        {
            var datetime = DataReaderBLL.Current.GetLastTime();
            new TextViewForm(startDate: datetime != null ? (DateTime?)datetime.Value.AddDays(-6) : null,
                                  endDate: datetime).ShowDialog();
        }

        private void alarmLogButton_Click(object sender, EventArgs e)
        {
            var datetime = AlarmBLL.Current.GetLastTime();
            new AlarmManagerForm(null,
                datetime != null ? (DateTime?)datetime.Value.AddDays(-7) : null,
                datetime != null ? (DateTime?)datetime.Value.AddDays(1) : null, false).ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void appNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Exit System
            ExitApplication();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectBLL.Current.CloseProject();
            configView();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectsManagerForm().ShowDialog();
            configView();
        }
        #endregion

        private void alarmNotifyTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (connectedToDatabase)
                {
                    int count = entityConntext.AlarmLogs.Count(ent => !ent.IsEnded && ent.LastEditedDate == null);
                    if (count > 0)
                    {
                        if (!AlarmNotifyForm.IsNotifying)
                        {
                            if (!(AlarmNotifyForm.DisableToUntilAlarm && count == AlarmNotifyForm.NumberOfSensor))
                            {
                                AlarmNotifyForm.NumberOfSensor = count;
                                new AlarmNotifyForm().Show();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        private void configView()
        {
            loggersSensorsToolStripMenuItem.Enabled
                = viewsToolStripMenuItem.Enabled
                = pictureViewButton.Enabled
                = chartViewButton.Enabled
                = textViewButton.Enabled
                = closeProjectToolStripMenuItem.Visible
                = AppContext.Current.OpenProject != null;

            this.Text = AppContext.Current.OpenProject != null ? string.Format(Resources.MainForm_Title_Project, AppContext.Current.OpenProject.Name) : Resources.MainForm_Title;
        }
    }
}
