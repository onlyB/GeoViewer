namespace GeoViewer.Data
{
    partial class ReadDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadDataForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressReader = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            this.lblFileLineCount = new System.Windows.Forms.Label();
            this.lblFolderLineCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressReader
            // 
            this.progressReader.Location = new System.Drawing.Point(15, 55);
            this.progressReader.Name = "progressReader";
            this.progressReader.Size = new System.Drawing.Size(581, 23);
            this.progressReader.Step = 1;
            this.progressReader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "File đang đọc:";
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.Location = new System.Drawing.Point(102, 26);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(340, 14);
            this.lblCurrentFile.TabIndex = 2;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(12, 90);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(88, 14);
            this.lblFolder.TabIndex = 3;
            this.lblFolder.Text = "Folder đang đọc:";
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.Location = new System.Drawing.Point(102, 90);
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(340, 14);
            this.lblCurrentFolder.TabIndex = 4;
            // 
            // lblFileLineCount
            // 
            this.lblFileLineCount.Location = new System.Drawing.Point(494, 26);
            this.lblFileLineCount.Name = "lblFileLineCount";
            this.lblFileLineCount.Size = new System.Drawing.Size(100, 14);
            this.lblFileLineCount.TabIndex = 5;
            this.lblFileLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFolderLineCount
            // 
            this.lblFolderLineCount.Location = new System.Drawing.Point(494, 90);
            this.lblFolderLineCount.Name = "lblFolderLineCount";
            this.lblFolderLineCount.Size = new System.Drawing.Size(100, 14);
            this.lblFolderLineCount.TabIndex = 6;
            this.lblFolderLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReadDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 130);
            this.Controls.Add(this.lblFolderLineCount);
            this.Controls.Add(this.lblFileLineCount);
            this.Controls.Add(this.lblCurrentFolder);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressReader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReadDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đọc dữ liệu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblCurrentFolder;
        private System.Windows.Forms.Label lblFileLineCount;
        private System.Windows.Forms.Label lblFolderLineCount;
    }
}