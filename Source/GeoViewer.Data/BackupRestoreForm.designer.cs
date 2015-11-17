using GeoViewer.Data.Properties;

namespace GeoViewer.Data
{
    partial class BackupRestoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupRestoreForm));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtFileNameBackup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseRestore = new System.Windows.Forms.Button();
            this.txtFileNameRestore = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbBackup = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::GeoViewer.Data.Properties.Resources.delete_16;
            this.btnDelete.Location = new System.Drawing.Point(320, 362);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 26);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = global::GeoViewer.Data.Properties.Resources.Delete;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDelete, global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Delete_Hint);
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Image = global::GeoViewer.Data.Properties.Resources.disk_16;
            this.btnBackup.Location = new System.Drawing.Point(6, 96);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(80, 26);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Backup;
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnBackup, global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Backup_Hint);
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtFileNameBackup
            // 
            this.txtFileNameBackup.Location = new System.Drawing.Point(6, 58);
            this.txtFileNameBackup.MaxLength = 5000;
            this.txtFileNameBackup.Name = "txtFileNameBackup";
            this.txtFileNameBackup.ReadOnly = true;
            this.txtFileNameBackup.Size = new System.Drawing.Size(223, 20);
            this.txtFileNameBackup.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chọn file phục hồi";
            // 
            // btnRestore
            // 
            this.btnRestore.Image = global::GeoViewer.Data.Properties.Resources.refresh_16;
            this.btnRestore.Location = new System.Drawing.Point(7, 96);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(80, 26);
            this.btnRestore.TabIndex = 0;
            this.btnRestore.Text = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Restore;
            this.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseBackup.Image")));
            this.btnBrowseBackup.Location = new System.Drawing.Point(235, 57);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(63, 23);
            this.btnBrowseBackup.TabIndex = 3;
            this.btnBrowseBackup.Text = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Select;
            this.btnBrowseBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseBackup.UseVisualStyleBackColor = true;
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 397);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.CreationTime,
            this.FileSize});
            this.dataGridView1.Location = new System.Drawing.Point(320, 9);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(350, 347);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Column_Path;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 250;
            // 
            // CreationTime
            // 
            this.CreationTime.DataPropertyName = "CreationTime";
            this.CreationTime.HeaderText = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Column_CreationDate;
            this.CreationTime.Name = "CreationTime";
            this.CreationTime.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.DataPropertyName = "FileSize";
            this.FileSize.HeaderText = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Column_Size;
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseRestore);
            this.groupBox2.Controls.Add(this.txtFileNameRestore);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 182);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phục Hồi";
            // 
            // btnBrowseRestore
            // 
            this.btnBrowseRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseRestore.Image")));
            this.btnBrowseRestore.Location = new System.Drawing.Point(236, 53);
            this.btnBrowseRestore.Name = "btnBrowseRestore";
            this.btnBrowseRestore.Size = new System.Drawing.Size(63, 23);
            this.btnBrowseRestore.TabIndex = 7;
            this.btnBrowseRestore.Text = global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Select;
            this.btnBrowseRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseRestore.UseVisualStyleBackColor = true;
            this.btnBrowseRestore.Click += new System.EventHandler(this.btnBrowseRestore_Click);
            // 
            // txtFileNameRestore
            // 
            this.txtFileNameRestore.Location = new System.Drawing.Point(7, 56);
            this.txtFileNameRestore.MaxLength = 5000;
            this.txtFileNameRestore.Name = "txtFileNameRestore";
            this.txtFileNameRestore.ReadOnly = true;
            this.txtFileNameRestore.Size = new System.Drawing.Size(223, 20);
            this.txtFileNameRestore.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtFileNameRestore, global::GeoViewer.Data.Properties.Resources.BackupRestoreForm_Restore_Hint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbBackup);
            this.groupBox1.Controls.Add(this.txtFileNameBackup);
            this.groupBox1.Controls.Add(this.btnBrowseBackup);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 175);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sao Lưu";
            // 
            // lbBackup
            // 
            this.lbBackup.AutoSize = true;
            this.lbBackup.Location = new System.Drawing.Point(6, 26);
            this.lbBackup.Name = "lbBackup";
            this.lbBackup.Size = new System.Drawing.Size(148, 14);
            this.lbBackup.TabIndex = 4;
            this.lbBackup.Text = "Chọn thư mục sao lưu dữ liệu";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = global::GeoViewer.Data.Properties.Resources.ToolTip_Title;
            // 
            // BackupRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupRestoreForm";
            this.Text = "Sao lưu phục hồi dữ liệu";
            this.Load += new System.EventHandler(this.BackupRestoreForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox txtFileNameBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowseRestore;
        private System.Windows.Forms.TextBox txtFileNameRestore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbBackup;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.ToolTip toolTip1;


    }
}