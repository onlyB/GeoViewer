using GeoViewer.Views.PictureView.Properties;

namespace GeoViewer.Views.PictureView
{
    partial class PictureViewsManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureViewsManagerForm));
            this.newPictureButton = new System.Windows.Forms.Button();
            this.pictureDataGrid = new System.Windows.Forms.DataGridView();
            this.PictureViewID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureViewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addEditBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDataGrid)).BeginInit();
            this.addEditBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newPictureButton
            // 
            this.newPictureButton.Image = global::GeoViewer.Views.PictureView.Properties.Resources.add_16;
            this.newPictureButton.Location = new System.Drawing.Point(0, 3);
            this.newPictureButton.Name = "newPictureButton";
            this.newPictureButton.Size = new System.Drawing.Size(80, 26);
            this.newPictureButton.TabIndex = 10;
            this.newPictureButton.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewsManagerForm_New_Picture;
            this.newPictureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newPictureButton.UseVisualStyleBackColor = true;
            this.newPictureButton.Click += new System.EventHandler(this.newPictureButton_Click);
            // 
            // pictureDataGrid
            // 
            this.pictureDataGrid.AllowUserToAddRows = false;
            this.pictureDataGrid.AllowUserToDeleteRows = false;
            this.pictureDataGrid.AllowUserToOrderColumns = true;
            this.pictureDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.pictureDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pictureDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PictureViewID,
            this.PictureViewName,
            this.Description,
            this.CreatedDate,
            this.CreatedUser,
            this.LastEditedDate,
            this.LastEditedUser});
            this.pictureDataGrid.Location = new System.Drawing.Point(12, 12);
            this.pictureDataGrid.Name = "pictureDataGrid";
            this.pictureDataGrid.ReadOnly = true;
            this.pictureDataGrid.RowHeadersVisible = false;
            this.pictureDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pictureDataGrid.Size = new System.Drawing.Size(670, 217);
            this.pictureDataGrid.TabIndex = 9;
            this.pictureDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pictureDataGrid_CellDoubleClick);
            // 
            // PictureViewID
            // 
            this.PictureViewID.DataPropertyName = "PictureViewID";
            this.PictureViewID.FillWeight = 177.665F;
            this.PictureViewID.HeaderText = "Mã";
            this.PictureViewID.Name = "PictureViewID";
            this.PictureViewID.ReadOnly = true;
            this.PictureViewID.Width = 50;
            // 
            // PictureViewName
            // 
            this.PictureViewName.DataPropertyName = "Name";
            this.PictureViewName.FillWeight = 463.2392F;
            this.PictureViewName.HeaderText = "Tên";
            this.PictureViewName.Name = "PictureViewName";
            this.PictureViewName.ReadOnly = true;
            this.PictureViewName.Width = 200;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 11.81917F;
            this.Description.HeaderText = "Mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.FillWeight = 11.81917F;
            this.CreatedDate.HeaderText = "Ngày tạo";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // CreatedUser
            // 
            this.CreatedUser.DataPropertyName = "CreatedUser";
            this.CreatedUser.FillWeight = 11.81917F;
            this.CreatedUser.HeaderText = "Người tạo";
            this.CreatedUser.Name = "CreatedUser";
            this.CreatedUser.ReadOnly = true;
            // 
            // LastEditedDate
            // 
            this.LastEditedDate.DataPropertyName = "LastEditedDate";
            this.LastEditedDate.FillWeight = 11.81917F;
            this.LastEditedDate.HeaderText = "Ngày sửa cuối";
            this.LastEditedDate.Name = "LastEditedDate";
            this.LastEditedDate.ReadOnly = true;
            // 
            // LastEditedUser
            // 
            this.LastEditedUser.DataPropertyName = "LastEditedUser";
            this.LastEditedUser.FillWeight = 11.81917F;
            this.LastEditedUser.HeaderText = "Người sửa cuối";
            this.LastEditedUser.Name = "LastEditedUser";
            this.LastEditedUser.ReadOnly = true;
            // 
            // addEditBox
            // 
            this.addEditBox.Controls.Add(this.saveButton);
            this.addEditBox.Controls.Add(this.descriptionTextBox);
            this.addEditBox.Controls.Add(this.nameTextBox);
            this.addEditBox.Controls.Add(this.label2);
            this.addEditBox.Controls.Add(this.label1);
            this.addEditBox.Enabled = false;
            this.addEditBox.Location = new System.Drawing.Point(12, 272);
            this.addEditBox.Name = "addEditBox";
            this.addEditBox.Size = new System.Drawing.Size(670, 145);
            this.addEditBox.TabIndex = 11;
            this.addEditBox.TabStop = false;
            this.addEditBox.Text = "Thêm / Sửa Picture View";
            // 
            // saveButton
            // 
            this.saveButton.Image = global::GeoViewer.Views.PictureView.Properties.Resources.disk_16;
            this.saveButton.Location = new System.Drawing.Point(584, 16);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewsManagerForm_save;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(32, 64);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(617, 68);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(99, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(477, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thông tin mô tả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.reloadButton);
            this.panel1.Controls.Add(this.newPictureButton);
            this.panel1.Location = new System.Drawing.Point(12, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 35);
            this.panel1.TabIndex = 12;
            // 
            // viewButton
            // 
            this.viewButton.Image = global::GeoViewer.Views.PictureView.Properties.Resources.login_16;
            this.viewButton.Location = new System.Drawing.Point(258, 3);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(80, 26);
            this.viewButton.TabIndex = 14;
            this.viewButton.Text = "Xem";
            this.viewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(172, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 26);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewsManagerForm_Delete;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.Location = new System.Drawing.Point(86, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 26);
            this.editButton.TabIndex = 12;
            this.editButton.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewsManagerForm_Edit;
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadButton.Image")));
            this.reloadButton.Location = new System.Drawing.Point(584, 5);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(86, 26);
            this.reloadButton.TabIndex = 11;
            this.reloadButton.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewsManagerForm_RefreshTable;
            this.reloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // PictureViewsManagerForm
            // 
            this.AcceptButton = this.viewButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureDataGrid);
            this.Controls.Add(this.addEditBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PictureViewsManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hình ảnh";
            this.Load += new System.EventHandler(this.PictureViewsManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDataGrid)).EndInit();
            this.addEditBox.ResumeLayout(false);
            this.addEditBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newPictureButton;
        private System.Windows.Forms.DataGridView pictureDataGrid;
        private System.Windows.Forms.GroupBox addEditBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn PictureViewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PictureViewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditedUser;
    }
}