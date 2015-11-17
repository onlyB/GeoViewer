using GeoViewer.Views.ChartView.Properties;

namespace GeoViewer.Views.ChartView
{
    partial class EditScaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditScaleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChartTitle = new System.Windows.Forms.TextBox();
            this.txtXaxis = new System.Windows.Forms.TextBox();
            this.txtYaxis = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboedittype = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EditScaleGridView = new System.Windows.Forms.DataGridView();
            this.comboeditbold = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btncolor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditScaleGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiêu đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên trục X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên trục Y";
            // 
            // txtChartTitle
            // 
            this.txtChartTitle.Location = new System.Drawing.Point(67, 13);
            this.txtChartTitle.Name = "txtChartTitle";
            this.txtChartTitle.Size = new System.Drawing.Size(208, 20);
            this.txtChartTitle.TabIndex = 3;
            // 
            // txtXaxis
            // 
            this.txtXaxis.Location = new System.Drawing.Point(66, 47);
            this.txtXaxis.Name = "txtXaxis";
            this.txtXaxis.Size = new System.Drawing.Size(209, 20);
            this.txtXaxis.TabIndex = 4;
            // 
            // txtYaxis
            // 
            this.txtYaxis.Location = new System.Drawing.Point(67, 83);
            this.txtYaxis.Name = "txtYaxis";
            this.txtYaxis.Size = new System.Drawing.Size(208, 20);
            this.txtYaxis.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::GeoViewer.Views.ChartView.Properties.Resources.disk_16;
            this.btnOK.Location = new System.Drawing.Point(284, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 26);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = global::GeoViewer.Views.ChartView.Properties.Resources.EditScaleForm_OK;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::GeoViewer.Views.ChartView.Properties.Resources.refresh_16;
            this.btnCancel.Location = new System.Drawing.Point(284, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 26);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = global::GeoViewer.Views.ChartView.Properties.Resources.EditScaleForm_Cancel;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtChartTitle);
            this.groupBox1.Controls.Add(this.txtXaxis);
            this.groupBox1.Controls.Add(this.txtYaxis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 115);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đồ thị";
            // 
            // comboedittype
            // 
            this.comboedittype.FormattingEnabled = true;
            this.comboedittype.Items.AddRange(new object[] {
            "Raw",
            "Refine"});
            this.comboedittype.Location = new System.Drawing.Point(284, 91);
            this.comboedittype.Name = "comboedittype";
            this.comboedittype.Size = new System.Drawing.Size(80, 22);
            this.comboedittype.TabIndex = 11;
            this.comboedittype.SelectedIndexChanged += new System.EventHandler(this.comboedittype_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nét đậm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dữ liệu vẽ";
            // 
            // EditScaleGridView
            // 
            this.EditScaleGridView.AllowUserToAddRows = false;
            this.EditScaleGridView.AllowUserToDeleteRows = false;
            this.EditScaleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EditScaleGridView.Location = new System.Drawing.Point(9, 19);
            this.EditScaleGridView.MultiSelect = false;
            this.EditScaleGridView.Name = "EditScaleGridView";
            this.EditScaleGridView.ReadOnly = true;
            this.EditScaleGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EditScaleGridView.Size = new System.Drawing.Size(266, 223);
            this.EditScaleGridView.TabIndex = 6;
            this.EditScaleGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditScaleGridView_CellClick);
            // 
            // comboeditbold
            // 
            this.comboeditbold.FormattingEnabled = true;
            this.comboeditbold.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboeditbold.Location = new System.Drawing.Point(284, 149);
            this.comboeditbold.Name = "comboeditbold";
            this.comboeditbold.Size = new System.Drawing.Size(80, 22);
            this.comboeditbold.TabIndex = 13;
            this.comboeditbold.SelectedIndexChanged += new System.EventHandler(this.comboeditbold_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Màu sắc";
            // 
            // btncolor
            // 
            this.btncolor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btncolor.Location = new System.Drawing.Point(284, 35);
            this.btncolor.Name = "btncolor";
            this.btncolor.Size = new System.Drawing.Size(80, 26);
            this.btncolor.TabIndex = 9;
            this.btncolor.UseVisualStyleBackColor = false;
            this.btncolor.Click += new System.EventHandler(this.btncolor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbStyle);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btncolor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboeditbold);
            this.groupBox2.Controls.Add(this.EditScaleGridView);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboedittype);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 247);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cảm biến hiển thị";
            // 
            // cbStyle
            // 
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Items.AddRange(new object[] {
            "_________",
            "...............",
            "---------",
            "-.-.-.-.-.-",
            "-..-..-..-.."});
            this.cbStyle.Location = new System.Drawing.Point(284, 205);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(77, 22);
            this.cbStyle.TabIndex = 15;
            this.cbStyle.SelectedIndexChanged += new System.EventHandler(this.cbStyle_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nét vẽ";
            // 
            // EditScaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditScaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tùy chỉnh";
            this.Load += new System.EventHandler(this.EditScaleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditScaleGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChartTitle;
        private System.Windows.Forms.TextBox txtXaxis;
        private System.Windows.Forms.TextBox txtYaxis;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboedittype;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView EditScaleGridView;
        private System.Windows.Forms.ComboBox comboeditbold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btncolor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.Label label4;
    }
}