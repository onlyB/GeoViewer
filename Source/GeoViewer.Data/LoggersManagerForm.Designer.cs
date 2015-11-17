using GeoViewer.Data.Properties;

namespace GeoViewer.Data
{
    partial class LoggersManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggersManagerForm));
            this.loggerGridView = new System.Windows.Forms.DataGridView();
            this.LoggerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoggerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutomaticReadData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReadInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reloadButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.addeditBox = new System.Windows.Forms.GroupBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.Panel();
            this.readNewRadio = new System.Windows.Forms.RadioButton();
            this.readAllRadio = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.readStatusLabel = new System.Windows.Forms.Label();
            this.metaLabel = new System.Windows.Forms.Label();
            this.lastTimeLabel = new System.Windows.Forms.Label();
            this.firstTimeLabel = new System.Windows.Forms.Label();
            this.lastModifyLabel = new System.Windows.Forms.Label();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.recordNumberLabel = new System.Windows.Forms.Label();
            this.sensorCountLabel = new System.Windows.Forms.Label();
            this.intervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.delimiterTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autoReadCheckBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.updateReadStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.loggerGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.addeditBox.SuspendLayout();
            this.infoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // loggerGridView
            // 
            this.loggerGridView.AllowUserToAddRows = false;
            this.loggerGridView.AllowUserToDeleteRows = false;
            this.loggerGridView.AllowUserToOrderColumns = true;
            this.loggerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loggerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoggerID,
            this.LoggerName,
            this.DataPath,
            this.AutomaticReadData,
            this.ReadInterval,
            this.CreatedDate,
            this.CreatedUser,
            this.LastEditedDate,
            this.LastEditedUser});
            this.loggerGridView.Location = new System.Drawing.Point(12, 12);
            this.loggerGridView.MultiSelect = false;
            this.loggerGridView.Name = "loggerGridView";
            this.loggerGridView.ReadOnly = true;
            this.loggerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.loggerGridView.Size = new System.Drawing.Size(660, 180);
            this.loggerGridView.TabIndex = 0;
            this.toolTip1.SetToolTip(this.loggerGridView, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Grid_Hint);
            this.loggerGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loggerGridView_CellClick);
            this.loggerGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loggerGridView_CellDoubleClick);
            // 
            // LoggerID
            // 
            this.LoggerID.DataPropertyName = "LoggerID";
            this.LoggerID.HeaderText = "Mã";
            this.LoggerID.Name = "LoggerID";
            this.LoggerID.ReadOnly = true;
            this.LoggerID.Width = 40;
            // 
            // LoggerName
            // 
            this.LoggerName.DataPropertyName = "Name";
            this.LoggerName.HeaderText = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Column_Name;
            this.LoggerName.Name = "LoggerName";
            this.LoggerName.ReadOnly = true;
            this.LoggerName.Width = 180;
            // 
            // DataPath
            // 
            this.DataPath.DataPropertyName = "DataPath";
            this.DataPath.HeaderText = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Column_Path;
            this.DataPath.Name = "DataPath";
            this.DataPath.ReadOnly = true;
            this.DataPath.Width = 260;
            // 
            // AutomaticReadData
            // 
            this.AutomaticReadData.DataPropertyName = "AutomaticReadData";
            this.AutomaticReadData.HeaderText = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Column_AutoRead;
            this.AutomaticReadData.Name = "AutomaticReadData";
            this.AutomaticReadData.ReadOnly = true;
            this.AutomaticReadData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AutomaticReadData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AutomaticReadData.Width = 95;
            // 
            // ReadInterval
            // 
            this.ReadInterval.DataPropertyName = "ReadInterval";
            this.ReadInterval.HeaderText = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_ReadInterval;
            this.ReadInterval.Name = "ReadInterval";
            this.ReadInterval.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Ngày tạo";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // CreatedUser
            // 
            this.CreatedUser.DataPropertyName = "CreatedUser";
            this.CreatedUser.HeaderText = "Người tạo";
            this.CreatedUser.Name = "CreatedUser";
            this.CreatedUser.ReadOnly = true;
            // 
            // LastEditedDate
            // 
            this.LastEditedDate.DataPropertyName = "LastEditedDate";
            this.LastEditedDate.HeaderText = "Ngày sửa cuối";
            this.LastEditedDate.Name = "LastEditedDate";
            this.LastEditedDate.ReadOnly = true;
            // 
            // LastEditedUser
            // 
            this.LastEditedUser.DataPropertyName = "LastEditedUser";
            this.LastEditedUser.HeaderText = "Người sửa cuối";
            this.LastEditedUser.Name = "LastEditedUser";
            this.LastEditedUser.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reloadButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Location = new System.Drawing.Point(12, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 29);
            this.panel1.TabIndex = 1;
            // 
            // reloadButton
            // 
            this.reloadButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadButton.Image")));
            this.reloadButton.Location = new System.Drawing.Point(574, 3);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(86, 26);
            this.reloadButton.TabIndex = 4;
            this.reloadButton.Text = global::GeoViewer.Data.Properties.Resources.RefreshTable;
            this.reloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.reloadButton, global::GeoViewer.Data.Properties.Resources.Refresh_Hint);
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(176, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 26);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = global::GeoViewer.Data.Properties.Resources.Delete;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.deleteButton, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Delete_Hint);
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.Location = new System.Drawing.Point(88, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 26);
            this.editButton.TabIndex = 2;
            this.editButton.Text = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_EditSensor;
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.editButton, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_EditSensor_Hint);
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::GeoViewer.Data.Properties.Resources.add_16;
            this.addButton.Location = new System.Drawing.Point(0, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 26);
            this.addButton.TabIndex = 1;
            this.addButton.Text = global::GeoViewer.Data.Properties.Resources.Add;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.addButton, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Add_Hint);
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addeditBox
            // 
            this.addeditBox.Controls.Add(this.btnSelectFile);
            this.addeditBox.Controls.Add(this.infoBox);
            this.addeditBox.Controls.Add(this.intervalNumeric);
            this.addeditBox.Controls.Add(this.saveButton);
            this.addeditBox.Controls.Add(this.delimiterTextBox);
            this.addeditBox.Controls.Add(this.label4);
            this.addeditBox.Controls.Add(this.selectFileButton);
            this.addeditBox.Controls.Add(this.pathTextBox);
            this.addeditBox.Controls.Add(this.label1);
            this.addeditBox.Controls.Add(this.autoReadCheckBox);
            this.addeditBox.Controls.Add(this.nameTextBox);
            this.addeditBox.Controls.Add(this.label3);
            this.addeditBox.Controls.Add(this.label2);
            this.addeditBox.Location = new System.Drawing.Point(12, 240);
            this.addeditBox.Name = "addeditBox";
            this.addeditBox.Size = new System.Drawing.Size(660, 260);
            this.addeditBox.TabIndex = 2;
            this.addeditBox.TabStop = false;
            this.addeditBox.Text = "Thêm / Chỉnh sửa";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.Location = new System.Drawing.Point(430, 15);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelectFile.Size = new System.Drawing.Size(105, 23);
            this.btnSelectFile.TabIndex = 13;
            this.btnSelectFile.Text = "Chọn file";
            this.btnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // infoBox
            // 
            this.infoBox.AutoScroll = true;
            this.infoBox.BackColor = System.Drawing.SystemColors.Info;
            this.infoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoBox.Controls.Add(this.readNewRadio);
            this.infoBox.Controls.Add(this.readAllRadio);
            this.infoBox.Controls.Add(this.startButton);
            this.infoBox.Controls.Add(this.readStatusLabel);
            this.infoBox.Controls.Add(this.metaLabel);
            this.infoBox.Controls.Add(this.lastTimeLabel);
            this.infoBox.Controls.Add(this.firstTimeLabel);
            this.infoBox.Controls.Add(this.lastModifyLabel);
            this.infoBox.Controls.Add(this.fileSizeLabel);
            this.infoBox.Controls.Add(this.recordNumberLabel);
            this.infoBox.Controls.Add(this.sensorCountLabel);
            this.infoBox.Location = new System.Drawing.Point(9, 105);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(637, 149);
            this.infoBox.TabIndex = 12;
            // 
            // readNewRadio
            // 
            this.readNewRadio.AutoSize = true;
            this.readNewRadio.Location = new System.Drawing.Point(429, 104);
            this.readNewRadio.Name = "readNewRadio";
            this.readNewRadio.Size = new System.Drawing.Size(98, 18);
            this.readNewRadio.TabIndex = 15;
            this.readNewRadio.TabStop = true;
            this.readNewRadio.Text = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_OnlyNew;
            this.readNewRadio.UseVisualStyleBackColor = true;
            // 
            // readAllRadio
            // 
            this.readAllRadio.AutoSize = true;
            this.readAllRadio.Checked = true;
            this.readAllRadio.Location = new System.Drawing.Point(325, 104);
            this.readAllRadio.Name = "readAllRadio";
            this.readAllRadio.Size = new System.Drawing.Size(103, 18);
            this.readAllRadio.TabIndex = 14;
            this.readAllRadio.TabStop = true;
            this.readAllRadio.Text = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_AllFile;
            this.readAllRadio.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.Location = new System.Drawing.Point(533, 91);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(72, 44);
            this.startButton.TabIndex = 13;
            this.startButton.Text = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Read;
            this.startButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.startButton, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Begin_Read);
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // readStatusLabel
            // 
            this.readStatusLabel.AutoSize = true;
            this.readStatusLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.readStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.readStatusLabel.Location = new System.Drawing.Point(3, 102);
            this.readStatusLabel.Name = "readStatusLabel";
            this.readStatusLabel.Padding = new System.Windows.Forms.Padding(4);
            this.readStatusLabel.Size = new System.Drawing.Size(112, 22);
            this.readStatusLabel.TabIndex = 9;
            this.readStatusLabel.Text = "Trạng thái đọc: {0}";
            // 
            // metaLabel
            // 
            this.metaLabel.AutoSize = true;
            this.metaLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.metaLabel.Location = new System.Drawing.Point(11, 11);
            this.metaLabel.Name = "metaLabel";
            this.metaLabel.Size = new System.Drawing.Size(50, 14);
            this.metaLabel.TabIndex = 8;
            this.metaLabel.Text = "Meta: {0}";
            // 
            // lastTimeLabel
            // 
            this.lastTimeLabel.AutoSize = true;
            this.lastTimeLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lastTimeLabel.Location = new System.Drawing.Point(232, 68);
            this.lastTimeLabel.Name = "lastTimeLabel";
            this.lastTimeLabel.Size = new System.Drawing.Size(86, 14);
            this.lastTimeLabel.TabIndex = 7;
            this.lastTimeLabel.Text = "Bản ghi cuối: {0}";
            // 
            // firstTimeLabel
            // 
            this.firstTimeLabel.AutoSize = true;
            this.firstTimeLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstTimeLabel.Location = new System.Drawing.Point(11, 68);
            this.firstTimeLabel.Name = "firstTimeLabel";
            this.firstTimeLabel.Size = new System.Drawing.Size(84, 14);
            this.firstTimeLabel.TabIndex = 6;
            this.firstTimeLabel.Text = "Bản ghi đầu: {0}";
            // 
            // lastModifyLabel
            // 
            this.lastModifyLabel.AutoSize = true;
            this.lastModifyLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lastModifyLabel.Location = new System.Drawing.Point(426, 68);
            this.lastModifyLabel.Name = "lastModifyLabel";
            this.lastModifyLabel.Size = new System.Drawing.Size(89, 14);
            this.lastModifyLabel.TabIndex = 5;
            this.lastModifyLabel.Text = "Lần đọc cuối: {0}";
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileSizeLabel.Location = new System.Drawing.Point(426, 39);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(127, 14);
            this.fileSizeLabel.TabIndex = 4;
            this.fileSizeLabel.Text = "Kích thước file: {0} bytes";
            // 
            // recordNumberLabel
            // 
            this.recordNumberLabel.AutoSize = true;
            this.recordNumberLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.recordNumberLabel.Location = new System.Drawing.Point(232, 39);
            this.recordNumberLabel.Name = "recordNumberLabel";
            this.recordNumberLabel.Size = new System.Drawing.Size(78, 14);
            this.recordNumberLabel.TabIndex = 2;
            this.recordNumberLabel.Text = "Số bản ghi: {0}";
            // 
            // sensorCountLabel
            // 
            this.sensorCountLabel.AutoSize = true;
            this.sensorCountLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sensorCountLabel.Location = new System.Drawing.Point(11, 39);
            this.sensorCountLabel.Name = "sensorCountLabel";
            this.sensorCountLabel.Size = new System.Drawing.Size(77, 14);
            this.sensorCountLabel.TabIndex = 0;
            this.sensorCountLabel.Text = "Số sensor: {0}";
            // 
            // intervalNumeric
            // 
            this.intervalNumeric.Location = new System.Drawing.Point(277, 74);
            this.intervalNumeric.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.intervalNumeric.Name = "intervalNumeric";
            this.intervalNumeric.Size = new System.Drawing.Size(60, 20);
            this.intervalNumeric.TabIndex = 11;
            // 
            // saveButton
            // 
            this.saveButton.Image = global::GeoViewer.Data.Properties.Resources.disk_16;
            this.saveButton.Location = new System.Drawing.Point(574, 42);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(72, 52);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = global::GeoViewer.Data.Properties.Resources.Save;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.saveButton, "Lưu dữ liệu");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // delimiterTextBox
            // 
            this.delimiterTextBox.Location = new System.Drawing.Point(511, 73);
            this.delimiterTextBox.MaxLength = 3;
            this.delimiterTextBox.Name = "delimiterTextBox";
            this.delimiterTextBox.Size = new System.Drawing.Size(60, 20);
            this.delimiterTextBox.TabIndex = 9;
            this.toolTip1.SetToolTip(this.delimiterTextBox, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Delimiter_Hint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dấu phân cách";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Image = ((System.Drawing.Image)(resources.GetObject("selectFileButton.Image")));
            this.selectFileButton.Location = new System.Drawing.Point(541, 15);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectFileButton.Size = new System.Drawing.Size(105, 23);
            this.selectFileButton.TabIndex = 6;
            this.selectFileButton.Text = "Chọn thư mục";
            this.selectFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(71, 16);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(353, 20);
            this.pathTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nguồn";
            // 
            // autoReadCheckBox
            // 
            this.autoReadCheckBox.AutoSize = true;
            this.autoReadCheckBox.Location = new System.Drawing.Point(9, 75);
            this.autoReadCheckBox.Name = "autoReadCheckBox";
            this.autoReadCheckBox.Size = new System.Drawing.Size(87, 18);
            this.autoReadCheckBox.TabIndex = 4;
            this.autoReadCheckBox.Text = global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_Column_AutoRead;
            this.toolTip1.SetToolTip(this.autoReadCheckBox, global::GeoViewer.Data.Properties.Resources.LoggersManagerForm_AutoRead_Hint);
            this.autoReadCheckBox.UseVisualStyleBackColor = true;
            this.autoReadCheckBox.CheckedChanged += new System.EventHandler(this.autoReadCheckBox_CheckedChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(71, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(500, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chu kỳ đọc(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đường dẫn";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = global::GeoViewer.Data.Properties.Resources.ToolTip_Title;
            // 
            // updateReadStatusTimer
            // 
            this.updateReadStatusTimer.Enabled = true;
            this.updateReadStatusTimer.Interval = 1000;
            this.updateReadStatusTimer.Tick += new System.EventHandler(this.updateReadStatusTimer_Tick);
            // 
            // LoggersManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 512);
            this.Controls.Add(this.addeditBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loggerGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoggersManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nguồn dữ liệu";
            this.Load += new System.EventHandler(this.LoggersManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loggerGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.addeditBox.ResumeLayout(false);
            this.addeditBox.PerformLayout();
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView loggerGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.GroupBox addeditBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox delimiterTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.CheckBox autoReadCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog dataOpenFileDialog;
        private System.Windows.Forms.NumericUpDown intervalNumeric;
        private System.Windows.Forms.Panel infoBox;
        private System.Windows.Forms.Label sensorCountLabel;
        private System.Windows.Forms.Label lastModifyLabel;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.Label recordNumberLabel;
        private System.Windows.Forms.Label lastTimeLabel;
        private System.Windows.Forms.Label firstTimeLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label readStatusLabel;
        private System.Windows.Forms.Label metaLabel;
        private System.Windows.Forms.Timer updateReadStatusTimer;
        private System.Windows.Forms.RadioButton readNewRadio;
        private System.Windows.Forms.RadioButton readAllRadio;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoggerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoggerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AutomaticReadData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedUser;
    }
}