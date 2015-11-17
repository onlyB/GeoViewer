using GeoViewer.Views.ChartView.Properties;

namespace GeoViewer.Views.ChartView
{
    partial class ChartViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartViewForm));
            this.zedChartMain = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedChartMain
            // 
            this.zedChartMain.Location = new System.Drawing.Point(5, 3);
            this.zedChartMain.Name = "zedChartMain";
            this.zedChartMain.ScrollGrace = 0D;
            this.zedChartMain.ScrollMaxX = 0D;
            this.zedChartMain.ScrollMaxY = 0D;
            this.zedChartMain.ScrollMaxY2 = 0D;
            this.zedChartMain.ScrollMinX = 0D;
            this.zedChartMain.ScrollMinY = 0D;
            this.zedChartMain.ScrollMinY2 = 0D;
            this.zedChartMain.Size = new System.Drawing.Size(828, 446);
            this.zedChartMain.TabIndex = 0;
            // 
            // ChartViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 453);
            this.Controls.Add(this.zedChartMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart View";
            this.Load += new System.EventHandler(this.ChartViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedChartMain;


    }
}