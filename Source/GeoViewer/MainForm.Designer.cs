using GeoViewer.Properties;

namespace GeoViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggersSensorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureViewButton = new System.Windows.Forms.Button();
            this.chartViewButton = new System.Windows.Forms.Button();
            this.textViewButton = new System.Windows.Forms.Button();
            this.alarmLogButton = new System.Windows.Forms.Button();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.appContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmNotifyTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.appContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.alarmToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.userToolStripMenuItem.Image = global::GeoViewer.Properties.Resources.man_16;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.logoutToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Logout;
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Exit;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManagerToolStripMenuItem,
            this.myAccountToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.accountToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Account;
            // 
            // accountManagerToolStripMenuItem
            // 
            this.accountManagerToolStripMenuItem.Name = "accountManagerToolStripMenuItem";
            this.accountManagerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.accountManagerToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_AccountManager;
            this.accountManagerToolStripMenuItem.Click += new System.EventHandler(this.accountManagerToolStripMenuItem_Click);
            // 
            // myAccountToolStripMenuItem
            // 
            this.myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            this.myAccountToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.myAccountToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_MyAccount;
            this.myAccountToolStripMenuItem.Click += new System.EventHandler(this.myAccountToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.closeProjectToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.projectToolStripMenuItem.Text = "Dự án";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openProjectToolStripMenuItem.Text = "Mở dự án";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.closeProjectToolStripMenuItem.Text = "Đóng dự án";
            this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggersSensorsToolStripMenuItem,
            this.backupRestoreToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.dataToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Data;
            // 
            // loggersSensorsToolStripMenuItem
            // 
            this.loggersSensorsToolStripMenuItem.Name = "loggersSensorsToolStripMenuItem";
            this.loggersSensorsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.loggersSensorsToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_LoggerSensor;
            this.loggersSensorsToolStripMenuItem.Click += new System.EventHandler(this.loggersSensorsToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.backupRestoreToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Backup;
            this.backupRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupRestoreToolStripMenuItem_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureViewToolStripMenuItem,
            this.chartViewsToolStripMenuItem,
            this.textViewsToolStripMenuItem});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.viewsToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_View;
            // 
            // pictureViewToolStripMenuItem
            // 
            this.pictureViewToolStripMenuItem.Name = "pictureViewToolStripMenuItem";
            this.pictureViewToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.pictureViewToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Picture_Views;
            this.pictureViewToolStripMenuItem.Click += new System.EventHandler(this.pictureViewToolStripMenuItem_Click);
            // 
            // chartViewsToolStripMenuItem
            // 
            this.chartViewsToolStripMenuItem.Name = "chartViewsToolStripMenuItem";
            this.chartViewsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.chartViewsToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Chart_Views;
            this.chartViewsToolStripMenuItem.Click += new System.EventHandler(this.chartViewsToolStripMenuItem_Click);
            // 
            // textViewsToolStripMenuItem
            // 
            this.textViewsToolStripMenuItem.Name = "textViewsToolStripMenuItem";
            this.textViewsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.textViewsToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_TextView;
            this.textViewsToolStripMenuItem.Click += new System.EventHandler(this.textViewsToolStripMenuItem_Click);
            // 
            // alarmToolStripMenuItem
            // 
            this.alarmToolStripMenuItem.Name = "alarmToolStripMenuItem";
            this.alarmToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.alarmToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Alarm;
            this.alarmToolStripMenuItem.Click += new System.EventHandler(this.alarmToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.helpToolStripMenuItem.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Logout_Help;
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "Giới thiệu";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureViewButton
            // 
            this.pictureViewButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pictureViewButton.Image = global::GeoViewer.Properties.Resources.picture_view_32;
            this.pictureViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureViewButton.Location = new System.Drawing.Point(396, 45);
            this.pictureViewButton.Name = "pictureViewButton";
            this.pictureViewButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.pictureViewButton.Size = new System.Drawing.Size(140, 50);
            this.pictureViewButton.TabIndex = 1;
            this.pictureViewButton.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Picture_Views;
            this.pictureViewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.pictureViewButton.UseVisualStyleBackColor = true;
            this.pictureViewButton.Click += new System.EventHandler(this.pictureViewButton_Click);
            // 
            // chartViewButton
            // 
            this.chartViewButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chartViewButton.Image = global::GeoViewer.Properties.Resources.chart_view_32;
            this.chartViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chartViewButton.Location = new System.Drawing.Point(396, 101);
            this.chartViewButton.Name = "chartViewButton";
            this.chartViewButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.chartViewButton.Size = new System.Drawing.Size(140, 50);
            this.chartViewButton.TabIndex = 2;
            this.chartViewButton.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Chart_Views;
            this.chartViewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chartViewButton.UseVisualStyleBackColor = true;
            this.chartViewButton.Click += new System.EventHandler(this.chartViewButton_Click);
            // 
            // textViewButton
            // 
            this.textViewButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textViewButton.Image = global::GeoViewer.Properties.Resources.text_view_32;
            this.textViewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.textViewButton.Location = new System.Drawing.Point(396, 157);
            this.textViewButton.Name = "textViewButton";
            this.textViewButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.textViewButton.Size = new System.Drawing.Size(140, 50);
            this.textViewButton.TabIndex = 3;
            this.textViewButton.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_TextView;
            this.textViewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textViewButton.UseVisualStyleBackColor = true;
            this.textViewButton.Click += new System.EventHandler(this.textViewButton_Click);
            // 
            // alarmLogButton
            // 
            this.alarmLogButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.alarmLogButton.Image = global::GeoViewer.Properties.Resources.alarm_red_32;
            this.alarmLogButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.alarmLogButton.Location = new System.Drawing.Point(396, 213);
            this.alarmLogButton.Name = "alarmLogButton";
            this.alarmLogButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.alarmLogButton.Size = new System.Drawing.Size(140, 50);
            this.alarmLogButton.TabIndex = 4;
            this.alarmLogButton.Text = "Cảnh báo";
            this.alarmLogButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.alarmLogButton.UseVisualStyleBackColor = true;
            this.alarmLogButton.Click += new System.EventHandler(this.alarmLogButton_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.copyrightLabel.ForeColor = System.Drawing.Color.Red;
            this.copyrightLabel.Location = new System.Drawing.Point(27, 289);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(175, 14);
            this.copyrightLabel.TabIndex = 5;
            this.copyrightLabel.Text = "Phần mềm quan trắc GeoDIV V1.1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GeoViewer.Properties.Resources.GeoDiv1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(30, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 223);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.ContextMenuStrip = this.appContextMenu;
            this.appNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("appNotifyIcon.Icon")));
            this.appNotifyIcon.Text = global::GeoViewer.Properties.Resources.MainForm_NotifyIcon_Title;
            this.appNotifyIcon.Visible = true;
            this.appNotifyIcon.DoubleClick += new System.EventHandler(this.appNotifyIcon_DoubleClick);
            // 
            // appContextMenu
            // 
            this.appContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.appContextMenu.Name = "appContextMenu";
            this.appContextMenu.Size = new System.Drawing.Size(142, 26);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem1.Text = global::GeoViewer.Properties.Resources.MainForm_MenuItem_Exit;
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // alarmNotifyTimer
            // 
            this.alarmNotifyTimer.Enabled = true;
            this.alarmNotifyTimer.Interval = 20000;
            this.alarmNotifyTimer.Tick += new System.EventHandler(this.alarmNotifyTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 312);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.alarmLogButton);
            this.Controls.Add(this.textViewButton);
            this.Controls.Add(this.chartViewButton);
            this.Controls.Add(this.pictureViewButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeoDIV V1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.appContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggersSensorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartViewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textViewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button pictureViewButton;
        private System.Windows.Forms.Button chartViewButton;
        private System.Windows.Forms.Button textViewButton;
        private System.Windows.Forms.Button alarmLogButton;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip appContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer alarmNotifyTimer;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
    }
}