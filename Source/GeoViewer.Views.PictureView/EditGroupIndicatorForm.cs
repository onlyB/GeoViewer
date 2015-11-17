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

namespace GeoViewer.Views.PictureView
{
    public partial class EditGroupIndicatorForm : BaseWindowForm
    {
        private bool submitted = false;
        private int width, height, top, left;
        private int idPicture = 0;

        public EditGroupIndicatorForm(int idObject)
        {
            InitializeComponent();
            LoadForm(idObject);
        }

        private void LoadForm(int idObject)
        {
            try
            {
                // Load datagrid
                List<GeoViewer.Models.PictureView> picturelist = entityConntext.PictureViews.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).ToList();
                var list = (from ent in picturelist
                            select new { ent.PictureViewID, ent.Name, ent.Description });
                dataGridView1.DataSource = list.ToList();
                // Load current object
                var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                if (obj != null)
                {
                    this.widthNumericUpDown.Value = obj.Width;
                    this.heightNumericUpDown.Value = obj.Height;
                    this.topNumericUpDown.Value = obj.Y;
                    this.leftNumericUpDown.Value = obj.X;
                    // Find current picture
                    int pictureId = Convert.ToInt32(obj.Parameters);
                    GeoViewer.Models.PictureView picture = PictureViewBLL.Current.GetByID(pictureId);
                    if (picture != null)
                    {
                        this.idPicture = picture.PictureViewID;
                        this.valueTextBox.Text = "Current Picture: " + picture.Name;
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        public int IDPicture
        {
            get
            {
                return this.idPicture;
            }
        }

        public int IndWidth
        {
            get
            {
                return this.width;
            }
        }

        public int IndHeight
        {
            get
            {
                return this.height;
            }
        }

        public int IndTop
        {
            get
            {
                return this.top;
            }
        }

        public int IndLeft
        {
            get
            {
                return this.left;
            }
        }

        public bool Submitted
        {
            get
            {
                return this.submitted;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.submitted = true;
                this.top = System.Convert.ToInt32(topNumericUpDown.Value);
                this.left = System.Convert.ToInt32(leftNumericUpDown.Value);
                this.width = System.Convert.ToInt32(widthNumericUpDown.Value);
                this.height = System.Convert.ToInt32(heightNumericUpDown.Value);
                this.Close();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int pictureId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PictureViewID"].Value);
                    GeoViewer.Models.PictureView picture = PictureViewBLL.Current.GetByID(pictureId);
                    this.valueTextBox.Text = "Current Picture: " + picture.Name;
                    this.idPicture = picture.PictureViewID;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
    }
}
