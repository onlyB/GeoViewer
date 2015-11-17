using GeoViewer.Views.TextView.Properties;

namespace GeoViewer.Views.TextView
{
    partial class TextViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextViewForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.calcRadio = new System.Windows.Forms.RadioButton();
            this.rawRadio = new System.Windows.Forms.RadioButton();
            this.todateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fromdateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureTab = new System.Windows.Forms.TabPage();
            this.pictureGridView = new System.Windows.Forms.DataGridView();
            this.PictureViewID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupTab = new System.Windows.Forms.TabPage();
            this.groupGridView = new System.Windows.Forms.DataGridView();
            this.GroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorTab = new System.Windows.Forms.TabPage();
            this.sensorGridView = new System.Windows.Forms.DataGridView();
            this.choiseTab = new System.Windows.Forms.TabControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SensorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoggerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pictureTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGridView)).BeginInit();
            this.groupTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupGridView)).BeginInit();
            this.sensorTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorGridView)).BeginInit();
            this.choiseTab.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(216, 35);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(756, 565);
            this.dataGridView.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.calcRadio);
            this.groupBox2.Controls.Add(this.rawRadio);
            this.groupBox2.Controls.Add(this.todateTextBox);
            this.groupBox2.Controls.Add(this.fromdateTextBox);
            this.groupBox2.Controls.Add(this.searchButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(10, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 221);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xem theo tùy chọn";
            // 
            // calcRadio
            // 
            this.calcRadio.AutoSize = true;
            this.calcRadio.Checked = true;
            this.calcRadio.Location = new System.Drawing.Point(90, 29);
            this.calcRadio.Name = "calcRadio";
            this.calcRadio.Size = new System.Drawing.Size(97, 18);
            this.calcRadio.TabIndex = 13;
            this.calcRadio.TabStop = true;
            this.calcRadio.Text = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_CalcValue;
            this.calcRadio.UseVisualStyleBackColor = true;
            // 
            // rawRadio
            // 
            this.rawRadio.AutoSize = true;
            this.rawRadio.Location = new System.Drawing.Point(13, 29);
            this.rawRadio.Name = "rawRadio";
            this.rawRadio.Size = new System.Drawing.Size(71, 18);
            this.rawRadio.TabIndex = 12;
            this.rawRadio.Text = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_RawValue;
            this.rawRadio.UseVisualStyleBackColor = true;
            // 
            // todateTextBox
            // 
            this.todateTextBox.Location = new System.Drawing.Point(9, 132);
            this.todateTextBox.Mask = "00/00/0000";
            this.todateTextBox.Name = "todateTextBox";
            this.todateTextBox.Size = new System.Drawing.Size(180, 20);
            this.todateTextBox.TabIndex = 11;
            this.todateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // fromdateTextBox
            // 
            this.fromdateTextBox.Location = new System.Drawing.Point(9, 76);
            this.fromdateTextBox.Mask = "00/00/0000";
            this.fromdateTextBox.Name = "fromdateTextBox";
            this.fromdateTextBox.Size = new System.Drawing.Size(180, 20);
            this.fromdateTextBox.TabIndex = 10;
            this.fromdateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // searchButton
            // 
            this.searchButton.Image = global::GeoViewer.Views.TextView.Properties.Resources.login_16;
            this.searchButton.Location = new System.Drawing.Point(58, 168);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(80, 26);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_View;
            this.searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày";
            // 
            // pictureTab
            // 
            this.pictureTab.Controls.Add(this.pictureGridView);
            this.pictureTab.Location = new System.Drawing.Point(4, 23);
            this.pictureTab.Name = "pictureTab";
            this.pictureTab.Size = new System.Drawing.Size(192, 311);
            this.pictureTab.TabIndex = 2;
            this.pictureTab.Text = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_Picture_View;
            this.pictureTab.UseVisualStyleBackColor = true;
            // 
            // pictureGridView
            // 
            this.pictureGridView.AllowUserToAddRows = false;
            this.pictureGridView.AllowUserToDeleteRows = false;
            this.pictureGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pictureGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PictureViewID,
            this.PictureName});
            this.pictureGridView.Location = new System.Drawing.Point(3, 3);
            this.pictureGridView.MultiSelect = false;
            this.pictureGridView.Name = "pictureGridView";
            this.pictureGridView.ReadOnly = true;
            this.pictureGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pictureGridView.Size = new System.Drawing.Size(186, 303);
            this.pictureGridView.TabIndex = 0;
            // 
            // PictureViewID
            // 
            this.PictureViewID.DataPropertyName = "PictureViewID";
            this.PictureViewID.HeaderText = "Mã";
            this.PictureViewID.Name = "PictureViewID";
            this.PictureViewID.ReadOnly = true;
            this.PictureViewID.Width = 40;
            // 
            // PictureName
            // 
            this.PictureName.DataPropertyName = "Name";
            this.PictureName.HeaderText = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_PictureName;
            this.PictureName.Name = "PictureName";
            this.PictureName.ReadOnly = true;
            this.PictureName.Width = 150;
            // 
            // groupTab
            // 
            this.groupTab.Controls.Add(this.groupGridView);
            this.groupTab.Location = new System.Drawing.Point(4, 23);
            this.groupTab.Name = "groupTab";
            this.groupTab.Padding = new System.Windows.Forms.Padding(3);
            this.groupTab.Size = new System.Drawing.Size(192, 311);
            this.groupTab.TabIndex = 1;
            this.groupTab.Text = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_Group;
            this.groupTab.UseVisualStyleBackColor = true;
            // 
            // groupGridView
            // 
            this.groupGridView.AllowUserToAddRows = false;
            this.groupGridView.AllowUserToDeleteRows = false;
            this.groupGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupID,
            this.GroupName});
            this.groupGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupGridView.Location = new System.Drawing.Point(3, 3);
            this.groupGridView.MultiSelect = false;
            this.groupGridView.Name = "groupGridView";
            this.groupGridView.ReadOnly = true;
            this.groupGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.groupGridView.Size = new System.Drawing.Size(186, 305);
            this.groupGridView.TabIndex = 1;
            // 
            // GroupID
            // 
            this.GroupID.DataPropertyName = "GroupID";
            this.GroupID.HeaderText = "Mã";
            this.GroupID.Name = "GroupID";
            this.GroupID.ReadOnly = true;
            this.GroupID.Width = 40;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Name";
            this.GroupName.HeaderText = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_GroupName;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 150;
            // 
            // sensorTab
            // 
            this.sensorTab.Controls.Add(this.sensorGridView);
            this.sensorTab.Location = new System.Drawing.Point(4, 23);
            this.sensorTab.Name = "sensorTab";
            this.sensorTab.Padding = new System.Windows.Forms.Padding(3);
            this.sensorTab.Size = new System.Drawing.Size(192, 311);
            this.sensorTab.TabIndex = 0;
            this.sensorTab.Text = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_Sensors;
            this.sensorTab.UseVisualStyleBackColor = true;
            // 
            // sensorGridView
            // 
            this.sensorGridView.AllowUserToAddRows = false;
            this.sensorGridView.AllowUserToDeleteRows = false;
            this.sensorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sensorGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SensorID,
            this.SensorName,
            this.LoggerName,
            this.Description});
            this.sensorGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorGridView.Location = new System.Drawing.Point(3, 3);
            this.sensorGridView.Name = "sensorGridView";
            this.sensorGridView.ReadOnly = true;
            this.sensorGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sensorGridView.Size = new System.Drawing.Size(186, 305);
            this.sensorGridView.TabIndex = 0;
            // 
            // choiseTab
            // 
            this.choiseTab.Controls.Add(this.sensorTab);
            this.choiseTab.Controls.Add(this.groupTab);
            this.choiseTab.Controls.Add(this.pictureTab);
            this.choiseTab.Location = new System.Drawing.Point(10, 35);
            this.choiseTab.Name = "choiseTab";
            this.choiseTab.SelectedIndex = 0;
            this.choiseTab.Size = new System.Drawing.Size(200, 338);
            this.choiseTab.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.editGroupsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.closeToolStripMenuItem.Text = "Đóng lại";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.exportToExcelToolStripMenuItem.Text = "Xuất ra file Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // editGroupsToolStripMenuItem
            // 
            this.editGroupsToolStripMenuItem.Name = "editGroupsToolStripMenuItem";
            this.editGroupsToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.editGroupsToolStripMenuItem.Text = "Sửa nhóm";
            this.editGroupsToolStripMenuItem.Click += new System.EventHandler(this.editGroupsToolStripMenuItem_Click);
            // 
            // SensorID
            // 
            this.SensorID.DataPropertyName = "SensorID";
            this.SensorID.HeaderText = "Mã";
            this.SensorID.Name = "SensorID";
            this.SensorID.ReadOnly = true;
            this.SensorID.Width = 40;
            // 
            // SensorName
            // 
            this.SensorName.DataPropertyName = "SensorName";
            this.SensorName.HeaderText = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_SensorName;
            this.SensorName.Name = "SensorName";
            this.SensorName.ReadOnly = true;
            this.SensorName.Width = 150;
            // 
            // LoggerName
            // 
            this.LoggerName.DataPropertyName = "LoggerName";
            this.LoggerName.HeaderText = global::GeoViewer.Views.TextView.Properties.Resources.TextViewForm_InitializeComponent_LoggerName;
            this.LoggerName.Name = "LoggerName";
            this.LoggerName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // TextViewForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.choiseTab);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TextViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text View";
            this.Load += new System.EventHandler(this.TextViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pictureTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureGridView)).EndInit();
            this.groupTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupGridView)).EndInit();
            this.sensorTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sensorGridView)).EndInit();
            this.choiseTab.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox todateTextBox;
        private System.Windows.Forms.MaskedTextBox fromdateTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton calcRadio;
        private System.Windows.Forms.RadioButton rawRadio;
        private System.Windows.Forms.TabPage pictureTab;
        private System.Windows.Forms.DataGridView pictureGridView;
        private System.Windows.Forms.TabPage groupTab;
        private System.Windows.Forms.DataGridView groupGridView;
        private System.Windows.Forms.TabPage sensorTab;
        private System.Windows.Forms.DataGridView sensorGridView;
        private System.Windows.Forms.TabControl choiseTab;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn PictureViewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PictureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGroupsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoggerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}