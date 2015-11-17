namespace Geoviewer.Security
{
    partial class AccountUpdateForm
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
            this.updateInfoBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.changePassButton = new System.Windows.Forms.Button();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLastLoginDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ckAlarmView = new System.Windows.Forms.CheckBox();
            this.ckAlarmEdit = new System.Windows.Forms.CheckBox();
            this.ckAlarmManage = new System.Windows.Forms.CheckBox();
            this.ckViewsView = new System.Windows.Forms.CheckBox();
            this.ckViewsEdit = new System.Windows.Forms.CheckBox();
            this.ckViewsManage = new System.Windows.Forms.CheckBox();
            this.ckDataView = new System.Windows.Forms.CheckBox();
            this.ckDataEdit = new System.Windows.Forms.CheckBox();
            this.ckDataManage = new System.Windows.Forms.CheckBox();
            this.ckAccountView = new System.Windows.Forms.CheckBox();
            this.ckAccountEdit = new System.Windows.Forms.CheckBox();
            this.ckAccountManage = new System.Windows.Forms.CheckBox();
            this.updateInfoBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateInfoBox
            // 
            this.updateInfoBox.Controls.Add(this.saveButton);
            this.updateInfoBox.Controls.Add(this.txtFullName);
            this.updateInfoBox.Controls.Add(this.txtEmail);
            this.updateInfoBox.Controls.Add(this.txtUsername);
            this.updateInfoBox.Controls.Add(this.label3);
            this.updateInfoBox.Controls.Add(this.label2);
            this.updateInfoBox.Controls.Add(this.label1);
            this.updateInfoBox.Location = new System.Drawing.Point(12, 12);
            this.updateInfoBox.Name = "updateInfoBox";
            this.updateInfoBox.Size = new System.Drawing.Size(660, 104);
            this.updateInfoBox.TabIndex = 0;
            this.updateInfoBox.TabStop = false;
            this.updateInfoBox.Text = "Cập nhật thông tin";
            // 
            // saveButton
            // 
            this.saveButton.Image = global::Geoviewer.Security.Properties.Resources.disk_16;
            this.saveButton.Location = new System.Drawing.Point(568, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Lưu";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(109, 73);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(306, 20);
            this.txtFullName.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(109, 47);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(306, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(109, 20);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(306, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tài khoản";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.changePassButton);
            this.groupBox1.Controls.Add(this.txtOldPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đổi mật khẩu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nhập lại mk mới";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(109, 71);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(306, 20);
            this.txtConfirmPassword.TabIndex = 16;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(109, 45);
            this.txtNewPassword.MaxLength = 50;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(306, 20);
            this.txtNewPassword.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mật khẩu mới";
            // 
            // changePassButton
            // 
            this.changePassButton.Image = global::Geoviewer.Security.Properties.Resources.key_edit_16;
            this.changePassButton.Location = new System.Drawing.Point(568, 22);
            this.changePassButton.Name = "changePassButton";
            this.changePassButton.Size = new System.Drawing.Size(80, 26);
            this.changePassButton.TabIndex = 13;
            this.changePassButton.Text = "Đổi";
            this.changePassButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.changePassButton.UseVisualStyleBackColor = true;
            this.changePassButton.Click += new System.EventHandler(this.changePassButton_Click);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(109, 19);
            this.txtOldPassword.MaxLength = 50;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(306, 20);
            this.txtOldPassword.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mật khẩu cũ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLastLoginDate);
            this.groupBox2.Controls.Add(this.lblCreatedDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ckAlarmView);
            this.groupBox2.Controls.Add(this.ckAlarmEdit);
            this.groupBox2.Controls.Add(this.ckAlarmManage);
            this.groupBox2.Controls.Add(this.ckViewsView);
            this.groupBox2.Controls.Add(this.ckViewsEdit);
            this.groupBox2.Controls.Add(this.ckViewsManage);
            this.groupBox2.Controls.Add(this.ckDataView);
            this.groupBox2.Controls.Add(this.ckDataEdit);
            this.groupBox2.Controls.Add(this.ckDataManage);
            this.groupBox2.Controls.Add(this.ckAccountView);
            this.groupBox2.Controls.Add(this.ckAccountEdit);
            this.groupBox2.Controls.Add(this.ckAccountManage);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 170);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tài khoản";
            // 
            // lblLastLoginDate
            // 
            this.lblLastLoginDate.AutoSize = true;
            this.lblLastLoginDate.Location = new System.Drawing.Point(180, 51);
            this.lblLastLoginDate.Name = "lblLastLoginDate";
            this.lblLastLoginDate.Size = new System.Drawing.Size(48, 14);
            this.lblLastLoginDate.TabIndex = 15;
            this.lblLastLoginDate.Text = "Datetime";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(180, 28);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(48, 14);
            this.lblCreatedDate.TabIndex = 14;
            this.lblCreatedDate.Text = "Datetime";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "Đăng nhập lần cuối";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ngày khởi tạo";
            // 
            // ckAlarmView
            // 
            this.ckAlarmView.AutoSize = true;
            this.ckAlarmView.Enabled = false;
            this.ckAlarmView.Location = new System.Drawing.Point(521, 126);
            this.ckAlarmView.Name = "ckAlarmView";
            this.ckAlarmView.Size = new System.Drawing.Size(106, 18);
            this.ckAlarmView.TabIndex = 11;
            this.ckAlarmView.Text = "Xem, in, báo cáo";
            this.ckAlarmView.UseVisualStyleBackColor = true;
            // 
            // ckAlarmEdit
            // 
            this.ckAlarmEdit.AutoSize = true;
            this.ckAlarmEdit.Enabled = false;
            this.ckAlarmEdit.Location = new System.Drawing.Point(521, 102);
            this.ckAlarmEdit.Name = "ckAlarmEdit";
            this.ckAlarmEdit.Size = new System.Drawing.Size(75, 18);
            this.ckAlarmEdit.TabIndex = 10;
            this.ckAlarmEdit.Text = "Chỉnh sửa";
            this.ckAlarmEdit.UseVisualStyleBackColor = true;
            // 
            // ckAlarmManage
            // 
            this.ckAlarmManage.AutoSize = true;
            this.ckAlarmManage.Enabled = false;
            this.ckAlarmManage.Location = new System.Drawing.Point(521, 78);
            this.ckAlarmManage.Name = "ckAlarmManage";
            this.ckAlarmManage.Size = new System.Drawing.Size(82, 18);
            this.ckAlarmManage.TabIndex = 9;
            this.ckAlarmManage.Text = "Toàn quyền";
            this.ckAlarmManage.UseVisualStyleBackColor = true;
            // 
            // ckViewsView
            // 
            this.ckViewsView.AutoSize = true;
            this.ckViewsView.Enabled = false;
            this.ckViewsView.Location = new System.Drawing.Point(355, 126);
            this.ckViewsView.Name = "ckViewsView";
            this.ckViewsView.Size = new System.Drawing.Size(106, 18);
            this.ckViewsView.TabIndex = 8;
            this.ckViewsView.Text = "Xem, in, báo cáo";
            this.ckViewsView.UseVisualStyleBackColor = true;
            // 
            // ckViewsEdit
            // 
            this.ckViewsEdit.AutoSize = true;
            this.ckViewsEdit.Enabled = false;
            this.ckViewsEdit.Location = new System.Drawing.Point(355, 102);
            this.ckViewsEdit.Name = "ckViewsEdit";
            this.ckViewsEdit.Size = new System.Drawing.Size(75, 18);
            this.ckViewsEdit.TabIndex = 7;
            this.ckViewsEdit.Text = "Chỉnh sửa";
            this.ckViewsEdit.UseVisualStyleBackColor = true;
            // 
            // ckViewsManage
            // 
            this.ckViewsManage.AutoSize = true;
            this.ckViewsManage.Enabled = false;
            this.ckViewsManage.Location = new System.Drawing.Point(355, 78);
            this.ckViewsManage.Name = "ckViewsManage";
            this.ckViewsManage.Size = new System.Drawing.Size(82, 18);
            this.ckViewsManage.TabIndex = 6;
            this.ckViewsManage.Text = "Toàn quyền";
            this.ckViewsManage.UseVisualStyleBackColor = true;
            // 
            // ckDataView
            // 
            this.ckDataView.AutoSize = true;
            this.ckDataView.Enabled = false;
            this.ckDataView.Location = new System.Drawing.Point(180, 126);
            this.ckDataView.Name = "ckDataView";
            this.ckDataView.Size = new System.Drawing.Size(106, 18);
            this.ckDataView.TabIndex = 5;
            this.ckDataView.Text = "Xem, in, báo cáo";
            this.ckDataView.UseVisualStyleBackColor = true;
            // 
            // ckDataEdit
            // 
            this.ckDataEdit.AutoSize = true;
            this.ckDataEdit.Enabled = false;
            this.ckDataEdit.Location = new System.Drawing.Point(180, 102);
            this.ckDataEdit.Name = "ckDataEdit";
            this.ckDataEdit.Size = new System.Drawing.Size(75, 18);
            this.ckDataEdit.TabIndex = 4;
            this.ckDataEdit.Text = "Chỉnh sửa";
            this.ckDataEdit.UseVisualStyleBackColor = true;
            // 
            // ckDataManage
            // 
            this.ckDataManage.AutoSize = true;
            this.ckDataManage.Enabled = false;
            this.ckDataManage.Location = new System.Drawing.Point(180, 78);
            this.ckDataManage.Name = "ckDataManage";
            this.ckDataManage.Size = new System.Drawing.Size(82, 18);
            this.ckDataManage.TabIndex = 3;
            this.ckDataManage.Text = "Toàn quyền";
            this.ckDataManage.UseVisualStyleBackColor = true;
            // 
            // ckAccountView
            // 
            this.ckAccountView.AutoSize = true;
            this.ckAccountView.Enabled = false;
            this.ckAccountView.Location = new System.Drawing.Point(13, 126);
            this.ckAccountView.Name = "ckAccountView";
            this.ckAccountView.Size = new System.Drawing.Size(106, 18);
            this.ckAccountView.TabIndex = 2;
            this.ckAccountView.Text = "Xem, in, báo cáo";
            this.ckAccountView.UseVisualStyleBackColor = true;
            // 
            // ckAccountEdit
            // 
            this.ckAccountEdit.AutoSize = true;
            this.ckAccountEdit.Enabled = false;
            this.ckAccountEdit.Location = new System.Drawing.Point(13, 102);
            this.ckAccountEdit.Name = "ckAccountEdit";
            this.ckAccountEdit.Size = new System.Drawing.Size(75, 18);
            this.ckAccountEdit.TabIndex = 1;
            this.ckAccountEdit.Text = "Chỉnh sửa";
            this.ckAccountEdit.UseVisualStyleBackColor = true;
            // 
            // ckAccountManage
            // 
            this.ckAccountManage.AutoSize = true;
            this.ckAccountManage.Enabled = false;
            this.ckAccountManage.Location = new System.Drawing.Point(13, 78);
            this.ckAccountManage.Name = "ckAccountManage";
            this.ckAccountManage.Size = new System.Drawing.Size(82, 18);
            this.ckAccountManage.TabIndex = 0;
            this.ckAccountManage.Text = "Toàn quyền";
            this.ckAccountManage.UseVisualStyleBackColor = true;
            // 
            // AccountUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateInfoBox);
            this.Name = "AccountUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.AccountUpdateForm_Load);
            this.updateInfoBox.ResumeLayout(false);
            this.updateInfoBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox updateInfoBox;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button changePassButton;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckAccountView;
        private System.Windows.Forms.CheckBox ckAccountEdit;
        private System.Windows.Forms.CheckBox ckAccountManage;
        private System.Windows.Forms.CheckBox ckDataView;
        private System.Windows.Forms.CheckBox ckDataEdit;
        private System.Windows.Forms.CheckBox ckDataManage;
        private System.Windows.Forms.CheckBox ckViewsView;
        private System.Windows.Forms.CheckBox ckViewsEdit;
        private System.Windows.Forms.CheckBox ckViewsManage;
        private System.Windows.Forms.CheckBox ckAlarmView;
        private System.Windows.Forms.CheckBox ckAlarmEdit;
        private System.Windows.Forms.CheckBox ckAlarmManage;
        private System.Windows.Forms.Label lblLastLoginDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}