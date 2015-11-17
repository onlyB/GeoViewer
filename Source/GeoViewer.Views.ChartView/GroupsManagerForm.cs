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
using GeoViewer.Utils;

namespace GeoViewer.Views.ChartView
{
    public partial class GroupsManagerForm : BaseWindowForm
    {
        private Group _group;

        /// <summary>
        /// Constructor with required Sensors Group parameter
        /// </summary>
        /// <param name="group">start editing with this group</param>
        public GroupsManagerForm(Group group = null)
        {
            _group = group;
            InitializeComponent();
            initialAddSensorForm();
            LoadGroupSensor();
        }

        private void LoadGroupSensor()
        {
            GridViewGroup.DataSource = entityConntext.Groups.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).Select(ent => new { ent.GroupID, ent.Name }).ToList();
        }

        int idgroup = 0;

        private void btncreategroup_Click(object sender, EventArgs e)
        {
            try
            {
                GroupCreate createform = new GroupCreate();
                createform.ShowDialog();
                //load after create group           
                LoadGroupSensor();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void btndeletegroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChartViewBLL.Current.DeleteGroup(idgroup))
                {
                    ShowSuccessMessage("Xóa nhóm thành công!");

                }
                //load after delete group
                GridViewSensors.DataSource = null;
                txtgroupname.Text = "";
                LoadGroupSensor();
            }
            catch(Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
            
        }

        int idsensor = 0;

        private void btndeletesensor_Click(object sender, EventArgs e)
        {
            try
            {
                Group group = entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == idgroup);
                // Sensor sensor = SensorBLL.Current.GetByID(idsensor);
                //try
                //{
                //    group.Sensors.Remove(sensor);
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("An Error");
                //}

                // Edited by binhpro
                if (GridViewSensors.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < GridViewSensors.SelectedRows.Count; i++)
                    {
                        var sensorId = GridViewSensors.SelectedRows[i].Cells["SensorID"].Value.ToInt32TryParse();
                        var sensor = entityConntext.Sensors.SingleOrDefault(ent => ent.SensorID == sensorId);
                            
                        if (sensor != null)
                        {
                            group.Sensors.Remove(sensor);
                        }
                    }
                }
                entityConntext.SaveChanges();
                ShowSuccessMessage("Bỏ " + GridViewSensors.SelectedRows.Count + " sensor khỏi nhóm thành công!");

                //Load after delete sensor in group
                //group = ChartViewBLL.Current.GetGroupByID(idgroup);
                //List<Sensor> sensorsInGroup = group.Sensors.ToList();
                GridViewSensors.DataSource = group.Sensors.ToList();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            try
            {
                var groupedit = ChartViewBLL.Current.GetGroupByID(idgroup);
                groupedit.Name = textchange;
                if (ChartViewBLL.Current.UpdateGroup(groupedit))
                {
                    ShowSuccessMessage("Cập nhật thông tin nhóm thành công!");
                    //load after change
                    LoadGroupSensor();
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        string textchange;
        private void txtgroupname_TextChanged(object sender, EventArgs e)
        {
            textchange = txtgroupname.Text;
        }


        //////////////////////////////////////////form add sensor to group///////////////////////////////////////////////
        Form AddSensorForm = new Form();
        DataGridView GridViewAdd = new DataGridView();
        Button btnAddSensors = new Button();
        Button btnCancel = new Button();

        private void initialAddSensorForm()
        {
            //grid view
            GridViewAdd.Location = new System.Drawing.Point(1, 1);
            GridViewAdd.Name = "dataGridView1";
            GridViewAdd.Size = new System.Drawing.Size(230, 330);
            GridViewAdd.TabIndex = 0;
            GridViewAdd.CellContentClick += new DataGridViewCellEventHandler(GridViewAdd_CellContentClick);
            GridViewAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //AddSensorForm
            AddSensorForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AddSensorForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AddSensorForm.ClientSize = new System.Drawing.Size(231, 366);
            AddSensorForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            AddSensorForm.Controls.Add(this.GridViewAdd);
            AddSensorForm.Controls.Add(this.btnAddSensors);
            AddSensorForm.Controls.Add(this.btnCancel);
            AddSensorForm.Name = "AddSensorForm";
            AddSensorForm.Text = "Thêm Sensor";

            // btnAddSensors          
            btnAddSensors.Location = new System.Drawing.Point(47, 337);
            btnAddSensors.Name = "btnAddSensors";
            btnAddSensors.Size = new System.Drawing.Size(75, 23);
            btnAddSensors.TabIndex = 1;
            btnAddSensors.Text = "Thêm";
            btnAddSensors.UseVisualStyleBackColor = true;
            btnAddSensors.Click += new EventHandler(btnAddSensors_Click);
            // btnCancel            
            btnCancel.Location = new System.Drawing.Point(144, 337);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Bỏ qua";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new EventHandler(btnCancel_Click);

        }

        int idsensoradd = 0;
        void GridViewAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idsensoradd = Convert.ToInt16(GridViewAdd.Rows[e.RowIndex].Cells[0].Value);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            idsensoradd = 0;
            AddSensorForm.Close();

            //Load after add sensor to group
            var group = entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == idgroup);
            List<Sensor> sensorsInGroup = group.Sensors.ToList();
            GridViewSensors.DataSource = sensorsInGroup;
        }

        void btnAddSensors_Click(object sender, EventArgs e)
        {

            try
            {
                int sensorId = GridViewAdd.SelectedRows[0].Cells[0].Value.ToInt32TryParse();
                Sensor sensor = entityConntext.Sensors.SingleOrDefault(ent => ent.SensorID == sensorId);
                Group group = entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == idgroup);
                try
                {
                    group.Sensors.Add(sensor);
                    GridViewSensors.DataSource = group.Sensors.ToList();
                    //ShowSuccessMessage("Sensor " + sensor.Name.ToString() + " đã được thêm vào nhóm " + group.Name);
                }
                catch (Exception exception)
                {
                    ShowWarningMessage(exception.Message);
                }
                entityConntext.SaveChanges();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }

        }



        //Button of Form GroupManagerForm
        private void btnaddsensor_Click(object sender, EventArgs e)
        {
            GridViewAdd.DataSource = entityConntext.Sensors.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).ToList();
            AddSensorForm.ShowDialog();
        }

        private void GridViewGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow rowgrid = GridViewGroup.Rows[e.RowIndex];
            idgroup = rowgrid.Cells[0].Value.ToInt32TryParse();
            //get sensor in group
            var group = entityConntext.Groups.SingleOrDefault(ent => ent.GroupID == idgroup);
            GridViewSensors.DataSource = group.Sensors.ToList();
            txtgroupname.Text = GridViewGroup.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void GroupsManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_VIEWS_EDIT);
        }
        

        //////////////////////////////////////end form add sensor to group///////////////////////////////////////////////
    }
}
