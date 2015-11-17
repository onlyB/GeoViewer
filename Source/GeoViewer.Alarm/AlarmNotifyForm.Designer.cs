namespace GeoViewer.Alarm
{
    partial class AlarmNotifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmNotifyForm));
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ckEnableSound = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Location = new System.Drawing.Point(12, 172);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(259, 26);
            this.btnTurnOff.TabIndex = 2;
            this.btnTurnOff.Text = "Không hiển thị lại cho tới khi có cảnh báo mới";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::GeoViewer.Alarm.Properties.Resources.nhay_kieu_3;
            this.pictureBox1.Location = new System.Drawing.Point(11, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ckEnableSound
            // 
            this.ckEnableSound.AutoSize = true;
            this.ckEnableSound.Location = new System.Drawing.Point(12, 121);
            this.ckEnableSound.Name = "ckEnableSound";
            this.ckEnableSound.Size = new System.Drawing.Size(137, 18);
            this.ckEnableSound.TabIndex = 6;
            this.ckEnableSound.Text = "Bật âm thanh cảnh báo";
            this.ckEnableSound.UseVisualStyleBackColor = true;
            this.ckEnableSound.CheckedChanged += new System.EventHandler(this.ckEnableSound_CheckedChanged);
            // 
            // AlarmNotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.ckEnableSound);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTurnOff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlarmNotifyForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thông báo!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlarmNotifyForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckEnableSound;
    }
}