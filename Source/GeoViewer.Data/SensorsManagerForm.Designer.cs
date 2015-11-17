using GeoViewer.Data.Properties;

namespace GeoViewer.Data
{
    partial class SensorsManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorsManagerForm));
            this.sensorGridView = new System.Windows.Forms.DataGridView();
            this.addEditTabs = new System.Windows.Forms.TabControl();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.updateInfo = new System.Windows.Forms.CheckBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.columnIndexNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.calcTab = new System.Windows.Forms.TabPage();
            this.updateCalc = new System.Windows.Forms.CheckBox();
            this.caclSelectTabs = new System.Windows.Forms.TabControl();
            this.linearTab = new System.Windows.Forms.TabPage();
            this.linear_C1 = new System.Windows.Forms.TextBox();
            this.linear_C0 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.arcToLengthTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.arc_Radian = new System.Windows.Forms.RadioButton();
            this.arc_Degree = new System.Windows.Forms.RadioButton();
            this.arc_Length = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.polynomialTab = new System.Windows.Forms.TabPage();
            this.poly_C5 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.poly_C4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.poly_C3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.poly_C2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.poly_C1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.poly_C0 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.temperatureCompTab = new System.Windows.Forms.TabPage();
            this.temp_TcClearButton = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.temp_Tc = new System.Windows.Forms.ComboBox();
            this.temp_Ti = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.temp_Tk = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.temp_C5 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.temp_C4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.temp_C3 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.temp_C2 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.temp_C1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.temp_C0 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.vwLinearTab = new System.Windows.Forms.TabPage();
            this.vwLinear_Bc_Clear = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.vwLinear_Bc = new System.Windows.Forms.ComboBox();
            this.vwLinear_Tc_Clear = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.vwLinear_Tc = new System.Windows.Forms.ComboBox();
            this.vwLinear_E = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.vwLinear_D = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.vwLinear_Lm = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.vwLinear_Bi = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.vwLinear_Ti = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.vwLinear_Tk = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.vwLinear_Li = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.vwLinear_CK = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.vwPoly = new System.Windows.Forms.TabPage();
            this.vwPoly_Lm = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.vwPoly_Bc_Clear = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.vwPoly_Bc = new System.Windows.Forms.ComboBox();
            this.vwPoly_Tc_Clear = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.vwPoly_Tc = new System.Windows.Forms.ComboBox();
            this.vwPoly_E = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.vwPoly_D = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.vwPoly_Bi = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.vwPoly_Ti = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.vwPoly_Tk = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.vwPoly_C = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.vwPoly_B = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.vwPoly_A = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.tabUserDefine = new System.Windows.Forms.TabPage();
            this.btnTestExpression = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.txtUserExpression = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.alarmTab = new System.Windows.Forms.TabPage();
            this.updateAlarm = new System.Windows.Forms.CheckBox();
            this.unitLabel2 = new System.Windows.Forms.Label();
            this.unitLabel1 = new System.Windows.Forms.Label();
            this.maxAlarmTextBox = new System.Windows.Forms.TextBox();
            this.minAlarmTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.enableAlarmCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recalcButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SensorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlarmEnabled = new System.Windows.Forms.DataGridViewImageColumn();
            this.AlarmFlag = new System.Windows.Forms.DataGridViewImageColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sensorGridView)).BeginInit();
            this.addEditTabs.SuspendLayout();
            this.infoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnIndexNumeric)).BeginInit();
            this.calcTab.SuspendLayout();
            this.caclSelectTabs.SuspendLayout();
            this.linearTab.SuspendLayout();
            this.arcToLengthTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.polynomialTab.SuspendLayout();
            this.temperatureCompTab.SuspendLayout();
            this.vwLinearTab.SuspendLayout();
            this.vwPoly.SuspendLayout();
            this.tabUserDefine.SuspendLayout();
            this.alarmTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sensorGridView
            // 
            this.sensorGridView.AllowUserToAddRows = false;
            this.sensorGridView.AllowUserToDeleteRows = false;
            this.sensorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sensorGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SensorID,
            this.ColumnIndex,
            this.SensorName,
            this.Unit,
            this.AlarmEnabled,
            this.AlarmFlag,
            this.CreatedDate,
            this.CreatedUser,
            this.LastEditedDate,
            this.LastEditedUser});
            this.sensorGridView.Location = new System.Drawing.Point(12, 12);
            this.sensorGridView.Name = "sensorGridView";
            this.sensorGridView.ReadOnly = true;
            this.sensorGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sensorGridView.Size = new System.Drawing.Size(660, 244);
            this.sensorGridView.TabIndex = 0;
            this.sensorGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sensorGridView_CellDoubleClick);
            this.sensorGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.sensorGridView_CellFormatting);
            // 
            // addEditTabs
            // 
            this.addEditTabs.Controls.Add(this.infoTab);
            this.addEditTabs.Controls.Add(this.calcTab);
            this.addEditTabs.Controls.Add(this.alarmTab);
            this.addEditTabs.Enabled = false;
            this.addEditTabs.Location = new System.Drawing.Point(12, 290);
            this.addEditTabs.Name = "addEditTabs";
            this.addEditTabs.SelectedIndex = 0;
            this.addEditTabs.Size = new System.Drawing.Size(660, 310);
            this.addEditTabs.TabIndex = 1;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.updateInfo);
            this.infoTab.Controls.Add(this.descriptionTextBox);
            this.infoTab.Controls.Add(this.unitTextBox);
            this.infoTab.Controls.Add(this.label3);
            this.infoTab.Controls.Add(this.nameTextBox);
            this.infoTab.Controls.Add(this.label2);
            this.infoTab.Controls.Add(this.columnIndexNumeric);
            this.infoTab.Controls.Add(this.label1);
            this.infoTab.Location = new System.Drawing.Point(4, 23);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(652, 283);
            this.infoTab.TabIndex = 0;
            this.infoTab.Text = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_InfoTab;
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // updateInfo
            // 
            this.updateInfo.AutoSize = true;
            this.updateInfo.Location = new System.Drawing.Point(533, 6);
            this.updateInfo.Name = "updateInfo";
            this.updateInfo.Size = new System.Drawing.Size(113, 18);
            this.updateInfo.TabIndex = 7;
            this.updateInfo.Text = "Cập nhật thông tin";
            this.updateInfo.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(42, 158);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(567, 109);
            this.descriptionTextBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.descriptionTextBox, global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_Description);
            // 
            // unitTextBox
            // 
            this.unitTextBox.Location = new System.Drawing.Point(140, 117);
            this.unitTextBox.MaxLength = 50;
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(120, 20);
            this.unitTextBox.TabIndex = 5;
            this.unitTextBox.Leave += new System.EventHandler(this.unitTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đơn vị đo";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(140, 74);
            this.nameTextBox.MaxLength = 200;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(469, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên cảm biến";
            // 
            // columnIndexNumeric
            // 
            this.columnIndexNumeric.Location = new System.Drawing.Point(140, 31);
            this.columnIndexNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.columnIndexNumeric.Name = "columnIndexNumeric";
            this.columnIndexNumeric.Size = new System.Drawing.Size(120, 20);
            this.columnIndexNumeric.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thứ tự cột";
            // 
            // calcTab
            // 
            this.calcTab.Controls.Add(this.updateCalc);
            this.calcTab.Controls.Add(this.caclSelectTabs);
            this.calcTab.Location = new System.Drawing.Point(4, 23);
            this.calcTab.Name = "calcTab";
            this.calcTab.Padding = new System.Windows.Forms.Padding(3);
            this.calcTab.Size = new System.Drawing.Size(652, 283);
            this.calcTab.TabIndex = 1;
            this.calcTab.Text = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_CalcTab;
            this.calcTab.UseVisualStyleBackColor = true;
            // 
            // updateCalc
            // 
            this.updateCalc.AutoSize = true;
            this.updateCalc.Location = new System.Drawing.Point(533, 6);
            this.updateCalc.Name = "updateCalc";
            this.updateCalc.Size = new System.Drawing.Size(113, 18);
            this.updateCalc.TabIndex = 8;
            this.updateCalc.Text = "Cập nhật tính toán";
            this.updateCalc.UseVisualStyleBackColor = true;
            // 
            // caclSelectTabs
            // 
            this.caclSelectTabs.Controls.Add(this.linearTab);
            this.caclSelectTabs.Controls.Add(this.arcToLengthTab);
            this.caclSelectTabs.Controls.Add(this.polynomialTab);
            this.caclSelectTabs.Controls.Add(this.temperatureCompTab);
            this.caclSelectTabs.Controls.Add(this.vwLinearTab);
            this.caclSelectTabs.Controls.Add(this.vwPoly);
            this.caclSelectTabs.Controls.Add(this.tabUserDefine);
            this.caclSelectTabs.Location = new System.Drawing.Point(19, 20);
            this.caclSelectTabs.Name = "caclSelectTabs";
            this.caclSelectTabs.SelectedIndex = 0;
            this.caclSelectTabs.Size = new System.Drawing.Size(616, 245);
            this.caclSelectTabs.TabIndex = 0;
            // 
            // linearTab
            // 
            this.linearTab.Controls.Add(this.linear_C1);
            this.linearTab.Controls.Add(this.linear_C0);
            this.linearTab.Controls.Add(this.label8);
            this.linearTab.Controls.Add(this.label7);
            this.linearTab.Controls.Add(this.label6);
            this.linearTab.Location = new System.Drawing.Point(4, 23);
            this.linearTab.Name = "linearTab";
            this.linearTab.Padding = new System.Windows.Forms.Padding(3);
            this.linearTab.Size = new System.Drawing.Size(608, 218);
            this.linearTab.TabIndex = 0;
            this.linearTab.Text = "Tuyến tính";
            this.linearTab.UseVisualStyleBackColor = true;
            // 
            // linear_C1
            // 
            this.linear_C1.Location = new System.Drawing.Point(178, 86);
            this.linear_C1.MaxLength = 20;
            this.linear_C1.Name = "linear_C1";
            this.linear_C1.Size = new System.Drawing.Size(110, 20);
            this.linear_C1.TabIndex = 6;
            // 
            // linear_C0
            // 
            this.linear_C0.Location = new System.Drawing.Point(40, 86);
            this.linear_C0.MaxLength = 20;
            this.linear_C0.Name = "linear_C0";
            this.linear_C0.Size = new System.Drawing.Size(110, 20);
            this.linear_C0.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "C1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "C0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(40, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Xo = C0 + C1*Vi";
            // 
            // arcToLengthTab
            // 
            this.arcToLengthTab.Controls.Add(this.groupBox1);
            this.arcToLengthTab.Controls.Add(this.arc_Length);
            this.arcToLengthTab.Controls.Add(this.label10);
            this.arcToLengthTab.Controls.Add(this.label9);
            this.arcToLengthTab.Location = new System.Drawing.Point(4, 23);
            this.arcToLengthTab.Name = "arcToLengthTab";
            this.arcToLengthTab.Padding = new System.Windows.Forms.Padding(3);
            this.arcToLengthTab.Size = new System.Drawing.Size(608, 218);
            this.arcToLengthTab.TabIndex = 1;
            this.arcToLengthTab.Text = "Lượng giác";
            this.arcToLengthTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.arc_Radian);
            this.groupBox1.Controls.Add(this.arc_Degree);
            this.groupBox1.Location = new System.Drawing.Point(277, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 81);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tính theo";
            // 
            // arc_Radian
            // 
            this.arc_Radian.AutoSize = true;
            this.arc_Radian.Location = new System.Drawing.Point(21, 48);
            this.arc_Radian.Name = "arc_Radian";
            this.arc_Radian.Size = new System.Drawing.Size(58, 18);
            this.arc_Radian.TabIndex = 1;
            this.arc_Radian.TabStop = true;
            this.arc_Radian.Text = "Radian";
            this.arc_Radian.UseVisualStyleBackColor = true;
            // 
            // arc_Degree
            // 
            this.arc_Degree.AutoSize = true;
            this.arc_Degree.Checked = true;
            this.arc_Degree.Location = new System.Drawing.Point(21, 24);
            this.arc_Degree.Name = "arc_Degree";
            this.arc_Degree.Size = new System.Drawing.Size(60, 18);
            this.arc_Degree.TabIndex = 0;
            this.arc_Degree.TabStop = true;
            this.arc_Degree.Text = "Degree";
            this.arc_Degree.UseVisualStyleBackColor = true;
            // 
            // arc_Length
            // 
            this.arc_Length.Location = new System.Drawing.Point(52, 116);
            this.arc_Length.MaxLength = 20;
            this.arc_Length.Name = "arc_Length";
            this.arc_Length.Size = new System.Drawing.Size(110, 20);
            this.arc_Length.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 14);
            this.label10.TabIndex = 6;
            this.label10.Text = "Length";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(52, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "L = Length * Sin(Vi)";
            // 
            // polynomialTab
            // 
            this.polynomialTab.Controls.Add(this.poly_C5);
            this.polynomialTab.Controls.Add(this.label17);
            this.polynomialTab.Controls.Add(this.poly_C4);
            this.polynomialTab.Controls.Add(this.label16);
            this.polynomialTab.Controls.Add(this.poly_C3);
            this.polynomialTab.Controls.Add(this.label15);
            this.polynomialTab.Controls.Add(this.poly_C2);
            this.polynomialTab.Controls.Add(this.label14);
            this.polynomialTab.Controls.Add(this.poly_C1);
            this.polynomialTab.Controls.Add(this.label13);
            this.polynomialTab.Controls.Add(this.poly_C0);
            this.polynomialTab.Controls.Add(this.label11);
            this.polynomialTab.Controls.Add(this.label12);
            this.polynomialTab.Location = new System.Drawing.Point(4, 23);
            this.polynomialTab.Name = "polynomialTab";
            this.polynomialTab.Size = new System.Drawing.Size(608, 218);
            this.polynomialTab.TabIndex = 2;
            this.polynomialTab.Text = "Hàm mũ";
            this.polynomialTab.UseVisualStyleBackColor = true;
            // 
            // poly_C5
            // 
            this.poly_C5.Location = new System.Drawing.Point(503, 118);
            this.poly_C5.MaxLength = 20;
            this.poly_C5.Name = "poly_C5";
            this.poly_C5.Size = new System.Drawing.Size(75, 20);
            this.poly_C5.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(500, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 14);
            this.label17.TabIndex = 17;
            this.label17.Text = "C5";
            // 
            // poly_C4
            // 
            this.poly_C4.Location = new System.Drawing.Point(410, 118);
            this.poly_C4.MaxLength = 20;
            this.poly_C4.Name = "poly_C4";
            this.poly_C4.Size = new System.Drawing.Size(75, 20);
            this.poly_C4.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(408, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 14);
            this.label16.TabIndex = 15;
            this.label16.Text = "C4";
            // 
            // poly_C3
            // 
            this.poly_C3.Location = new System.Drawing.Point(315, 118);
            this.poly_C3.MaxLength = 20;
            this.poly_C3.Name = "poly_C3";
            this.poly_C3.Size = new System.Drawing.Size(75, 20);
            this.poly_C3.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(315, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 14);
            this.label15.TabIndex = 13;
            this.label15.Text = "C3";
            // 
            // poly_C2
            // 
            this.poly_C2.Location = new System.Drawing.Point(221, 118);
            this.poly_C2.MaxLength = 20;
            this.poly_C2.Name = "poly_C2";
            this.poly_C2.Size = new System.Drawing.Size(75, 20);
            this.poly_C2.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(222, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 14);
            this.label14.TabIndex = 11;
            this.label14.Text = "C2";
            // 
            // poly_C1
            // 
            this.poly_C1.Location = new System.Drawing.Point(126, 118);
            this.poly_C1.MaxLength = 20;
            this.poly_C1.Name = "poly_C1";
            this.poly_C1.Size = new System.Drawing.Size(75, 20);
            this.poly_C1.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(126, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 14);
            this.label13.TabIndex = 9;
            this.label13.Text = "C1";
            // 
            // poly_C0
            // 
            this.poly_C0.Location = new System.Drawing.Point(31, 118);
            this.poly_C0.MaxLength = 20;
            this.poly_C0.Name = "poly_C0";
            this.poly_C0.Size = new System.Drawing.Size(75, 20);
            this.poly_C0.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "C0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(28, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(425, 18);
            this.label12.TabIndex = 6;
            this.label12.Text = "Xo = C0 + C1*Vi + C2*Vi^2 + C3*Vi^3 + C4*Vi^4 + C5*Vi^5";
            // 
            // temperatureCompTab
            // 
            this.temperatureCompTab.Controls.Add(this.temp_TcClearButton);
            this.temperatureCompTab.Controls.Add(this.label28);
            this.temperatureCompTab.Controls.Add(this.temp_Tc);
            this.temperatureCompTab.Controls.Add(this.temp_Ti);
            this.temperatureCompTab.Controls.Add(this.label26);
            this.temperatureCompTab.Controls.Add(this.temp_Tk);
            this.temperatureCompTab.Controls.Add(this.label27);
            this.temperatureCompTab.Controls.Add(this.label25);
            this.temperatureCompTab.Controls.Add(this.temp_C5);
            this.temperatureCompTab.Controls.Add(this.label18);
            this.temperatureCompTab.Controls.Add(this.temp_C4);
            this.temperatureCompTab.Controls.Add(this.label19);
            this.temperatureCompTab.Controls.Add(this.temp_C3);
            this.temperatureCompTab.Controls.Add(this.label20);
            this.temperatureCompTab.Controls.Add(this.temp_C2);
            this.temperatureCompTab.Controls.Add(this.label21);
            this.temperatureCompTab.Controls.Add(this.temp_C1);
            this.temperatureCompTab.Controls.Add(this.label22);
            this.temperatureCompTab.Controls.Add(this.temp_C0);
            this.temperatureCompTab.Controls.Add(this.label23);
            this.temperatureCompTab.Controls.Add(this.label24);
            this.temperatureCompTab.Location = new System.Drawing.Point(4, 23);
            this.temperatureCompTab.Name = "temperatureCompTab";
            this.temperatureCompTab.Size = new System.Drawing.Size(608, 218);
            this.temperatureCompTab.TabIndex = 3;
            this.temperatureCompTab.Text = "Hàm nhiệt độ";
            this.temperatureCompTab.UseVisualStyleBackColor = true;
            // 
            // temp_TcClearButton
            // 
            this.temp_TcClearButton.Location = new System.Drawing.Point(388, 164);
            this.temp_TcClearButton.Name = "temp_TcClearButton";
            this.temp_TcClearButton.Size = new System.Drawing.Size(75, 23);
            this.temp_TcClearButton.TabIndex = 39;
            this.temp_TcClearButton.Text = "Bỏ trống";
            this.temp_TcClearButton.UseVisualStyleBackColor = true;
            this.temp_TcClearButton.Click += new System.EventHandler(this.temp_TcClearButton_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(41, 168);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(127, 14);
            this.label28.TabIndex = 38;
            this.label28.Text = "Temperature Sensor (Tc)";
            // 
            // temp_Tc
            // 
            this.temp_Tc.FormattingEnabled = true;
            this.temp_Tc.Location = new System.Drawing.Point(174, 165);
            this.temp_Tc.Name = "temp_Tc";
            this.temp_Tc.Size = new System.Drawing.Size(205, 22);
            this.temp_Tc.TabIndex = 37;
            // 
            // temp_Ti
            // 
            this.temp_Ti.Location = new System.Drawing.Point(138, 121);
            this.temp_Ti.MaxLength = 20;
            this.temp_Ti.Name = "temp_Ti";
            this.temp_Ti.Size = new System.Drawing.Size(75, 20);
            this.temp_Ti.TabIndex = 36;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(138, 103);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(15, 14);
            this.label26.TabIndex = 35;
            this.label26.Text = "Ti";
            // 
            // temp_Tk
            // 
            this.temp_Tk.Location = new System.Drawing.Point(43, 121);
            this.temp_Tk.MaxLength = 20;
            this.temp_Tk.Name = "temp_Tk";
            this.temp_Tk.Size = new System.Drawing.Size(75, 20);
            this.temp_Tk.TabIndex = 34;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(43, 103);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 14);
            this.label27.TabIndex = 33;
            this.label27.Text = "Tk";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label25.Location = new System.Drawing.Point(38, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(163, 18);
            this.label25.TabIndex = 32;
            this.label25.Text = "V1 = Vi*(1 - Tk*(Tc-Ti))";
            // 
            // temp_C5
            // 
            this.temp_C5.Location = new System.Drawing.Point(515, 80);
            this.temp_C5.MaxLength = 20;
            this.temp_C5.Name = "temp_C5";
            this.temp_C5.Size = new System.Drawing.Size(75, 20);
            this.temp_C5.TabIndex = 31;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(512, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 14);
            this.label18.TabIndex = 30;
            this.label18.Text = "C5";
            // 
            // temp_C4
            // 
            this.temp_C4.Location = new System.Drawing.Point(422, 80);
            this.temp_C4.MaxLength = 20;
            this.temp_C4.Name = "temp_C4";
            this.temp_C4.Size = new System.Drawing.Size(75, 20);
            this.temp_C4.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(420, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 14);
            this.label19.TabIndex = 28;
            this.label19.Text = "C4";
            // 
            // temp_C3
            // 
            this.temp_C3.Location = new System.Drawing.Point(327, 80);
            this.temp_C3.MaxLength = 20;
            this.temp_C3.Name = "temp_C3";
            this.temp_C3.Size = new System.Drawing.Size(75, 20);
            this.temp_C3.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(327, 62);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 14);
            this.label20.TabIndex = 26;
            this.label20.Text = "C3";
            // 
            // temp_C2
            // 
            this.temp_C2.Location = new System.Drawing.Point(233, 80);
            this.temp_C2.MaxLength = 20;
            this.temp_C2.Name = "temp_C2";
            this.temp_C2.Size = new System.Drawing.Size(75, 20);
            this.temp_C2.TabIndex = 25;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(234, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 14);
            this.label21.TabIndex = 24;
            this.label21.Text = "C2";
            // 
            // temp_C1
            // 
            this.temp_C1.Location = new System.Drawing.Point(138, 80);
            this.temp_C1.MaxLength = 20;
            this.temp_C1.Name = "temp_C1";
            this.temp_C1.Size = new System.Drawing.Size(75, 20);
            this.temp_C1.TabIndex = 23;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(138, 62);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 14);
            this.label22.TabIndex = 22;
            this.label22.Text = "C1";
            // 
            // temp_C0
            // 
            this.temp_C0.Location = new System.Drawing.Point(43, 80);
            this.temp_C0.MaxLength = 20;
            this.temp_C0.Name = "temp_C0";
            this.temp_C0.Size = new System.Drawing.Size(75, 20);
            this.temp_C0.TabIndex = 21;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(43, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(20, 14);
            this.label23.TabIndex = 20;
            this.label23.Text = "C0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label24.Location = new System.Drawing.Point(38, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(450, 18);
            this.label24.TabIndex = 19;
            this.label24.Text = "Xo = C0 + C1*V1 + C2*V1^2 + C3*V1^3 + C4*V1^4 + C5*V1^5";
            // 
            // vwLinearTab
            // 
            this.vwLinearTab.Controls.Add(this.vwLinear_Bc_Clear);
            this.vwLinearTab.Controls.Add(this.label39);
            this.vwLinearTab.Controls.Add(this.vwLinear_Bc);
            this.vwLinearTab.Controls.Add(this.vwLinear_Tc_Clear);
            this.vwLinearTab.Controls.Add(this.label29);
            this.vwLinearTab.Controls.Add(this.vwLinear_Tc);
            this.vwLinearTab.Controls.Add(this.vwLinear_E);
            this.vwLinearTab.Controls.Add(this.label30);
            this.vwLinearTab.Controls.Add(this.vwLinear_D);
            this.vwLinearTab.Controls.Add(this.label31);
            this.vwLinearTab.Controls.Add(this.vwLinear_Lm);
            this.vwLinearTab.Controls.Add(this.label32);
            this.vwLinearTab.Controls.Add(this.vwLinear_Bi);
            this.vwLinearTab.Controls.Add(this.label33);
            this.vwLinearTab.Controls.Add(this.vwLinear_Ti);
            this.vwLinearTab.Controls.Add(this.label34);
            this.vwLinearTab.Controls.Add(this.vwLinear_Tk);
            this.vwLinearTab.Controls.Add(this.label35);
            this.vwLinearTab.Controls.Add(this.vwLinear_Li);
            this.vwLinearTab.Controls.Add(this.label36);
            this.vwLinearTab.Controls.Add(this.vwLinear_CK);
            this.vwLinearTab.Controls.Add(this.label37);
            this.vwLinearTab.Controls.Add(this.label38);
            this.vwLinearTab.Location = new System.Drawing.Point(4, 23);
            this.vwLinearTab.Name = "vwLinearTab";
            this.vwLinearTab.Size = new System.Drawing.Size(608, 218);
            this.vwLinearTab.TabIndex = 4;
            this.vwLinearTab.Text = "VW tuyến tính";
            this.vwLinearTab.UseVisualStyleBackColor = true;
            // 
            // vwLinear_Bc_Clear
            // 
            this.vwLinear_Bc_Clear.Location = new System.Drawing.Point(380, 182);
            this.vwLinear_Bc_Clear.Name = "vwLinear_Bc_Clear";
            this.vwLinear_Bc_Clear.Size = new System.Drawing.Size(75, 23);
            this.vwLinear_Bc_Clear.TabIndex = 62;
            this.vwLinear_Bc_Clear.Text = "Bỏ trống";
            this.vwLinear_Bc_Clear.UseVisualStyleBackColor = true;
            this.vwLinear_Bc_Clear.Click += new System.EventHandler(this.vwLinear_Bc_Clear_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(30, 186);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(121, 14);
            this.label39.TabIndex = 61;
            this.label39.Text = "Barometric Sensor (Bc)";
            // 
            // vwLinear_Bc
            // 
            this.vwLinear_Bc.FormattingEnabled = true;
            this.vwLinear_Bc.Location = new System.Drawing.Point(164, 183);
            this.vwLinear_Bc.Name = "vwLinear_Bc";
            this.vwLinear_Bc.Size = new System.Drawing.Size(205, 22);
            this.vwLinear_Bc.TabIndex = 60;
            // 
            // vwLinear_Tc_Clear
            // 
            this.vwLinear_Tc_Clear.Location = new System.Drawing.Point(380, 151);
            this.vwLinear_Tc_Clear.Name = "vwLinear_Tc_Clear";
            this.vwLinear_Tc_Clear.Size = new System.Drawing.Size(75, 23);
            this.vwLinear_Tc_Clear.TabIndex = 59;
            this.vwLinear_Tc_Clear.Text = "Bỏ trống";
            this.vwLinear_Tc_Clear.UseVisualStyleBackColor = true;
            this.vwLinear_Tc_Clear.Click += new System.EventHandler(this.vwLinear_Tc_Clear_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(31, 155);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(127, 14);
            this.label29.TabIndex = 58;
            this.label29.Text = "Temperature Sensor (Tc)";
            // 
            // vwLinear_Tc
            // 
            this.vwLinear_Tc.FormattingEnabled = true;
            this.vwLinear_Tc.Location = new System.Drawing.Point(164, 152);
            this.vwLinear_Tc.Name = "vwLinear_Tc";
            this.vwLinear_Tc.Size = new System.Drawing.Size(205, 22);
            this.vwLinear_Tc.TabIndex = 57;
            // 
            // vwLinear_E
            // 
            this.vwLinear_E.Location = new System.Drawing.Point(128, 117);
            this.vwLinear_E.MaxLength = 20;
            this.vwLinear_E.Name = "vwLinear_E";
            this.vwLinear_E.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_E.TabIndex = 56;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(128, 99);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 14);
            this.label30.TabIndex = 55;
            this.label30.Text = "E";
            // 
            // vwLinear_D
            // 
            this.vwLinear_D.Location = new System.Drawing.Point(33, 117);
            this.vwLinear_D.MaxLength = 20;
            this.vwLinear_D.Name = "vwLinear_D";
            this.vwLinear_D.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_D.TabIndex = 54;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(33, 99);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(14, 14);
            this.label31.TabIndex = 53;
            this.label31.Text = "D";
            // 
            // vwLinear_Lm
            // 
            this.vwLinear_Lm.Location = new System.Drawing.Point(505, 76);
            this.vwLinear_Lm.MaxLength = 20;
            this.vwLinear_Lm.Name = "vwLinear_Lm";
            this.vwLinear_Lm.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_Lm.TabIndex = 52;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(502, 58);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(21, 14);
            this.label32.TabIndex = 51;
            this.label32.Text = "Lm";
            // 
            // vwLinear_Bi
            // 
            this.vwLinear_Bi.Location = new System.Drawing.Point(412, 76);
            this.vwLinear_Bi.MaxLength = 20;
            this.vwLinear_Bi.Name = "vwLinear_Bi";
            this.vwLinear_Bi.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_Bi.TabIndex = 50;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(410, 58);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(16, 14);
            this.label33.TabIndex = 49;
            this.label33.Text = "Bi";
            // 
            // vwLinear_Ti
            // 
            this.vwLinear_Ti.Location = new System.Drawing.Point(317, 76);
            this.vwLinear_Ti.MaxLength = 20;
            this.vwLinear_Ti.Name = "vwLinear_Ti";
            this.vwLinear_Ti.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_Ti.TabIndex = 48;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(317, 58);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(15, 14);
            this.label34.TabIndex = 47;
            this.label34.Text = "Ti";
            // 
            // vwLinear_Tk
            // 
            this.vwLinear_Tk.Location = new System.Drawing.Point(223, 76);
            this.vwLinear_Tk.MaxLength = 20;
            this.vwLinear_Tk.Name = "vwLinear_Tk";
            this.vwLinear_Tk.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_Tk.TabIndex = 46;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(224, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(18, 14);
            this.label35.TabIndex = 45;
            this.label35.Text = "Tk";
            // 
            // vwLinear_Li
            // 
            this.vwLinear_Li.Location = new System.Drawing.Point(128, 76);
            this.vwLinear_Li.MaxLength = 20;
            this.vwLinear_Li.Name = "vwLinear_Li";
            this.vwLinear_Li.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_Li.TabIndex = 44;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(128, 58);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(15, 14);
            this.label36.TabIndex = 43;
            this.label36.Text = "Li";
            // 
            // vwLinear_CK
            // 
            this.vwLinear_CK.Location = new System.Drawing.Point(33, 76);
            this.vwLinear_CK.MaxLength = 20;
            this.vwLinear_CK.Name = "vwLinear_CK";
            this.vwLinear_CK.Size = new System.Drawing.Size(75, 20);
            this.vwLinear_CK.TabIndex = 42;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(33, 58);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(21, 14);
            this.label37.TabIndex = 41;
            this.label37.Text = "CK";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label38.Location = new System.Drawing.Point(30, 20);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(361, 18);
            this.label38.TabIndex = 40;
            this.label38.Text = "P0 = CK*(Li*Lm - Lc) - Tk*(Ti - Tc) + D*(Bi - Bc) + E";
            // 
            // vwPoly
            // 
            this.vwPoly.Controls.Add(this.vwPoly_Lm);
            this.vwPoly.Controls.Add(this.label51);
            this.vwPoly.Controls.Add(this.vwPoly_Bc_Clear);
            this.vwPoly.Controls.Add(this.label40);
            this.vwPoly.Controls.Add(this.vwPoly_Bc);
            this.vwPoly.Controls.Add(this.vwPoly_Tc_Clear);
            this.vwPoly.Controls.Add(this.label41);
            this.vwPoly.Controls.Add(this.vwPoly_Tc);
            this.vwPoly.Controls.Add(this.vwPoly_E);
            this.vwPoly.Controls.Add(this.label42);
            this.vwPoly.Controls.Add(this.vwPoly_D);
            this.vwPoly.Controls.Add(this.label43);
            this.vwPoly.Controls.Add(this.vwPoly_Bi);
            this.vwPoly.Controls.Add(this.label44);
            this.vwPoly.Controls.Add(this.vwPoly_Ti);
            this.vwPoly.Controls.Add(this.label45);
            this.vwPoly.Controls.Add(this.vwPoly_Tk);
            this.vwPoly.Controls.Add(this.label46);
            this.vwPoly.Controls.Add(this.vwPoly_C);
            this.vwPoly.Controls.Add(this.label47);
            this.vwPoly.Controls.Add(this.vwPoly_B);
            this.vwPoly.Controls.Add(this.label48);
            this.vwPoly.Controls.Add(this.vwPoly_A);
            this.vwPoly.Controls.Add(this.label49);
            this.vwPoly.Controls.Add(this.label50);
            this.vwPoly.Location = new System.Drawing.Point(4, 23);
            this.vwPoly.Name = "vwPoly";
            this.vwPoly.Size = new System.Drawing.Size(608, 218);
            this.vwPoly.TabIndex = 5;
            this.vwPoly.Text = "VW mũ";
            this.vwPoly.UseVisualStyleBackColor = true;
            // 
            // vwPoly_Lm
            // 
            this.vwPoly_Lm.Location = new System.Drawing.Point(32, 118);
            this.vwPoly_Lm.MaxLength = 20;
            this.vwPoly_Lm.Name = "vwPoly_Lm";
            this.vwPoly_Lm.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_Lm.TabIndex = 87;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(32, 100);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(21, 14);
            this.label51.TabIndex = 86;
            this.label51.Text = "Lm";
            // 
            // vwPoly_Bc_Clear
            // 
            this.vwPoly_Bc_Clear.Location = new System.Drawing.Point(379, 183);
            this.vwPoly_Bc_Clear.Name = "vwPoly_Bc_Clear";
            this.vwPoly_Bc_Clear.Size = new System.Drawing.Size(75, 23);
            this.vwPoly_Bc_Clear.TabIndex = 85;
            this.vwPoly_Bc_Clear.Text = "Bỏ trống";
            this.vwPoly_Bc_Clear.UseVisualStyleBackColor = true;
            this.vwPoly_Bc_Clear.Click += new System.EventHandler(this.vwPoly_Bc_Clear_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(29, 187);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(121, 14);
            this.label40.TabIndex = 84;
            this.label40.Text = "Barometric Sensor (Bc)";
            // 
            // vwPoly_Bc
            // 
            this.vwPoly_Bc.FormattingEnabled = true;
            this.vwPoly_Bc.Location = new System.Drawing.Point(163, 184);
            this.vwPoly_Bc.Name = "vwPoly_Bc";
            this.vwPoly_Bc.Size = new System.Drawing.Size(205, 22);
            this.vwPoly_Bc.TabIndex = 83;
            // 
            // vwPoly_Tc_Clear
            // 
            this.vwPoly_Tc_Clear.Location = new System.Drawing.Point(379, 152);
            this.vwPoly_Tc_Clear.Name = "vwPoly_Tc_Clear";
            this.vwPoly_Tc_Clear.Size = new System.Drawing.Size(75, 23);
            this.vwPoly_Tc_Clear.TabIndex = 82;
            this.vwPoly_Tc_Clear.Text = "Bỏ trống";
            this.vwPoly_Tc_Clear.UseVisualStyleBackColor = true;
            this.vwPoly_Tc_Clear.Click += new System.EventHandler(this.vwPoly_Tc_Clear_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(30, 156);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(127, 14);
            this.label41.TabIndex = 81;
            this.label41.Text = "Temperature Sensor (Tc)";
            // 
            // vwPoly_Tc
            // 
            this.vwPoly_Tc.FormattingEnabled = true;
            this.vwPoly_Tc.Location = new System.Drawing.Point(163, 153);
            this.vwPoly_Tc.Name = "vwPoly_Tc";
            this.vwPoly_Tc.Size = new System.Drawing.Size(205, 22);
            this.vwPoly_Tc.TabIndex = 80;
            // 
            // vwPoly_E
            // 
            this.vwPoly_E.Location = new System.Drawing.Point(222, 118);
            this.vwPoly_E.MaxLength = 20;
            this.vwPoly_E.Name = "vwPoly_E";
            this.vwPoly_E.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_E.TabIndex = 79;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(222, 100);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(13, 14);
            this.label42.TabIndex = 78;
            this.label42.Text = "E";
            // 
            // vwPoly_D
            // 
            this.vwPoly_D.Location = new System.Drawing.Point(127, 118);
            this.vwPoly_D.MaxLength = 20;
            this.vwPoly_D.Name = "vwPoly_D";
            this.vwPoly_D.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_D.TabIndex = 77;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(127, 100);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(14, 14);
            this.label43.TabIndex = 76;
            this.label43.Text = "D";
            // 
            // vwPoly_Bi
            // 
            this.vwPoly_Bi.Location = new System.Drawing.Point(504, 77);
            this.vwPoly_Bi.MaxLength = 20;
            this.vwPoly_Bi.Name = "vwPoly_Bi";
            this.vwPoly_Bi.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_Bi.TabIndex = 75;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(501, 59);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(16, 14);
            this.label44.TabIndex = 74;
            this.label44.Text = "Bi";
            // 
            // vwPoly_Ti
            // 
            this.vwPoly_Ti.Location = new System.Drawing.Point(411, 77);
            this.vwPoly_Ti.MaxLength = 20;
            this.vwPoly_Ti.Name = "vwPoly_Ti";
            this.vwPoly_Ti.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_Ti.TabIndex = 73;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(409, 59);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(15, 14);
            this.label45.TabIndex = 72;
            this.label45.Text = "Ti";
            // 
            // vwPoly_Tk
            // 
            this.vwPoly_Tk.Location = new System.Drawing.Point(316, 77);
            this.vwPoly_Tk.MaxLength = 20;
            this.vwPoly_Tk.Name = "vwPoly_Tk";
            this.vwPoly_Tk.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_Tk.TabIndex = 71;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(316, 59);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(18, 14);
            this.label46.TabIndex = 70;
            this.label46.Text = "Tk";
            // 
            // vwPoly_C
            // 
            this.vwPoly_C.Location = new System.Drawing.Point(222, 77);
            this.vwPoly_C.MaxLength = 20;
            this.vwPoly_C.Name = "vwPoly_C";
            this.vwPoly_C.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_C.TabIndex = 69;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(223, 59);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(14, 14);
            this.label47.TabIndex = 68;
            this.label47.Text = "C";
            // 
            // vwPoly_B
            // 
            this.vwPoly_B.Location = new System.Drawing.Point(127, 77);
            this.vwPoly_B.MaxLength = 20;
            this.vwPoly_B.Name = "vwPoly_B";
            this.vwPoly_B.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_B.TabIndex = 67;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(127, 59);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(14, 14);
            this.label48.TabIndex = 66;
            this.label48.Text = "B";
            // 
            // vwPoly_A
            // 
            this.vwPoly_A.Location = new System.Drawing.Point(32, 77);
            this.vwPoly_A.MaxLength = 20;
            this.vwPoly_A.Name = "vwPoly_A";
            this.vwPoly_A.Size = new System.Drawing.Size(75, 20);
            this.vwPoly_A.TabIndex = 65;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(32, 59);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(15, 14);
            this.label49.TabIndex = 64;
            this.label49.Text = "A";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label50.Location = new System.Drawing.Point(30, 20);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(456, 18);
            this.label50.TabIndex = 63;
            this.label50.Text = "P0 = A*(Lc*Lm)^2 + B*(Lc*Lm) + C + Tk*(Tc - Ti) - D*(Bc - Bi) + E";
            // 
            // tabUserDefine
            // 
            this.tabUserDefine.Controls.Add(this.btnTestExpression);
            this.tabUserDefine.Controls.Add(this.label53);
            this.tabUserDefine.Controls.Add(this.txtUserExpression);
            this.tabUserDefine.Controls.Add(this.label52);
            this.tabUserDefine.Location = new System.Drawing.Point(4, 23);
            this.tabUserDefine.Name = "tabUserDefine";
            this.tabUserDefine.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserDefine.Size = new System.Drawing.Size(608, 218);
            this.tabUserDefine.TabIndex = 6;
            this.tabUserDefine.Text = "Tự định nghĩa";
            this.tabUserDefine.UseVisualStyleBackColor = true;
            // 
            // btnTestExpression
            // 
            this.btnTestExpression.Location = new System.Drawing.Point(43, 100);
            this.btnTestExpression.Name = "btnTestExpression";
            this.btnTestExpression.Size = new System.Drawing.Size(75, 23);
            this.btnTestExpression.TabIndex = 4;
            this.btnTestExpression.Text = "Kiểm tra";
            this.btnTestExpression.UseVisualStyleBackColor = true;
            this.btnTestExpression.Click += new System.EventHandler(this.btnTestExpression_Click);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(40, 66);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(53, 14);
            this.label53.TabIndex = 3;
            this.label53.Text = "Biểu thức";
            // 
            // txtUserExpression
            // 
            this.txtUserExpression.Location = new System.Drawing.Point(99, 63);
            this.txtUserExpression.Name = "txtUserExpression";
            this.txtUserExpression.Size = new System.Drawing.Size(383, 20);
            this.txtUserExpression.TabIndex = 2;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label52.Location = new System.Drawing.Point(40, 25);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(146, 18);
            this.label52.TabIndex = 1;
            this.label52.Text = "Xo = x^2  + (x+1)/10";
            // 
            // alarmTab
            // 
            this.alarmTab.Controls.Add(this.updateAlarm);
            this.alarmTab.Controls.Add(this.unitLabel2);
            this.alarmTab.Controls.Add(this.unitLabel1);
            this.alarmTab.Controls.Add(this.maxAlarmTextBox);
            this.alarmTab.Controls.Add(this.minAlarmTextBox);
            this.alarmTab.Controls.Add(this.label5);
            this.alarmTab.Controls.Add(this.label4);
            this.alarmTab.Controls.Add(this.enableAlarmCheckBox);
            this.alarmTab.Location = new System.Drawing.Point(4, 23);
            this.alarmTab.Name = "alarmTab";
            this.alarmTab.Size = new System.Drawing.Size(652, 283);
            this.alarmTab.TabIndex = 2;
            this.alarmTab.Text = "Cảnh báo";
            this.alarmTab.UseVisualStyleBackColor = true;
            // 
            // updateAlarm
            // 
            this.updateAlarm.AutoSize = true;
            this.updateAlarm.Location = new System.Drawing.Point(533, 6);
            this.updateAlarm.Name = "updateAlarm";
            this.updateAlarm.Size = new System.Drawing.Size(117, 18);
            this.updateAlarm.TabIndex = 8;
            this.updateAlarm.Text = "Cập nhật cảnh báo";
            this.updateAlarm.UseVisualStyleBackColor = true;
            // 
            // unitLabel2
            // 
            this.unitLabel2.AutoSize = true;
            this.unitLabel2.Location = new System.Drawing.Point(267, 120);
            this.unitLabel2.Name = "unitLabel2";
            this.unitLabel2.Size = new System.Drawing.Size(56, 14);
            this.unitLabel2.TabIndex = 6;
            this.unitLabel2.Text = "unitLabel2";
            // 
            // unitLabel1
            // 
            this.unitLabel1.AutoSize = true;
            this.unitLabel1.Location = new System.Drawing.Point(267, 80);
            this.unitLabel1.Name = "unitLabel1";
            this.unitLabel1.Size = new System.Drawing.Size(56, 14);
            this.unitLabel1.TabIndex = 5;
            this.unitLabel1.Text = "unitLabel1";
            // 
            // maxAlarmTextBox
            // 
            this.maxAlarmTextBox.Location = new System.Drawing.Point(161, 117);
            this.maxAlarmTextBox.Name = "maxAlarmTextBox";
            this.maxAlarmTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxAlarmTextBox.TabIndex = 4;
            // 
            // minAlarmTextBox
            // 
            this.minAlarmTextBox.Location = new System.Drawing.Point(161, 77);
            this.minAlarmTextBox.Name = "minAlarmTextBox";
            this.minAlarmTextBox.Size = new System.Drawing.Size(100, 20);
            this.minAlarmTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mức cảnh báo trên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mức cảnh báo dưới";
            // 
            // enableAlarmCheckBox
            // 
            this.enableAlarmCheckBox.AutoSize = true;
            this.enableAlarmCheckBox.Location = new System.Drawing.Point(46, 40);
            this.enableAlarmCheckBox.Name = "enableAlarmCheckBox";
            this.enableAlarmCheckBox.Size = new System.Drawing.Size(178, 18);
            this.enableAlarmCheckBox.TabIndex = 0;
            this.enableAlarmCheckBox.Text = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_EnableAlarm;
            this.enableAlarmCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.recalcButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.reloadButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Location = new System.Drawing.Point(12, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 29);
            this.panel1.TabIndex = 2;
            // 
            // recalcButton
            // 
            this.recalcButton.Image = global::GeoViewer.Data.Properties.Resources.calculator_16;
            this.recalcButton.Location = new System.Drawing.Point(258, 3);
            this.recalcButton.Name = "recalcButton";
            this.recalcButton.Size = new System.Drawing.Size(100, 26);
            this.recalcButton.TabIndex = 7;
            this.recalcButton.Text = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_ReCalc;
            this.recalcButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.recalcButton, "Tính toán lại giá trị của các sensors được chọn ");
            this.recalcButton.UseVisualStyleBackColor = true;
            this.recalcButton.Click += new System.EventHandler(this.recalcButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Image = global::GeoViewer.Data.Properties.Resources.disk_16;
            this.saveButton.Location = new System.Drawing.Point(473, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = global::GeoViewer.Data.Properties.Resources.Save;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadButton.Image")));
            this.reloadButton.Location = new System.Drawing.Point(559, 3);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(100, 26);
            this.reloadButton.TabIndex = 4;
            this.reloadButton.Text = global::GeoViewer.Data.Properties.Resources.RefreshTable;
            this.reloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(172, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 26);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = global::GeoViewer.Data.Properties.Resources.Delete;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.deleteButton, "Xóa các sensors được chọn");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.Location = new System.Drawing.Point(86, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 26);
            this.editButton.TabIndex = 2;
            this.editButton.Text = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_Edit;
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Location = new System.Drawing.Point(0, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 26);
            this.addButton.TabIndex = 1;
            this.addButton.Text = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_Add;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = global::GeoViewer.Data.Properties.Resources.ToolTip_Title;
            // 
            // SensorID
            // 
            this.SensorID.DataPropertyName = "SensorID";
            this.SensorID.HeaderText = "Mã";
            this.SensorID.Name = "SensorID";
            this.SensorID.ReadOnly = true;
            this.SensorID.Width = 45;
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.DataPropertyName = "ColumnIndex";
            this.ColumnIndex.HeaderText = "Cột";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.ReadOnly = true;
            this.ColumnIndex.Width = 45;
            // 
            // SensorName
            // 
            this.SensorName.DataPropertyName = "Name";
            this.SensorName.HeaderText = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_Column_Name;
            this.SensorName.Name = "SensorName";
            this.SensorName.ReadOnly = true;
            this.SensorName.Width = 150;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_Column_Unit;
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // AlarmEnabled
            // 
            this.AlarmEnabled.DataPropertyName = "AlarmEnabled";
            this.AlarmEnabled.HeaderText = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_InitializeComponent_AlarmEnabled;
            this.AlarmEnabled.Name = "AlarmEnabled";
            this.AlarmEnabled.ReadOnly = true;
            this.AlarmEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AlarmFlag
            // 
            this.AlarmFlag.DataPropertyName = "AlarmFlag";
            this.AlarmFlag.HeaderText = global::GeoViewer.Data.Properties.Resources.SensorsManagerForm_InitializeComponent_AlarmRunning;
            this.AlarmFlag.Image = ((System.Drawing.Image)(resources.GetObject("AlarmFlag.Image")));
            this.AlarmFlag.Name = "AlarmFlag";
            this.AlarmFlag.ReadOnly = true;
            this.AlarmFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // SensorsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addEditTabs);
            this.Controls.Add(this.sensorGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SensorsManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cảm biến";
            this.Load += new System.EventHandler(this.SensorsManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sensorGridView)).EndInit();
            this.addEditTabs.ResumeLayout(false);
            this.infoTab.ResumeLayout(false);
            this.infoTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnIndexNumeric)).EndInit();
            this.calcTab.ResumeLayout(false);
            this.calcTab.PerformLayout();
            this.caclSelectTabs.ResumeLayout(false);
            this.linearTab.ResumeLayout(false);
            this.linearTab.PerformLayout();
            this.arcToLengthTab.ResumeLayout(false);
            this.arcToLengthTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.polynomialTab.ResumeLayout(false);
            this.polynomialTab.PerformLayout();
            this.temperatureCompTab.ResumeLayout(false);
            this.temperatureCompTab.PerformLayout();
            this.vwLinearTab.ResumeLayout(false);
            this.vwLinearTab.PerformLayout();
            this.vwPoly.ResumeLayout(false);
            this.vwPoly.PerformLayout();
            this.tabUserDefine.ResumeLayout(false);
            this.tabUserDefine.PerformLayout();
            this.alarmTab.ResumeLayout(false);
            this.alarmTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sensorGridView;
        private System.Windows.Forms.TabControl addEditTabs;
        private System.Windows.Forms.TabPage infoTab;
        private System.Windows.Forms.TabPage calcTab;
        private System.Windows.Forms.TabPage alarmTab;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown columnIndexNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox enableAlarmCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl caclSelectTabs;
        private System.Windows.Forms.TabPage linearTab;
        private System.Windows.Forms.TabPage arcToLengthTab;
        private System.Windows.Forms.TabPage polynomialTab;
        private System.Windows.Forms.TabPage temperatureCompTab;
        private System.Windows.Forms.TabPage vwLinearTab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox linear_C0;
        private System.Windows.Forms.TextBox linear_C1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton arc_Radian;
        private System.Windows.Forms.RadioButton arc_Degree;
        private System.Windows.Forms.TextBox arc_Length;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox poly_C5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox poly_C4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox poly_C3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox poly_C2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox poly_C1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox poly_C0;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox temp_Tc;
        private System.Windows.Forms.TextBox temp_Ti;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox temp_Tk;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox temp_C5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox temp_C4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox temp_C3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox temp_C2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox temp_C1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox temp_C0;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button temp_TcClearButton;
        private System.Windows.Forms.Button vwLinear_Tc_Clear;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox vwLinear_Tc;
        private System.Windows.Forms.TextBox vwLinear_E;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox vwLinear_D;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox vwLinear_Lm;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox vwLinear_Bi;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox vwLinear_Ti;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox vwLinear_Tk;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox vwLinear_Li;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox vwLinear_CK;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button vwLinear_Bc_Clear;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox vwLinear_Bc;
        private System.Windows.Forms.TabPage vwPoly;
        private System.Windows.Forms.TextBox vwPoly_Lm;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Button vwPoly_Bc_Clear;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox vwPoly_Bc;
        private System.Windows.Forms.Button vwPoly_Tc_Clear;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox vwPoly_Tc;
        private System.Windows.Forms.TextBox vwPoly_E;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox vwPoly_D;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox vwPoly_Bi;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox vwPoly_Ti;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox vwPoly_Tk;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox vwPoly_C;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox vwPoly_B;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox vwPoly_A;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label unitLabel2;
        private System.Windows.Forms.Label unitLabel1;
        private System.Windows.Forms.TextBox maxAlarmTextBox;
        private System.Windows.Forms.TextBox minAlarmTextBox;
        private System.Windows.Forms.Button recalcButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.CheckBox updateInfo;
        private System.Windows.Forms.CheckBox updateCalc;
        private System.Windows.Forms.CheckBox updateAlarm;
        private System.Windows.Forms.TabPage tabUserDefine;
        private System.Windows.Forms.Button btnTestExpression;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox txtUserExpression;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn SensorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewImageColumn AlarmEnabled;
        private System.Windows.Forms.DataGridViewImageColumn AlarmFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedUser;
    }
}