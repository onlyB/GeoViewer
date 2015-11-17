using GeoViewer.Views.ChartView.Properties;

namespace GeoViewer.Views.ChartView
{
    partial class GroupCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupCreate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtgroupname = new System.Windows.Forms.TextBox();
            this.btncreategroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nhóm";
            // 
            // txtgroupname
            // 
            this.txtgroupname.Location = new System.Drawing.Point(85, 18);
            this.txtgroupname.Name = "txtgroupname";
            this.txtgroupname.Size = new System.Drawing.Size(193, 20);
            this.txtgroupname.TabIndex = 1;
            // 
            // btncreategroup
            // 
            this.btncreategroup.Location = new System.Drawing.Point(290, 16);
            this.btncreategroup.Name = "btncreategroup";
            this.btncreategroup.Size = new System.Drawing.Size(75, 25);
            this.btncreategroup.TabIndex = 2;
            this.btncreategroup.Text = global::GeoViewer.Views.ChartView.Properties.Resources.GroupCreate_InitializeComponent_Create;
            this.btncreategroup.UseVisualStyleBackColor = true;
            this.btncreategroup.Click += new System.EventHandler(this.btncreategroup_Click);
            // 
            // GroupCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 62);
            this.Controls.Add(this.btncreategroup);
            this.Controls.Add(this.txtgroupname);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo nhóm cảm biến mới";
            this.Load += new System.EventHandler(this.GroupCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgroupname;
        private System.Windows.Forms.Button btncreategroup;
    }
}