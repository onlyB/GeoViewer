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
using GeoViewer.Views.PictureView.Properties;

namespace GeoViewer.Views.PictureView
{
    public partial class EditObjectForm : BaseWindowForm
    {
        private bool submitted = false;
        private int idVar = 0;
        private int width, height, top, left;

        public EditObjectForm(int idObject)
        {
            InitializeComponent();
            LoadForm(idObject);
        }

        private void LoadForm(int idObject)
        {
            try
            {
                // Load datagrid
                List<GeoViewer.Models.Sensor> sensorlist = entityConntext.Sensors.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).ToList();
                var list = (from ent in sensorlist
                            select new { ent.SensorID, ent.Name, ent.Unit, ent.Description });
                dataGridView1.DataSource = list.ToList();
                // Load current object
                var obj = PictureViewBLL.Current.GetObjectByID(idObject);
                if (obj != null)
                {
                    this.widthNumericUpDown.Value = obj.Width;
                    this.heightNumericUpDown.Value = obj.Height;
                    this.topNumericUpDown.Value = obj.Y;
                    this.leftNumericUpDown.Value = obj.X;
                    // Find current sensor
                    int sensorId = Convert.ToInt32(obj.Parameters);
                    var sensor = SensorBLL.Current.GetByID(sensorId);
                    if (sensor != null)
                    {
                        this.idVar = sensor.SensorID;
                        this.valueTextBox.Text = Resources.EditObjectForm_Current_Value + sensor.Name;
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        public int IDVar
        {
            get
            {
                return this.idVar;
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
                    int sensorId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SensorID"].Value);
                    var sensor = SensorBLL.Current.GetByID(sensorId);
                    this.valueTextBox.Text = Resources.EditObjectForm_Current_Value + sensor.Name;
                    this.idVar = sensor.SensorID;
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
    }
}
