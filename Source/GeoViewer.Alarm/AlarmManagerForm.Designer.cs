using GeoViewer.Alarm.Properties;

namespace GeoViewer.Alarm
{
    partial class AlarmManagerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmManagerForm));
            this.logGridView = new System.Windows.Forms.DataGridView();
            this.IsEnded = new System.Windows.Forms.DataGridViewImageColumn();
            this.AlarmLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sensor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAlarmDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndAlarmDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markAsReadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markEndedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markUnendedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.todateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fromdateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.runningRadio = new System.Windows.Forms.RadioButton();
            this.endedRadio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sensorCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).BeginInit();
            this.gridContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logGridView
            // 
            this.logGridView.AllowUserToAddRows = false;
            this.logGridView.AllowUserToDeleteRows = false;
            this.logGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsEnded,
            this.AlarmLogID,
            this.SensorID,
            this.Sensor,
            this.LogTitle,
            this.LogNote,
            this.CalcValue,
            this.StartAlarmDatetime,
            this.EndAlarmDatetime,
            this.LastEditedDate,
            this.LastEditedUser,
            this.ProjectID});
            this.logGridView.ContextMenuStrip = this.gridContextMenu;
            this.logGridView.Location = new System.Drawing.Point(227, 12);
            this.logGridView.Name = "logGridView";
            this.logGridView.ReadOnly = true;
            this.logGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.logGridView.Size = new System.Drawing.Size(745, 588);
            this.logGridView.TabIndex = 0;
            this.logGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logGridView_CellClick);
            this.logGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logGridView_CellDoubleClick);
            this.logGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.logGridView_CellFormatting);
            // 
            // IsEnded
            // 
            this.IsEnded.DataPropertyName = "IsEnded";
            this.IsEnded.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_IsEnded;
            this.IsEnded.Name = "IsEnded";
            this.IsEnded.ReadOnly = true;
            this.IsEnded.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsEnded.Width = 50;
            // 
            // AlarmLogID
            // 
            this.AlarmLogID.DataPropertyName = "AlarmLogID";
            this.AlarmLogID.HeaderText = "Mã";
            this.AlarmLogID.Name = "AlarmLogID";
            this.AlarmLogID.ReadOnly = true;
            this.AlarmLogID.Width = 40;
            // 
            // SensorID
            // 
            this.SensorID.DataPropertyName = "SensorID";
            this.SensorID.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Sensor_ID;
            this.SensorID.Name = "SensorID";
            this.SensorID.ReadOnly = true;
            this.SensorID.Width = 40;
            // 
            // Sensor
            // 
            this.Sensor.DataPropertyName = "Sensor";
            this.Sensor.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Sensor;
            this.Sensor.Name = "Sensor";
            this.Sensor.ReadOnly = true;
            this.Sensor.Visible = false;
            // 
            // LogTitle
            // 
            this.LogTitle.DataPropertyName = "Title";
            this.LogTitle.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_Title;
            this.LogTitle.Name = "LogTitle";
            this.LogTitle.ReadOnly = true;
            this.LogTitle.Width = 250;
            // 
            // LogNote
            // 
            this.LogNote.DataPropertyName = "Note";
            this.LogNote.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Note;
            this.LogNote.Name = "LogNote";
            this.LogNote.ReadOnly = true;
            // 
            // CalcValue
            // 
            this.CalcValue.DataPropertyName = "CalcValue";
            this.CalcValue.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_CalcValue;
            this.CalcValue.Name = "CalcValue";
            this.CalcValue.ReadOnly = true;
            this.CalcValue.Width = 80;
            // 
            // StartAlarmDatetime
            // 
            this.StartAlarmDatetime.DataPropertyName = "StartAlarmDatetime";
            this.StartAlarmDatetime.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_StartDate;
            this.StartAlarmDatetime.Name = "StartAlarmDatetime";
            this.StartAlarmDatetime.ReadOnly = true;
            this.StartAlarmDatetime.ToolTipText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_StartDate_Hint;
            // 
            // EndAlarmDatetime
            // 
            this.EndAlarmDatetime.DataPropertyName = "EndAlarmDatetime";
            this.EndAlarmDatetime.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_EndDate;
            this.EndAlarmDatetime.Name = "EndAlarmDatetime";
            this.EndAlarmDatetime.ReadOnly = true;
            this.EndAlarmDatetime.ToolTipText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_EndDate_Hint;
            // 
            // LastEditedDate
            // 
            this.LastEditedDate.DataPropertyName = "LastEditedDate";
            this.LastEditedDate.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_LastEditedDate;
            this.LastEditedDate.Name = "LastEditedDate";
            this.LastEditedDate.ReadOnly = true;
            // 
            // LastEditedUser
            // 
            this.LastEditedUser.DataPropertyName = "LastEditedUser";
            this.LastEditedUser.HeaderText = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Column_LastEditedUSer;
            this.LastEditedUser.Name = "LastEditedUser";
            this.LastEditedUser.ReadOnly = true;
            // 
            // ProjectID
            // 
            this.ProjectID.DataPropertyName = "ProjectID";
            this.ProjectID.HeaderText = "Mã dự án";
            this.ProjectID.Name = "ProjectID";
            this.ProjectID.ReadOnly = true;
            // 
            // gridContextMenu
            // 
            this.gridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsReadMenuItem,
            this.markEndedMenuItem,
            this.markUnendedMenuItem,
            this.deleteMenuItem});
            this.gridContextMenu.Name = "gridContextMenu";
            this.gridContextMenu.Size = new System.Drawing.Size(253, 92);
            // 
            // markAsReadMenuItem
            // 
            this.markAsReadMenuItem.Name = "markAsReadMenuItem";
            this.markAsReadMenuItem.Size = new System.Drawing.Size(252, 22);
            this.markAsReadMenuItem.Text = "Đánh dấu là đã xem";
            this.markAsReadMenuItem.Click += new System.EventHandler(this.markAsReadMenuItem_Click);
            // 
            // markEndedMenuItem
            // 
            this.markEndedMenuItem.Name = "markEndedMenuItem";
            this.markEndedMenuItem.Size = new System.Drawing.Size(252, 22);
            this.markEndedMenuItem.Text = "Đánh dấu cảnh báo kết thúc";
            this.markEndedMenuItem.Click += new System.EventHandler(this.markEndedMenuItem_Click);
            // 
            // markUnendedMenuItem
            // 
            this.markUnendedMenuItem.Name = "markUnendedMenuItem";
            this.markUnendedMenuItem.Size = new System.Drawing.Size(252, 22);
            this.markUnendedMenuItem.Text = "Đánh dấu cảnh báo chưa kết thúc";
            this.markUnendedMenuItem.Click += new System.EventHandler(this.markUnendedMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(252, 22);
            this.deleteMenuItem.Text = "Xóa";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.todateTextBox);
            this.groupBox1.Controls.Add(this.fromdateTextBox);
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.runningRadio);
            this.groupBox1.Controls.Add(this.endedRadio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sensorCombo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xem theo tùy chọn";
            // 
            // todateTextBox
            // 
            this.todateTextBox.Location = new System.Drawing.Point(9, 150);
            this.todateTextBox.Mask = "00/00/0000";
            this.todateTextBox.Name = "todateTextBox";
            this.todateTextBox.Size = new System.Drawing.Size(180, 20);
            this.todateTextBox.TabIndex = 11;
            this.toolTip1.SetToolTip(this.todateTextBox, global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_ToDate_Hint);
            this.todateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // fromdateTextBox
            // 
            this.fromdateTextBox.Location = new System.Drawing.Point(9, 95);
            this.fromdateTextBox.Mask = "00/00/0000";
            this.fromdateTextBox.Name = "fromdateTextBox";
            this.fromdateTextBox.Size = new System.Drawing.Size(180, 20);
            this.fromdateTextBox.TabIndex = 10;
            this.toolTip1.SetToolTip(this.fromdateTextBox, global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_ToDate_Hint);
            this.fromdateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // refreshButton
            // 
            this.refreshButton.Image = global::GeoViewer.Alarm.Properties.Resources.refresh_16;
            this.refreshButton.Location = new System.Drawing.Point(109, 233);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(80, 26);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_UnSearch;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.refreshButton, global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Refresh_Hint);
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Image = global::GeoViewer.Alarm.Properties.Resources.search_16;
            this.searchButton.Location = new System.Drawing.Point(9, 233);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(80, 26);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Search;
            this.searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // runningRadio
            // 
            this.runningRadio.AutoSize = true;
            this.runningRadio.Location = new System.Drawing.Point(99, 191);
            this.runningRadio.Name = "runningRadio";
            this.runningRadio.Size = new System.Drawing.Size(87, 18);
            this.runningRadio.TabIndex = 7;
            this.runningRadio.TabStop = true;
            this.runningRadio.Text = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Running;
            this.runningRadio.UseVisualStyleBackColor = true;
            // 
            // endedRadio
            // 
            this.endedRadio.AutoSize = true;
            this.endedRadio.Location = new System.Drawing.Point(9, 191);
            this.endedRadio.Name = "endedRadio";
            this.endedRadio.Size = new System.Drawing.Size(80, 18);
            this.endedRadio.TabIndex = 6;
            this.endedRadio.TabStop = true;
            this.endedRadio.Text = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Ended;
            this.endedRadio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cảm biến";
            // 
            // sensorCombo
            // 
            this.sensorCombo.FormattingEnabled = true;
            this.sensorCombo.Location = new System.Drawing.Point(9, 34);
            this.sensorCombo.Name = "sensorCombo";
            this.sensorCombo.Size = new System.Drawing.Size(180, 22);
            this.sensorCombo.TabIndex = 0;
            this.toolTip1.SetToolTip(this.sensorCombo, global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Sensor_Hint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.noteTextBox);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 295);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sửa / Xóa";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Image = global::GeoViewer.Alarm.Properties.Resources.disk_16;
            this.saveButton.Location = new System.Drawing.Point(9, 31);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Save;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.saveButton, global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Save_Hint);
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ghi chú";
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(9, 102);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(180, 170);
            this.noteTextBox.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::GeoViewer.Alarm.Properties.Resources.delete_16;
            this.deleteButton.Location = new System.Drawing.Point(109, 31);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 26);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Delete;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.deleteButton, global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_Delete_Hint);
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = global::GeoViewer.Alarm.Properties.Resources.AlarmManagerForm_ToolTipTitle;
            // 
            // AlarmManagerForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlarmManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử cảnh báo";
            this.Load += new System.EventHandler(this.AlarmManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).EndInit();
            this.gridContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton runningRadio;
        private System.Windows.Forms.RadioButton endedRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sensorCombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MaskedTextBox todateTextBox;
        private System.Windows.Forms.MaskedTextBox fromdateTextBox;
        private System.Windows.Forms.ContextMenuStrip gridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem markAsReadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markEndedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markUnendedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn IsEnded;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlarmLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sensor;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalcValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAlarmDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndAlarmDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
    }
}