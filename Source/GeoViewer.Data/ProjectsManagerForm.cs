using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Data.Properties;
using GeoViewer.Utils;

namespace GeoViewer.Data
{
    public partial class ProjectsManagerForm : BaseWindowForm
    {
        public ProjectsManagerForm()
        {
            InitializeComponent();
            BindingData();
        }

        private void LoggersManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_DATA_VIEW);
        }

        private void BindingData()
        {
            projectGrid.DataSource = entityConntext.Projects.Select(ent => new { ent.ProjectID, ent.Name }).ToList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (new ProjectAddEditForm().ShowDialog() == DialogResult.OK)
            {
                BindingData();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (projectGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            var id = projectGrid.SelectedRows[0].Cells[0].Value.ToInt32TryParse();
            if (new ProjectAddEditForm(ProjectBLL.Current.GetByID(id)).ShowDialog() == DialogResult.OK)
            {
                BindingData();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (projectGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            var id = projectGrid.SelectedRows[0].Cells[0].Value.ToInt32TryParse();

            if (ShowConfirmMessage(string.Format("Bạn có chắc chắn muốn xóa project ID {0} và tất cả các dữ liệu liên quan?", id)) == DialogResult.OK)
            {
                if (ProjectBLL.Current.Delete(id))
                {
                    ShowSuccessMessage("Xóa project thành công!");
                    BindingData();
                }
            }
        }

        private void projectGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            openProject();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            openProject();
        }

        private void openProject()
        {
            if (projectGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.Warning_NoRecordSelected);
                return;
            }
            var id = projectGrid.SelectedRows[0].Cells[0].Value.ToInt32TryParse();
            ProjectBLL.Current.OpenProject(id);
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
