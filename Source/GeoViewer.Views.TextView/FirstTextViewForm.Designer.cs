namespace GeoViewer.Views.TextView
{
    partial class FirstTextViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTextViewForm));
            this.GridViewText = new System.Windows.Forms.DataGridView();
            this.combotext = new System.Windows.Forms.ComboBox();
            this.ValueGridView = new System.Windows.Forms.DataGridView();
            this.Clearbtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTextViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawValueRadio = new System.Windows.Forms.RadioButton();
            this.calcRadio = new System.Windows.Forms.RadioButton();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridViewText
            // 
            this.GridViewText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewText.Location = new System.Drawing.Point(12, 59);
            this.GridViewText.Name = "GridViewText";
            this.GridViewText.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewText.Size = new System.Drawing.Size(210, 536);
            this.GridViewText.TabIndex = 3;
            this.GridViewText.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewText_CellClick);
            // 
            // combotext
            // 
            this.combotext.FormattingEnabled = true;
            this.combotext.Items.AddRange(new object[] {
            "All Sensors",
            "Group",
            "Picture"});
            this.combotext.Location = new System.Drawing.Point(12, 32);
            this.combotext.Name = "combotext";
            this.combotext.Size = new System.Drawing.Size(89, 22);
            this.combotext.TabIndex = 4;
            this.combotext.Text = "All Sensors";
            this.combotext.SelectedIndexChanged += new System.EventHandler(this.combotext_SelectedIndexChanged);
            // 
            // ValueGridView
            // 
            this.ValueGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValueGridView.Location = new System.Drawing.Point(228, 56);
            this.ValueGridView.Name = "ValueGridView";
            this.ValueGridView.Size = new System.Drawing.Size(754, 539);
            this.ValueGridView.TabIndex = 7;
            // 
            // Clearbtn
            // 
            this.Clearbtn.Image = global::GeoViewer.Views.TextView.Properties.Resources.refresh_16;
            this.Clearbtn.Location = new System.Drawing.Point(902, 24);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(80, 26);
            this.Clearbtn.TabIndex = 8;
            this.Clearbtn.Text = "Làm lại";
            this.Clearbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Clearbtn.UseVisualStyleBackColor = true;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printToolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "Print Preview";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem1
            // 
            this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            this.printToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem1.Text = "Print";
            this.printToolStripMenuItem1.Click += new System.EventHandler(this.printToolStripMenuItem1_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFroupToolStripMenuItem,
            this.editTextViewToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editFroupToolStripMenuItem
            // 
            this.editFroupToolStripMenuItem.Name = "editFroupToolStripMenuItem";
            this.editFroupToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editFroupToolStripMenuItem.Text = "Edit Group";
            this.editFroupToolStripMenuItem.Click += new System.EventHandler(this.editFroupToolStripMenuItem_Click);
            // 
            // editTextViewToolStripMenuItem
            // 
            this.editTextViewToolStripMenuItem.Name = "editTextViewToolStripMenuItem";
            this.editTextViewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editTextViewToolStripMenuItem.Text = "Edit Text View";
            // 
            // rawValueRadio
            // 
            this.rawValueRadio.AutoSize = true;
            this.rawValueRadio.Checked = true;
            this.rawValueRadio.Location = new System.Drawing.Point(122, 32);
            this.rawValueRadio.Name = "rawValueRadio";
            this.rawValueRadio.Size = new System.Drawing.Size(71, 18);
            this.rawValueRadio.TabIndex = 12;
            this.rawValueRadio.TabStop = true;
            this.rawValueRadio.Text = "Giá trị thô";
            this.rawValueRadio.UseVisualStyleBackColor = true;
            this.rawValueRadio.CheckedChanged += new System.EventHandler(this.rawValueRadio_CheckedChanged);
            // 
            // calcRadio
            // 
            this.calcRadio.AutoSize = true;
            this.calcRadio.Location = new System.Drawing.Point(199, 32);
            this.calcRadio.Name = "calcRadio";
            this.calcRadio.Size = new System.Drawing.Size(112, 18);
            this.calcRadio.TabIndex = 13;
            this.calcRadio.Text = "Giá trị đã tính toán";
            this.calcRadio.UseVisualStyleBackColor = true;
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
            // FirstTextViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 607);
            this.Controls.Add(this.calcRadio);
            this.Controls.Add(this.rawValueRadio);
            this.Controls.Add(this.Clearbtn);
            this.Controls.Add(this.ValueGridView);
            this.Controls.Add(this.combotext);
            this.Controls.Add(this.GridViewText);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstTextViewForm";
            this.Text = "Text view";
            this.Load += new System.EventHandler(this.FirstTextViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewText;
        private System.Windows.Forms.ComboBox combotext;
        private System.Windows.Forms.DataGridView ValueGridView;
        private System.Windows.Forms.Button Clearbtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTextViewToolStripMenuItem;
        private System.Windows.Forms.RadioButton rawValueRadio;
        private System.Windows.Forms.RadioButton calcRadio;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}