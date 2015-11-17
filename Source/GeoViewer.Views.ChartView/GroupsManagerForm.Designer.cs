using GeoViewer.Views.ChartView.Properties;

namespace GeoViewer.Views.ChartView
{
    partial class GroupsManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupsManagerForm));
            this.GridViewGroup = new System.Windows.Forms.DataGridView();
            this.btncreategroup = new System.Windows.Forms.Button();
            this.btndeletegroup = new System.Windows.Forms.Button();
            this.GridViewSensors = new System.Windows.Forms.DataGridView();
            this.SensorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtgroupname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnaddsensor = new System.Windows.Forms.Button();
            this.btndeletesensor = new System.Windows.Forms.Button();
            this.btnapply = new System.Windows.Forms.Button();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSensors)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewGroup
            // 
            this.GridViewGroup.AllowUserToAddRows = false;
            this.GridViewGroup.AllowUserToDeleteRows = false;
            this.GridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupID,
            this.GroupName});
            this.GridViewGroup.Location = new System.Drawing.Point(5, 5);
            this.GridViewGroup.Name = "GridViewGroup";
            this.GridViewGroup.ReadOnly = true;
            this.GridViewGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewGroup.Size = new System.Drawing.Size(239, 374);
            this.GridViewGroup.TabIndex = 1;
            this.GridViewGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewGroup_CellClick);
            // 
            // btncreategroup
            // 
            this.btncreategroup.Image = global::GeoViewer.Views.ChartView.Properties.Resources.add_16;
            this.btncreategroup.Location = new System.Drawing.Point(5, 386);
            this.btncreategroup.Name = "btncreategroup";
            this.btncreategroup.Size = new System.Drawing.Size(100, 26);
            this.btncreategroup.TabIndex = 3;
            this.btncreategroup.Text = global::GeoViewer.Views.ChartView.Properties.Resources.GroupsManagerForm_InitializeComponent_AddGroup;
            this.btncreategroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncreategroup.UseVisualStyleBackColor = true;
            this.btncreategroup.Click += new System.EventHandler(this.btncreategroup_Click);
            // 
            // btndeletegroup
            // 
            this.btndeletegroup.Image = global::GeoViewer.Views.ChartView.Properties.Resources.delete_16;
            this.btndeletegroup.Location = new System.Drawing.Point(111, 386);
            this.btndeletegroup.Name = "btndeletegroup";
            this.btndeletegroup.Size = new System.Drawing.Size(100, 26);
            this.btndeletegroup.TabIndex = 4;
            this.btndeletegroup.Text = global::GeoViewer.Views.ChartView.Properties.Resources.GroupsManagerForm_InitializeComponent_DeleteGroup;
            this.btndeletegroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletegroup.UseVisualStyleBackColor = true;
            this.btndeletegroup.Click += new System.EventHandler(this.btndeletegroup_Click);
            // 
            // GridViewSensors
            // 
            this.GridViewSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewSensors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SensorID,
            this.SensorName});
            this.GridViewSensors.Location = new System.Drawing.Point(253, 87);
            this.GridViewSensors.Name = "GridViewSensors";
            this.GridViewSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewSensors.Size = new System.Drawing.Size(246, 292);
            this.GridViewSensors.TabIndex = 5;
            // 
            // SensorID
            // 
            this.SensorID.DataPropertyName = "SensorID";
            this.SensorID.HeaderText = "Mã";
            this.SensorID.Name = "SensorID";
            this.SensorID.Width = 50;
            // 
            // SensorName
            // 
            this.SensorName.DataPropertyName = "Name";
            this.SensorName.HeaderText = "Tên cảm biến";
            this.SensorName.Name = "SensorName";
            this.SensorName.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên nhóm cảm biến";
            // 
            // txtgroupname
            // 
            this.txtgroupname.Location = new System.Drawing.Point(253, 37);
            this.txtgroupname.Name = "txtgroupname";
            this.txtgroupname.Size = new System.Drawing.Size(165, 20);
            this.txtgroupname.TabIndex = 7;
            this.txtgroupname.TextChanged += new System.EventHandler(this.txtgroupname_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cảm biến trong nhóm";
            // 
            // btnaddsensor
            // 
            this.btnaddsensor.Image = global::GeoViewer.Views.ChartView.Properties.Resources.add_16;
            this.btnaddsensor.Location = new System.Drawing.Point(293, 384);
            this.btnaddsensor.Name = "btnaddsensor";
            this.btnaddsensor.Size = new System.Drawing.Size(100, 26);
            this.btnaddsensor.TabIndex = 9;
            this.btnaddsensor.Text = "Thêm";
            this.btnaddsensor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaddsensor.UseVisualStyleBackColor = true;
            this.btnaddsensor.Click += new System.EventHandler(this.btnaddsensor_Click);
            // 
            // btndeletesensor
            // 
            this.btndeletesensor.Image = global::GeoViewer.Views.ChartView.Properties.Resources.delete_16;
            this.btndeletesensor.Location = new System.Drawing.Point(399, 384);
            this.btndeletesensor.Name = "btndeletesensor";
            this.btndeletesensor.Size = new System.Drawing.Size(100, 26);
            this.btndeletesensor.TabIndex = 10;
            this.btndeletesensor.Text = global::GeoViewer.Views.ChartView.Properties.Resources.GroupsManagerForm_InitializeComponent_Remove_Sensor;
            this.btndeletesensor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletesensor.UseVisualStyleBackColor = true;
            this.btndeletesensor.Click += new System.EventHandler(this.btndeletesensor_Click);
            // 
            // btnapply
            // 
            this.btnapply.Image = global::GeoViewer.Views.ChartView.Properties.Resources.disk_16;
            this.btnapply.Location = new System.Drawing.Point(424, 33);
            this.btnapply.Name = "btnapply";
            this.btnapply.Size = new System.Drawing.Size(75, 26);
            this.btnapply.TabIndex = 11;
            this.btnapply.Text = global::GeoViewer.Views.ChartView.Properties.Resources.GroupsManagerForm_InitializeComponent_Save;
            this.btnapply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnapply.UseVisualStyleBackColor = true;
            this.btnapply.Click += new System.EventHandler(this.btnapply_Click);
            // 
            // GroupID
            // 
            this.GroupID.DataPropertyName = "GroupID";
            this.GroupID.HeaderText = "Mã";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Width = 50;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Name";
            this.GroupName.HeaderText = "Tên nhóm";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 300;
            // 
            // GroupsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 418);
            this.Controls.Add(this.btnapply);
            this.Controls.Add(this.btndeletesensor);
            this.Controls.Add(this.btnaddsensor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtgroupname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridViewSensors);
            this.Controls.Add(this.btndeletegroup);
            this.Controls.Add(this.btncreategroup);
            this.Controls.Add(this.GridViewGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupsManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhóm cảm biến";
            this.Load += new System.EventHandler(this.GroupsManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSensors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewGroup;
        private System.Windows.Forms.Button btncreategroup;
        private System.Windows.Forms.Button btndeletegroup;
        private System.Windows.Forms.DataGridView GridViewSensors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgroupname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnaddsensor;
        private System.Windows.Forms.Button btndeletesensor;
        private System.Windows.Forms.Button btnapply;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;

    }
}