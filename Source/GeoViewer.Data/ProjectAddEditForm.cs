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

namespace GeoViewer.Data
{
    public partial class ProjectAddEditForm : BaseWindowForm
    {
        private Project _project;

        public ProjectAddEditForm(Project project = null)
        {
            InitializeComponent();
            _project = project;
            if(_project != null)
            {
                txtName.Text = _project.Name;
                txtDescription.Text = _project.Description;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_project == null)
            {
                _project = new Project();
                _project.Name = txtName.Text;
                _project.Description = txtDescription.Text;
                if(ProjectBLL.Current.Insert(_project))
                {
                    ShowSuccessMessage("Thêm project thành công!");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                _project.Name = txtName.Text;
                _project.Description = txtDescription.Text;
                if (ProjectBLL.Current.Update(_project))
                {
                    ShowSuccessMessage("Sửa project thành công!");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
