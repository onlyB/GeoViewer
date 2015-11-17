using Geoviewer.Security.Properties;

namespace Geoviewer.Security
{
    partial class AccountManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManagerForm));
            this.accountGridView = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastLoginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addeditBox = new System.Windows.Forms.GroupBox();
            this.lockCheckBox = new System.Windows.Forms.CheckBox();
            this.approveCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckAlarmView = new System.Windows.Forms.CheckBox();
            this.ckAlarmEdit = new System.Windows.Forms.CheckBox();
            this.ckAlarmManage = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckViewsView = new System.Windows.Forms.CheckBox();
            this.ckViewsEdit = new System.Windows.Forms.CheckBox();
            this.ckViewsManage = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckDataView = new System.Windows.Forms.CheckBox();
            this.ckDataEdit = new System.Windows.Forms.CheckBox();
            this.ckDataManage = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckAccountView = new System.Windows.Forms.CheckBox();
            this.ckAccountEdit = new System.Windows.Forms.CheckBox();
            this.ckAccountManage = new System.Windows.Forms.CheckBox();
            this.resetPassButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reloadButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accountGridView)).BeginInit();
            this.addeditBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountGridView
            // 
            this.accountGridView.AllowUserToAddRows = false;
            this.accountGridView.AllowUserToDeleteRows = false;
            this.accountGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Roles,
            this.Email,
            this.FullName,
            this.IsApproved,
            this.IsLocked,
            this.CreateDate,
            this.LastLoginDate,
            this.Password});
            this.accountGridView.Location = new System.Drawing.Point(12, 12);
            this.accountGridView.MultiSelect = false;
            this.accountGridView.Name = "accountGridView";
            this.accountGridView.ReadOnly = true;
            this.accountGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountGridView.Size = new System.Drawing.Size(960, 207);
            this.accountGridView.TabIndex = 0;
            this.accountGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountGridView_CellDoubleClick);
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = Resources.AccountManagerForm_Account;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.ToolTipText = Resources.AccountManagerForm_Account_Hint;
            this.Username.Width = 115;
            // 
            // Roles
            // 
            this.Roles.DataPropertyName = "Roles";
            this.Roles.HeaderText = Resources.AccountManagerForm_Role;
            this.Roles.Name = "Roles";
            this.Roles.ReadOnly = true;
            this.Roles.Visible = false;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = Resources.AccountManagerForm_Email;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 250;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = Resources.AccountManagerForm_FullName;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 150;
            // 
            // IsApproved
            // 
            this.IsApproved.DataPropertyName = "IsApproved";
            this.IsApproved.FalseValue = "Chưa duyệt";
            this.IsApproved.HeaderText = Resources.AccountManagerForm_Approved;
            this.IsApproved.Name = "IsApproved";
            this.IsApproved.ReadOnly = true; 
            this.IsApproved.TrueValue = Resources.AccountManagerForm_Approved;
            // 
            // IsLocked
            // 
            this.IsLocked.DataPropertyName = "IsLocked";
            this.IsLocked.FalseValue = "Hoạt động";
            this.IsLocked.HeaderText = Resources.AccountManagerForm_Locked;
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.TrueValue = Resources.AccountManagerForm_Locked;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreatedDate";
            this.CreateDate.HeaderText = Resources.AccountManagerForm_CreatedDate;
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // LastLoginDate
            // 
            this.LastLoginDate.DataPropertyName = "LastLoginDate";
            this.LastLoginDate.HeaderText = Resources.AccountManagerForm_LastLoginDate;
            this.LastLoginDate.Name = "LastLoginDate";
            this.LastLoginDate.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = Resources.AccountManagerForm_Password;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // addeditBox
            // 
            this.addeditBox.Controls.Add(this.lockCheckBox);
            this.addeditBox.Controls.Add(this.approveCheckBox);
            this.addeditBox.Controls.Add(this.groupBox4);
            this.addeditBox.Controls.Add(this.groupBox3);
            this.addeditBox.Controls.Add(this.groupBox2);
            this.addeditBox.Controls.Add(this.groupBox1);
            this.addeditBox.Controls.Add(this.resetPassButton);
            this.addeditBox.Controls.Add(this.saveButton);
            this.addeditBox.Controls.Add(this.txtPassword);
            this.addeditBox.Controls.Add(this.txtFullName);
            this.addeditBox.Controls.Add(this.txtEmail);
            this.addeditBox.Controls.Add(this.txtUsername);
            this.addeditBox.Controls.Add(this.label4);
            this.addeditBox.Controls.Add(this.label3);
            this.addeditBox.Controls.Add(this.label2);
            this.addeditBox.Controls.Add(this.label1);
            this.addeditBox.Enabled = false;
            this.addeditBox.Location = new System.Drawing.Point(12, 259);
            this.addeditBox.Name = "addeditBox";
            this.addeditBox.Size = new System.Drawing.Size(960, 341);
            this.addeditBox.TabIndex = 1;
            this.addeditBox.TabStop = false;
            this.addeditBox.Text = Resources.AccountManagerForm_AddEdit;
            // 
            // lockCheckBox
            // 
            this.lockCheckBox.AutoSize = true;
            this.lockCheckBox.Location = new System.Drawing.Point(115, 142);
            this.lockCheckBox.Name = "lockCheckBox";
            this.lockCheckBox.Size = new System.Drawing.Size(97, 18);
            this.lockCheckBox.TabIndex = 15;
            this.lockCheckBox.Text = Resources.AccountManagerForm_Lock;
            this.lockCheckBox.UseVisualStyleBackColor = true;
            // 
            // approveCheckBox
            // 
            this.approveCheckBox.AutoSize = true;
            this.approveCheckBox.Location = new System.Drawing.Point(20, 142);
            this.approveCheckBox.Name = "approveCheckBox";
            this.approveCheckBox.Size = new System.Drawing.Size(70, 18);
            this.approveCheckBox.TabIndex = 14;
            this.approveCheckBox.Text = Resources.AccountManagerForm_Approved;
            this.approveCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckAlarmView);
            this.groupBox4.Controls.Add(this.ckAlarmEdit);
            this.groupBox4.Controls.Add(this.ckAlarmManage);
            this.groupBox4.Location = new System.Drawing.Point(716, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 134);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = Resources.AccountManagerForm_AlarmRole;
            // 
            // ckAlarmView
            // 
            this.ckAlarmView.AutoSize = true;
            this.ckAlarmView.Location = new System.Drawing.Point(20, 82);
            this.ckAlarmView.Name = "ckAlarmView";
            this.ckAlarmView.Size = new System.Drawing.Size(106, 18);
            this.ckAlarmView.TabIndex = 2;
            this.ckAlarmView.Text = Resources.AccountManagerForm_RoleView;
            this.ckAlarmView.UseVisualStyleBackColor = true;
            // 
            // ckAlarmEdit
            // 
            this.ckAlarmEdit.AutoSize = true;
            this.ckAlarmEdit.Location = new System.Drawing.Point(20, 58);
            this.ckAlarmEdit.Name = "ckAlarmEdit";
            this.ckAlarmEdit.Size = new System.Drawing.Size(75, 18);
            this.ckAlarmEdit.TabIndex = 1;
            this.ckAlarmEdit.Text = Resources.AccountManagerForm_RoleEdit;
            this.ckAlarmEdit.UseVisualStyleBackColor = true;
            // 
            // ckAlarmManage
            // 
            this.ckAlarmManage.AutoSize = true;
            this.ckAlarmManage.Location = new System.Drawing.Point(20, 34);
            this.ckAlarmManage.Name = "ckAlarmManage";
            this.ckAlarmManage.Size = new System.Drawing.Size(82, 18);
            this.ckAlarmManage.TabIndex = 0;
            this.ckAlarmManage.Text = Resources.AccountManagerForm_RoleManage;
            this.ckAlarmManage.UseVisualStyleBackColor = true;
            this.ckAlarmManage.CheckedChanged += new System.EventHandler(this.ckAlarmManage_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckViewsView);
            this.groupBox3.Controls.Add(this.ckViewsEdit);
            this.groupBox3.Controls.Add(this.ckViewsManage);
            this.groupBox3.Location = new System.Drawing.Point(484, 175);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 134);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = Resources.AccountManagerForm_ViewRole;
            // 
            // ckViewsView
            // 
            this.ckViewsView.AutoSize = true;
            this.ckViewsView.Location = new System.Drawing.Point(20, 82);
            this.ckViewsView.Name = "ckViewsView";
            this.ckViewsView.Size = new System.Drawing.Size(106, 18);
            this.ckViewsView.TabIndex = 2;
            this.ckViewsView.Text = Resources.AccountManagerForm_RoleView;
            this.ckViewsView.UseVisualStyleBackColor = true;
            // 
            // ckViewsEdit
            // 
            this.ckViewsEdit.AutoSize = true;
            this.ckViewsEdit.Location = new System.Drawing.Point(20, 58);
            this.ckViewsEdit.Name = "ckViewsEdit";
            this.ckViewsEdit.Size = new System.Drawing.Size(75, 18);
            this.ckViewsEdit.TabIndex = 1;
            this.ckViewsEdit.Text = Resources.AccountManagerForm_RoleEdit;
            this.ckViewsEdit.UseVisualStyleBackColor = true;
            // 
            // ckViewsManage
            // 
            this.ckViewsManage.AutoSize = true;
            this.ckViewsManage.Location = new System.Drawing.Point(20, 34);
            this.ckViewsManage.Name = "ckViewsManage";
            this.ckViewsManage.Size = new System.Drawing.Size(82, 18);
            this.ckViewsManage.TabIndex = 0;
            this.ckViewsManage.Text = Resources.AccountManagerForm_RoleManage;
            this.ckViewsManage.UseVisualStyleBackColor = true;
            this.ckViewsManage.CheckedChanged += new System.EventHandler(this.ckViewsManage_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckDataView);
            this.groupBox2.Controls.Add(this.ckDataEdit);
            this.groupBox2.Controls.Add(this.ckDataManage);
            this.groupBox2.Location = new System.Drawing.Point(252, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 134);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = Resources.AccountManagerForm_DataRole;
            // 
            // ckDataView
            // 
            this.ckDataView.AutoSize = true;
            this.ckDataView.Location = new System.Drawing.Point(20, 82);
            this.ckDataView.Name = "ckDataView";
            this.ckDataView.Size = new System.Drawing.Size(106, 18);
            this.ckDataView.TabIndex = 2;
            this.ckDataView.Text = Resources.AccountManagerForm_RoleView;
            this.ckDataView.UseVisualStyleBackColor = true;
            // 
            // ckDataEdit
            // 
            this.ckDataEdit.AutoSize = true;
            this.ckDataEdit.Location = new System.Drawing.Point(20, 58);
            this.ckDataEdit.Name = "ckDataEdit";
            this.ckDataEdit.Size = new System.Drawing.Size(75, 18);
            this.ckDataEdit.TabIndex = 1;
            this.ckDataEdit.Text = Resources.AccountManagerForm_RoleEdit;
            this.ckDataEdit.UseVisualStyleBackColor = true;
            // 
            // ckDataManage
            // 
            this.ckDataManage.AutoSize = true;
            this.ckDataManage.Location = new System.Drawing.Point(20, 34);
            this.ckDataManage.Name = "ckDataManage";
            this.ckDataManage.Size = new System.Drawing.Size(82, 18);
            this.ckDataManage.TabIndex = 0;
            this.ckDataManage.Text = Resources.AccountManagerForm_RoleManage;
            this.ckDataManage.UseVisualStyleBackColor = true;
            this.ckDataManage.CheckedChanged += new System.EventHandler(this.ckDataManage_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckAccountView);
            this.groupBox1.Controls.Add(this.ckAccountEdit);
            this.groupBox1.Controls.Add(this.ckAccountManage);
            this.groupBox1.Location = new System.Drawing.Point(20, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 134);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = Resources.AccountManagerForm_AccountRole;
            // 
            // ckAccountView
            // 
            this.ckAccountView.AutoSize = true;
            this.ckAccountView.Location = new System.Drawing.Point(20, 82);
            this.ckAccountView.Name = "ckAccountView";
            this.ckAccountView.Size = new System.Drawing.Size(106, 18);
            this.ckAccountView.TabIndex = 2;
            this.ckAccountView.Text = Resources.AccountManagerForm_RoleView;
            this.ckAccountView.UseVisualStyleBackColor = true;
            // 
            // ckAccountEdit
            // 
            this.ckAccountEdit.AutoSize = true;
            this.ckAccountEdit.Location = new System.Drawing.Point(20, 58);
            this.ckAccountEdit.Name = "ckAccountEdit";
            this.ckAccountEdit.Size = new System.Drawing.Size(75, 18);
            this.ckAccountEdit.TabIndex = 1;
            this.ckAccountEdit.Text = Resources.AccountManagerForm_RoleEdit;
            this.ckAccountEdit.UseVisualStyleBackColor = true;
            // 
            // ckAccountManage
            // 
            this.ckAccountManage.AutoSize = true;
            this.ckAccountManage.Location = new System.Drawing.Point(20, 34);
            this.ckAccountManage.Name = "ckAccountManage";
            this.ckAccountManage.Size = new System.Drawing.Size(82, 18);
            this.ckAccountManage.TabIndex = 0;
            this.ckAccountManage.Text = Resources.AccountManagerForm_RoleManage;
            this.ckAccountManage.UseVisualStyleBackColor = true;
            this.ckAccountManage.CheckedChanged += new System.EventHandler(this.ckAccountManage_CheckedChanged);
            // 
            // resetPassButton
            // 
            this.resetPassButton.Image = global::Geoviewer.Security.Properties.Resources.key_edit_16;
            this.resetPassButton.Location = new System.Drawing.Point(398, 100);
            this.resetPassButton.Name = "resetPassButton";
            this.resetPassButton.Size = new System.Drawing.Size(120, 23);
            this.resetPassButton.TabIndex = 10;
            this.resetPassButton.Text = Resources.AccountManagerForm_ResetPass;
            this.resetPassButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.resetPassButton, Resources.AccountManagerForm_ResetPass_Hint);
            this.resetPassButton.UseVisualStyleBackColor = true;
            this.resetPassButton.Click += new System.EventHandler(this.resetPassButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Image = global::Geoviewer.Security.Properties.Resources.disk_16;
            this.saveButton.Location = new System.Drawing.Point(863, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = Resources.Save;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(86, 101);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(306, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(86, 75);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(306, 20);
            this.txtFullName.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(86, 49);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(306, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(86, 22);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(306, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = Resources.AccountManagerForm_Password;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = Resources.AccountManagerForm_FullName;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = Resources.AccountManagerForm_Email;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = Resources.AccountManagerForm_Account;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reloadButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Location = new System.Drawing.Point(12, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 28);
            this.panel1.TabIndex = 2;
            // 
            // reloadButton
            // 
            this.reloadButton.Image = global::Geoviewer.Security.Properties.Resources.refresh_16;
            this.reloadButton.Location = new System.Drawing.Point(860, 1);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(100, 26);
            this.reloadButton.TabIndex = 3;
            this.reloadButton.Text = Resources.RefreshTable;
            this.reloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::Geoviewer.Security.Properties.Resources.delete_16;
            this.deleteButton.Location = new System.Drawing.Point(167, 1);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 26);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = Resources.Delete;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = global::Geoviewer.Security.Properties.Resources.table_edit_16;
            this.editButton.Location = new System.Drawing.Point(86, 1);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 26);
            this.editButton.TabIndex = 1;
            this.editButton.Text = Resources.AccountManagerForm_RoleEdit;
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::Geoviewer.Security.Properties.Resources.add_16;
            this.addButton.Location = new System.Drawing.Point(4, 1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 26);
            this.addButton.TabIndex = 0;
            this.addButton.Text = Resources.Add;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = Resources.Tooltip_Title;
            // 
            // AccountManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addeditBox);
            this.Controls.Add(this.accountGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Resources.AccountManagerForm_Title;
            this.toolTip1.SetToolTip(this, Resources.AccountManagerForm_Title);
            this.Load += new System.EventHandler(this.AccountManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountGridView)).EndInit();
            this.addeditBox.ResumeLayout(false);
            this.addeditBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox addeditBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button resetPassButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView accountGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsApproved;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastLoginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckAccountView;
        private System.Windows.Forms.CheckBox ckAccountEdit;
        private System.Windows.Forms.CheckBox ckAccountManage;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckAlarmView;
        private System.Windows.Forms.CheckBox ckAlarmEdit;
        private System.Windows.Forms.CheckBox ckAlarmManage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckViewsView;
        private System.Windows.Forms.CheckBox ckViewsEdit;
        private System.Windows.Forms.CheckBox ckViewsManage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckDataView;
        private System.Windows.Forms.CheckBox ckDataEdit;
        private System.Windows.Forms.CheckBox ckDataManage;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.CheckBox lockCheckBox;
        private System.Windows.Forms.CheckBox approveCheckBox;
    }
}