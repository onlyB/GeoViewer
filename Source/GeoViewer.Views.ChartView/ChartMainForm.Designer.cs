using GeoViewer.Views.ChartView.Properties;

namespace GeoViewer.Views.ChartView
{
    partial class ChartMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combochart = new System.Windows.Forms.ComboBox();
            this.ChartGridView = new System.Windows.Forms.DataGridView();
            this.zedGraphChart = new ZedGraph.ZedGraphControl();
            this.fromdateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.todateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoggerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem1,
            this.groupToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.closeToolStripMenuItem.Text = global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Close;
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.printPreviewToolStripMenuItem.Text = global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Print_Preview;
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem1
            // 
            this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            this.printToolStripMenuItem1.Size = new System.Drawing.Size(29, 20);
            this.printToolStripMenuItem1.Text = global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Print;
            this.printToolStripMenuItem1.Click += new System.EventHandler(this.printToolStripMenuItem1_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.groupToolStripMenuItem.Text = global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Group;
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.scaleToolStripMenuItem.Text = global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Cutomize;
            this.scaleToolStripMenuItem.Click += new System.EventHandler(this.scaleToolStripMenuItem_Click);
            // 
            // combochart
            // 
            this.combochart.FormattingEnabled = true;
            this.combochart.Items.AddRange(new object[] {
            global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_All_Sensors,
            global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Group,
            global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Picture});
            this.combochart.Location = new System.Drawing.Point(3, 3);
            this.combochart.Name = "combochart";
            this.combochart.Size = new System.Drawing.Size(111, 22);
            this.combochart.TabIndex = 4;
            this.combochart.Text = "Tất cả cảm biến";
            this.combochart.SelectedIndexChanged += new System.EventHandler(this.combochart_SelectedIndexChanged);
            // 
            // ChartGridView
            // 
            this.ChartGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChartGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.NameColumn,
            this.LoggerName,
            this.Description});
            this.ChartGridView.Location = new System.Drawing.Point(2, 56);
            this.ChartGridView.Name = "ChartGridView";
            this.ChartGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChartGridView.Size = new System.Drawing.Size(193, 562);
            this.ChartGridView.TabIndex = 5;
            this.ChartGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChartGridView_CellClick);
            // 
            // zedGraphChart
            // 
            this.zedGraphChart.BackColor = System.Drawing.Color.Wheat;
            this.zedGraphChart.Location = new System.Drawing.Point(202, 56);
            this.zedGraphChart.Name = "zedGraphChart";
            this.zedGraphChart.PanModifierKeys = System.Windows.Forms.Keys.Space;
            this.zedGraphChart.ScrollGrace = 0D;
            this.zedGraphChart.ScrollMaxX = 0D;
            this.zedGraphChart.ScrollMaxY = 0D;
            this.zedGraphChart.ScrollMaxY2 = 0D;
            this.zedGraphChart.ScrollMinX = 0D;
            this.zedGraphChart.ScrollMinY = 0D;
            this.zedGraphChart.ScrollMinY2 = 0D;
            this.zedGraphChart.Size = new System.Drawing.Size(789, 562);
            this.zedGraphChart.TabIndex = 6;
            // 
            // fromdateTextBox
            // 
            this.fromdateTextBox.Location = new System.Drawing.Point(442, 3);
            this.fromdateTextBox.Mask = "00/00/0000";
            this.fromdateTextBox.Name = "fromdateTextBox";
            this.fromdateTextBox.Size = new System.Drawing.Size(180, 20);
            this.fromdateTextBox.TabIndex = 11;
            this.fromdateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // todateTextBox
            // 
            this.todateTextBox.Location = new System.Drawing.Point(704, 3);
            this.todateTextBox.Mask = "00/00/0000";
            this.todateTextBox.Name = "todateTextBox";
            this.todateTextBox.Size = new System.Drawing.Size(180, 20);
            this.todateTextBox.TabIndex = 12;
            this.todateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.fromdateTextBox);
            this.panel1.Controls.Add(this.todateTextBox);
            this.panel1.Controls.Add(this.combochart);
            this.panel1.Location = new System.Drawing.Point(2, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 27);
            this.panel1.TabIndex = 13;
            // 
            // viewButton
            // 
            this.viewButton.Image = global::GeoViewer.Views.ChartView.Properties.Resources.login_16;
            this.viewButton.Location = new System.Drawing.Point(906, 0);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(80, 26);
            this.viewButton.TabIndex = 15;
            this.viewButton.Text = global::GeoViewer.Views.ChartView.Properties.Resources.ChartMainForm_InitializeComponent_Drawchart;
            this.viewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(644, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = "Đến ngày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "Từ ngày";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "Mã";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.Width = 50;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Tên";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 150;
            // 
            // LoggerName
            // 
            this.LoggerName.DataPropertyName = "LoggerName";
            this.LoggerName.HeaderText = "Nguồn dữ liệu";
            this.LoggerName.Name = "LoggerName";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // ChartMainForm
            // 
            this.AcceptButton = this.viewButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 622);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zedGraphChart);
            this.Controls.Add(this.ChartGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biểu đồ";
            this.Load += new System.EventHandler(this.ChartMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox combochart;
        private System.Windows.Forms.DataGridView ChartGridView;
        private ZedGraph.ZedGraphControl zedGraphChart;
        private System.Windows.Forms.MaskedTextBox fromdateTextBox;
        private System.Windows.Forms.MaskedTextBox todateTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoggerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}