using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace GeoViewer.Views.PictureView
{
    public class indicator : Control
    {
        private Color fillColor = Color.Lime;
        private string varName = "Name", unitName = "Unit", varValue = "Value";

        public indicator()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            //Set style for double buffering
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            //Set the default backcolor
            this.BackColor = Color.White;
        }

        public string VarName
        {
            get
            {
                return this.varName;
            }
            set
            {
                this.varName = value;
            }
        }

        public string UnitName
        {
            get
            {
                return this.unitName;
            }
            set
            {
                this.unitName = value;
            }
        }

        public string Value
        {
            get
            {
                return this.varValue;
            }
            set
            {
                this.varValue = value;
            }
        }

        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            RectangleF r = new RectangleF(0.0f, 0.0f, (float)this.Width, (float)this.Height);
            RectangleF r2 = new RectangleF(0.0f, System.Convert.ToSingle(this.Height * 2 / 3), (float)this.Width, (float)this.Height);

            float cx = r.Width - 1;
            float cy = r.Height - 1;

            Pen pen = new Pen(new SolidBrush(this.ForeColor), 1);
            pen.Alignment = PenAlignment.Center;
            SolidBrush brush = new SolidBrush(fillColor);
            SolidBrush bckgnd = new SolidBrush(this.BackColor);

            // Creates a path to draw graphics
            GraphicsPath path = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();

            // Paint the control
            path.AddRectangle(r);
            path2.AddRectangle(r2);

            //Creates a region area for the background painting
            this.Region = new Region(path);
            Region re = new System.Drawing.Region(path2);

            //Paint the control background
            g.FillRegion(bckgnd, this.Region);
            g.FillRegion(brush, re);

            //Draw the shape over the control background
            //g.FillEllipse(brush, 0.0f, 0.0f, cx, cy);

            // Draw the shape outline
            g.DrawRectangle(pen, 0, 0, cx, cy);
            Point a = new Point(0, this.Height * 2 / 3);
            Point b = new Point(this.Width, this.Height * 2 / 3);
            Point c = new Point(0, this.Height * 1 / 3);
            g.DrawLine(pen, a, b);
            //g.DrawEllipse(pen, lineThick / 2.0f, lineThick / 2.0f, cx - lineThick, cy - lineThick);
            this.Font = new Font("Microsoft Sans Serif", System.Convert.ToSingle(this.Height * 1 / 6), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawString(this.varName, this.Font, Brushes.Black, 0.0f, 0.0f);
            g.DrawString(this.unitName, this.Font, Brushes.Black, c);
            g.DrawString(this.varValue, this.Font, Brushes.Black, a);

            pen.Dispose();
            brush.Dispose();
            bckgnd.Dispose();
            this.Region.Dispose();
            path.Dispose();
        }

    }
}
