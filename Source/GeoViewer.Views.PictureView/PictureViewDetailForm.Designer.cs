using GeoViewer.Views.PictureView.Properties;

namespace GeoViewer.Views.PictureView
{
    partial class PictureViewDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureViewDetailForm));
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.indicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupIndicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gaugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericIndicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swichEditModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swichValueMode = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.editContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chartViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.editContextMenu.SuspendLayout();
            this.viewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewModeToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.nextToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(984, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.closeToolStripMenuItem.Text = "Đóng lại";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.printPreviewToolStripMenuItem.Text = "Xem bản in";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            this.printPreviewToolStripMenuItem.MouseHover += new System.EventHandler(this.printPreviewToolStripMenuItem_MouseHover);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(29, 20);
            this.printToolStripMenuItem.Text = "In";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            this.printToolStripMenuItem.MouseHover += new System.EventHandler(this.printToolStripMenuItem_MouseHover);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.editToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Edit;
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.toolStripSeparator1,
            this.indicatorToolStripMenuItem,
            this.groupIndicatorToolStripMenuItem,
            this.toolStripSeparator2,
            this.gaugeToolStripMenuItem,
            this.verticalBarToolStripMenuItem,
            this.horizontalBarToolStripMenuItem,
            this.meterToolStripMenuItem,
            this.numericIndicatorToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.addToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Add;
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.imageIcon;
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.imageToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_AddImage;
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // indicatorToolStripMenuItem
            // 
            this.indicatorToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.indicatorIcon;
            this.indicatorToolStripMenuItem.Name = "indicatorToolStripMenuItem";
            this.indicatorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.indicatorToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Indicator;
            this.indicatorToolStripMenuItem.Click += new System.EventHandler(this.indicatorToolStripMenuItem_Click);
            // 
            // groupIndicatorToolStripMenuItem
            // 
            this.groupIndicatorToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.groupIndicatorIcon;
            this.groupIndicatorToolStripMenuItem.Name = "groupIndicatorToolStripMenuItem";
            this.groupIndicatorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.groupIndicatorToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Group_Indicator;
            this.groupIndicatorToolStripMenuItem.Click += new System.EventHandler(this.groupIndicatorToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // gaugeToolStripMenuItem
            // 
            this.gaugeToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.gaugeIcon;
            this.gaugeToolStripMenuItem.Name = "gaugeToolStripMenuItem";
            this.gaugeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.gaugeToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Gauge;
            this.gaugeToolStripMenuItem.Click += new System.EventHandler(this.gaugeToolStripMenuItem_Click);
            // 
            // verticalBarToolStripMenuItem
            // 
            this.verticalBarToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.verticalBarIcon;
            this.verticalBarToolStripMenuItem.Name = "verticalBarToolStripMenuItem";
            this.verticalBarToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.verticalBarToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Vertical_Bar;
            this.verticalBarToolStripMenuItem.Click += new System.EventHandler(this.verticalBarToolStripMenuItem_Click);
            // 
            // horizontalBarToolStripMenuItem
            // 
            this.horizontalBarToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.horizontalBarIcon;
            this.horizontalBarToolStripMenuItem.Name = "horizontalBarToolStripMenuItem";
            this.horizontalBarToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.horizontalBarToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Horizontal_Bar;
            this.horizontalBarToolStripMenuItem.Click += new System.EventHandler(this.horizontalBarToolStripMenuItem_Click);
            // 
            // meterToolStripMenuItem
            // 
            this.meterToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.meterIcon;
            this.meterToolStripMenuItem.Name = "meterToolStripMenuItem";
            this.meterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.meterToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Meter;
            this.meterToolStripMenuItem.Click += new System.EventHandler(this.meterToolStripMenuItem_Click);
            // 
            // numericIndicatorToolStripMenuItem
            // 
            this.numericIndicatorToolStripMenuItem.Image = global::GeoViewer.Views.PictureView.Properties.Resources.numericIndicatorIcon;
            this.numericIndicatorToolStripMenuItem.Name = "numericIndicatorToolStripMenuItem";
            this.numericIndicatorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.numericIndicatorToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Numeric_Indicator;
            this.numericIndicatorToolStripMenuItem.Click += new System.EventHandler(this.numericIndicatorToolStripMenuItem_Click);
            // 
            // viewModeToolStripMenuItem
            // 
            this.viewModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.swichEditModeToolStripMenuItem,
            this.swichValueMode});
            this.viewModeToolStripMenuItem.Name = "viewModeToolStripMenuItem";
            this.viewModeToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.viewModeToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_InitializeComponent_View;
            // 
            // swichEditModeToolStripMenuItem
            // 
            this.swichEditModeToolStripMenuItem.Name = "swichEditModeToolStripMenuItem";
            this.swichEditModeToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.swichEditModeToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_SwichToEditMode;
            this.swichEditModeToolStripMenuItem.Click += new System.EventHandler(this.switchToEditModeToolStripMenuItem_Click);
            // 
            // swichValueMode
            // 
            this.swichValueMode.Name = "swichValueMode";
            this.swichValueMode.Size = new System.Drawing.Size(236, 22);
            this.swichValueMode.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_swichValueMode_Raw;
            this.swichValueMode.Click += new System.EventHandler(this.swichValueMode_Click);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Enabled = false;
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.previousToolStripMenuItem.Text = "<< Trước";
            this.previousToolStripMenuItem.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Enabled = false;
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.nextToolStripMenuItem.Text = "Tiếp >>";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(984, 688);
            this.panel.TabIndex = 3;
            // 
            // editContextMenu
            // 
            this.editContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bringToFrontToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.editContextMenu.Name = "editContextMenu";
            this.editContextMenu.Size = new System.Drawing.Size(146, 70);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.bringToFrontToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Bring_To_Front;
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.editToolStripMenuItem1.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_EditObject;
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_DeleteObject;
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // viewContextMenu
            // 
            this.viewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartViewToolStripMenuItem,
            this.textViewToolStripMenuItem,
            this.pictureViewToolStripMenuItem});
            this.viewContextMenu.Name = "viewContextMenu";
            this.viewContextMenu.Size = new System.Drawing.Size(211, 70);
            // 
            // chartViewToolStripMenuItem
            // 
            this.chartViewToolStripMenuItem.Name = "chartViewToolStripMenuItem";
            this.chartViewToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.chartViewToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Chart_View;
            this.chartViewToolStripMenuItem.Click += new System.EventHandler(this.chartViewToolStripMenuItem_Click);
            // 
            // textViewToolStripMenuItem
            // 
            this.textViewToolStripMenuItem.Name = "textViewToolStripMenuItem";
            this.textViewToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.textViewToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Text_View;
            this.textViewToolStripMenuItem.Click += new System.EventHandler(this.textViewToolStripMenuItem_Click);
            // 
            // pictureViewToolStripMenuItem
            // 
            this.pictureViewToolStripMenuItem.Name = "pictureViewToolStripMenuItem";
            this.pictureViewToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.pictureViewToolStripMenuItem.Text = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Menu_Picture_View;
            this.pictureViewToolStripMenuItem.Click += new System.EventHandler(this.pictureViewToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*";
            this.openFileDialog.Title = global::GeoViewer.Views.PictureView.Properties.Resources.PictureViewDetailForm_Select_an_image;
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.toolTip1.IsBalloon = true;
            // 
            // PictureViewDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 712);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = true;
            this.Name = "PictureViewDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hình ảnh";
            this.Load += new System.EventHandler(this.PictureViewDetailForm_Load);
            this.ResizeEnd += new System.EventHandler(this.PictureViewDetailForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.PictureViewDetailForm_Resize);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.editContextMenu.ResumeLayout(false);
            this.viewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem indicatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupIndicatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem gaugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numericIndicatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewModeToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ContextMenuStrip editContextMenu;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip viewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem chartViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureViewToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem swichEditModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swichValueMode;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}