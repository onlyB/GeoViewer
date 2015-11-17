using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Data.Properties;

namespace GeoViewer.Data
{
    public partial class BackupRestoreForm : BaseWindowForm
    {
        public BackupRestoreForm()
        {
            InitializeComponent();
            txtFileNameBackup.Text = BackupRestoreBLL.Current.GetDefaultBackupFolder();
            BindingGrid();
        }

        private void BindingGrid()
        {
            DirectoryInfo folder = new DirectoryInfo(BackupRestoreBLL.Current.GetDefaultBackupFolder());
            var zipFiles = folder.GetFiles("*.zip", SearchOption.TopDirectoryOnly);
            dataGridView1.DataSource = zipFiles.OrderByDescending(ent => ent.CreationTime).Select(ent => new {ent.FullName, FileSize = ent.Length / 1024 + " Kb", ent.CreationTime }).ToList();
        }

        private void BackupRestoreForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_DATA_VIEW);
        }

        #region private event
        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            var openFileDialog = new FolderBrowserDialog();
            openFileDialog.SelectedPath = txtFileNameBackup.Text;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileNameBackup.Text = openFileDialog.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (BackupRestoreBLL.Current.BackupToFile(txtFileNameBackup.Text) != null)
                {
                    ShowSuccessMessage(Resources.Message_BackupSuccess);
                    BindingGrid();
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = BackupRestoreBLL.Current.GetDefaultBackupFolder();
            openFileDialog.Filter = "Backup file(*.zip)|*.zip";
            //openFileDialog.FilterIndex = 2;
            //openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileNameRestore.Text = openFileDialog.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (ShowConfirmMessage(string.Format(Resources.Confirm_Restore, txtFileNameRestore.Text)) == DialogResult.OK)
            {
                try
                {
                    BackupRestoreBLL.Current.RestoreFromFile(txtFileNameRestore.Text);
                    ShowSuccessMessage(Resources.Message_RestoreSuccess);
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception.Message);
                }
            }
        }

        //private void btnDeleteAll_Click(object sender, EventArgs e)
        //{
        //    string[] files = Directory.GetFiles(txtFileNameRestore.Text);
        //    foreach (var file in files)
        //    {
        //        File.Delete(file);
        //    }
        //    DirectoryInfo folder = new DirectoryInfo(txtFileNameRestore.Text);
        //    var zipFiles = folder.GetFiles("*.zip", SearchOption.TopDirectoryOnly);
        //    dataGridView1.DataSource = zipFiles.Select(ent => new { ent.Name, Size = ent.Length / 1024, ent.CreationTime, ent.Attributes }).ToList();
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            if (ShowConfirmMessage(string.Format(Resources.Confirm_DeleteBackup, txtFileNameRestore.Text)) == DialogResult.OK)
            {
                try
                {
                    File.Delete(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    BindingGrid();
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception.Message);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFileNameRestore.Text = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
        }
        #endregion
    }
}